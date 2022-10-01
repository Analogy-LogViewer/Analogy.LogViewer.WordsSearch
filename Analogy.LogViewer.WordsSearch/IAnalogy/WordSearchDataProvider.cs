using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.WordsSearch.Properties;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public sealed class WordSearchDataProvider : IAnalogySingleFileDataProvider
    {
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
            FileNamePath = "words.txt";
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
            if (string.IsNullOrEmpty(FileNamePath) || !File.Exists(FileNamePath))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, FileNamePath);
                return new List<AnalogyLogMessage> { empty };
            }

            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            try
            {
                long count = 0;
                using (var stream = File.OpenRead(FileNamePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = await reader.ReadLineAsync() ?? "";
                            var m = new AnalogyInformationMessage(line);
                            messagesHandler.ReportFileReadProgress(new AnalogyFileReadProgress(AnalogyFileReadProgressType.Incremental, 1, count, count));
                            messages.Add(m);
                            count++;
                        }
                    }
                }
                messagesHandler.AppendMessages(messages, FileNamePath);
                return messages;
            }
            catch (Exception e)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"Error occured processing file {FileNamePath}. Reason: {e.Message}",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, FileNamePath);
                return new List<AnalogyLogMessage> { empty };
            }
        }



    }
}
