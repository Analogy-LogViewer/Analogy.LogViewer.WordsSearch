using Analogy.Interfaces;
using Analogy.LogViewer.Template;
using Analogy.LogViewer.WordsSearch.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public class WordsSearchUserSettingsFactory : TemplateUserSettingsFactory
    {
        public override string Title { get; set; } = "Words Search settings";
        public override UserControl DataProviderSettings { get; set; }

        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override Guid Id { get; set; } = new Guid("38de920b-0a7b-4152-a3b2-a67a07a74082");

        public override void CreateUserControl(ILogger logger)
        {
            DataProviderSettings = new WordsSearchSettings();
        }

        public override Task SaveSettingsAsync()
        {
            return Task.CompletedTask;
        }
    }
}