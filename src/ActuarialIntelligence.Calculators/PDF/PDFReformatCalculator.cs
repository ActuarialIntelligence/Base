using ActuarialIntelligence.Calculators.Interfaces;
using ActuarialIntelligence.Domain.PDF;
using System.Drawing;

namespace ActuarialIntelligence.Calculators.PDF
{

    public class PDFReformatter : IFormat<Bitmap[]>
    {
        private PDFFormatterAndExtractor pDFFormatterAndExtractor;
        public PDFReformatter(PDFFormatterAndExtractor pDFFormatterAndExtractor)
        {
            this.pDFFormatterAndExtractor = pDFFormatterAndExtractor;
        }

        public Bitmap[] FormatAndReturn(int startpage, int endpage)
        {
            var result = pDFFormatterAndExtractor.GetImages(startpage, endpage);
            return result;
        }
    }
}
