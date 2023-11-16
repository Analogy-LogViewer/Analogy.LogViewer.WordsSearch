using Analogy.Interfaces;
using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public class WordsSearchDataProviderFactory : DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public override string Title { get; set; } = "Analogy Words Search";

        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider>
        {
            new WordSearchDataProvider(),
        };
    }
}