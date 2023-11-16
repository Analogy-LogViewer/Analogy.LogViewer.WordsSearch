using Analogy.Interfaces;
using Analogy.LogViewer.WordsSearch.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.WordsSearch.Managers
{
    internal class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;

        public int Length { get; set; }
        public List<CharPosition> CharsPositions { get; set; }
        public List<AnalogyLogMessage> AllLoadedWords { get; set; }
        public string FilesLocation { get; set; }
        public UserSettingsManager()
        {
            Length = 5;
            FilesLocation = Environment.CurrentDirectory;
            AllLoadedWords = new List<AnalogyLogMessage>();
            CharsPositions = new List<CharPosition>();
            Load();
        }

        public void RemovePosition(CharPosition charPosition)
        {
            CharsPositions.Remove(charPosition);
        }

        public void AddOrReplacePosition(CharPosition charPosition)
        {
            foreach (CharPosition position in CharsPositions)
            {
                if (position.Position == charPosition.Position)
                {
                    position.Char = charPosition.Char;
                    return;
                }
            }
            CharsPositions.Add(charPosition);
        }

        private void Load()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            if (!string.IsNullOrEmpty(Settings.Default.FilesLocation) && Directory.Exists(Settings.Default.FilesLocation))
            {
                FilesLocation = Settings.Default.FilesLocation;
            }
            else
            {
                FilesLocation = Environment.CurrentDirectory;
            }
        }
        public void Save()
        {
            Settings.Default.UpgradeRequired = false;
            Settings.Default.FilesLocation = FilesLocation;
            Settings.Default.Save();
        }

        public void ClearAllPositions()
        {
            CharsPositions.Clear();
        }
    }
}