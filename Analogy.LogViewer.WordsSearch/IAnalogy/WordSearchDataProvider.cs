using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.WordsSearch.Managers;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public sealed class WordSearchDataProvider : IAnalogySingleFileDataProvider
    {
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        public bool DisableFilePoolingOption { get; } = true;
        public string FileNamePath { get; set; }
        public IEnumerable<string> HideColumns() => new List<string>();
        public Guid Id { get; set; }
        public Image? LargeImage { get; set; } = null;
        public Image? SmallImage { get; set; } = null;
        public string OptionalTitle { get; set; }
        public bool UseCustomColors { get; set; } = false;
        public AnalogyToolTip? ToolTip { get; set; }

        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();
        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public WordSearchDataProvider()
        {
            Id = new Guid("b60aba2a-5130-4e49-ac98-ed1229fd5704");
            OptionalTitle = $"Analogy Words Search";
            FileNamePath = Settings.FilesLocation;
        }

        public Task InitializeDataProvider(IAnalogyLogger logger)
        {
            //do some initialization for this provider
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (Settings.AllLoadedWords.Any())
            {
                return FilterWords(messagesHandler);
            }

            if (string.IsNullOrEmpty(FileNamePath) || !Directory.Exists(FileNamePath))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"Directory is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, FileNamePath);
                return new List<AnalogyLogMessage> { empty };
            }

            string[] files = Directory.GetFiles(FileNamePath, "words*.txt");
            long count = 0;
            foreach (var file in files)
            {
                try
                {
                    using (var stream = File.OpenRead(file))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = await reader.ReadLineAsync() ?? "";
                                var all = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                Settings.AllLoadedWords.AddRange(all.Select(m => new AnalogyInformationMessage(m, Path.GetFileName(file))));
                            }
                        }

                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                    }
                }
                catch (Exception e)
                {

                    AnalogyLogMessage empty = new AnalogyLogMessage($"Error occurred processing file {FileNamePath}. Reason: {e.Message}",
                        AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                    {
                        Source = "Analogy",
                        Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                    };
                    messagesHandler.AppendMessage(empty, FileNamePath);
                };
            }

            return FilterWords(messagesHandler);
        }

        private IEnumerable<AnalogyLogMessage> FilterWords(ILogMessageCreatedHandler messagesHandler)
        {
            List<AnalogyLogMessage> words = new List<AnalogyLogMessage>();
            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            WordsSearchSettingsForm form = new WordsSearchSettingsForm();
            form.ShowDialog();


            foreach (var word in Settings.AllLoadedWords)
            {
                var lower = word.Text.ToLower();
                bool add = word.Text.Length == Settings.Length &&
                          ( !word.Text.StartsWith('(') ||
                           !word.Text.StartsWith('[') |
                           !word.Text.EndsWith(')') ||
                           !word.Text.EndsWith(']') ||
                           !word.Text.StartsWith('.') ||
                           !word.Text.EndsWith('.') ||
                           !word.Text.EndsWith(':') ||
                           !word.Text.StartsWith('"') ||
                           !word.Text.EndsWith('"') ||
                           !word.Text.EndsWith(','));
                foreach (var wp in Settings.CharsPositions)
                {
                    if (!add)
                    {
                        break;
                    }
                    if (wp.Position < lower.Length &&
                        lower[wp.Position] != wp.Char)
                    {
                        add = false;
                    }
                }

                if (add)
                {
                    words.Add(word);
                }

            }

            int count = 0;
            var comparer = new AnalogyLogMessageCustomEqualityComparer()
            {
                CompareText = true,
                CompareCategory = false,
                CompareClass = false,
                CompareDate = false,
                CompareFileName = false,
                CompareId = false,
                CompareLevel = false,
                CompareLineNumber = false,
                CompareMethodName = false,
                CompareModule = false,
                CompareParameters = false,
                CompareProcessId = false,
                CompareSource = false,
                CompareThread = false,
                CompareUser = false
            };
            foreach (var word in words.Distinct(comparer)
                         .OrderBy(m => m.Text))
            {
                messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(
                    AnalogyFileReadProgressType.Incremental, 1, count,
                    count));
                messages.Add(word);
                count++;
            }

            messagesHandler.AppendMessages(messages, FileNamePath);
            return messages;
        }
    }
}
