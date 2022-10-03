using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

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
        public UserSettingsManager()
        {
            Length = 5;
            AllLoadedWords = new List<AnalogyLogMessage>();
            CharsPositions = new List<CharPosition>();
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
    }
}
