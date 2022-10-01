using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.LogViewer.WordsSearch.Managers;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public class WordsSearchUserSettingsFactory: UserSettingsFactory
    {
        public override string Title { get; set; } = "Windows Event Logs settings";
        public override UserControl DataProviderSettings { get; set; } = new WordsSearchSettings();

        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override Guid Id { get; set; } = new Guid("38de920b-0a7b-4152-a3b2-a67a07a74082");

        public override Task SaveSettingsAsync()
        {
            return Task.CompletedTask;
        }
    }
}
