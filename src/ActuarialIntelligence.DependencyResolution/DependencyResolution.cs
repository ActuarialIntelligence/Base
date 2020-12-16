using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Calculators.PDF;
using ActuarialIntelligence.Infrastructure.Connections;
using ActuarialIntelligence.Infrastructure.Interfaces.Readers_Interfaces;
using ActuarialIntelligence.Infrastructure.Readers;
using Cyotek.GhostScript.PdfConversion;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;

namespace ActuarialIntelligence.DependencyResolution
{
    public static class DependencyResolution
    {

        public static IDataReader<IList<string>> GetDMXMDXReader(int noOfClusters, int stateRange)
        {
            var con = new SSRSConnection("Provider=MSOLAP;integrated security=SSPI;Data Source = JYP1510\\MULTINODESSAS; Initial Catalog =StatAIDataMining");
            var reader = new ModelStatesSuggestionReader(con, noOfClusters, stateRange);
            return reader;
        }

        public static IFormat<Bitmap[]> pDFReformatter(string path, int startpage, string password)
        {
            var settings = new Pdf2ImageSettings();
            settings.AntiAliasMode = Cyotek.GhostScript.AntiAliasMode.High;
            settings.Dpi = 1200;
            settings.GridFitMode = Cyotek.GhostScript.GridFitMode.Mixed;
            settings.ImageFormat = Cyotek.GhostScript.ImageFormat.Jpeg;
            settings.PaperSize = Cyotek.GhostScript.PaperSize.A4;
            settings.TrimMode = Cyotek.GhostScript.PdfTrimMode.PaperSize;
            var formatter = new PDFReformatter(new Domain.PDF.PDFFormatterAndExtractor(settings, path, startpage, password));
            return formatter;
        }
    }
}
