using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.Interfaces;
using Analogy.LogViewer.WordsSearch.Properties;

namespace Analogy.LogViewer.WordsSearch.IAnalogy
{
    public class PrimaryFactory : Analogy.LogViewer.Template.PrimaryFactory
    {
        internal static readonly Guid Id = new Guid("34557671-1d6a-4bc3-b2ba-314df574b3aa");
        public override Guid FactoryId { get; set; } = Id;

        public override string Title { get; set; } = "Analogy Words Search";
        public override Image? SmallImage { get; set; } = Resources.Analogy_image_16x16;
        public override Image? LargeImage { get; set; } = Resources.Analogy_image_32x32;

        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Initial Version",AnalogChangeLogType.None, "Lior Banai",new DateTime(2022, 10, 01)),
  };
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Analogy Words Search";
    }
}
