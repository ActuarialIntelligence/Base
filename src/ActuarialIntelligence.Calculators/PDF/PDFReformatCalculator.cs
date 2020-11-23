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

        public Bitmap[] FormatAndReturn()
        {
            var result = pDFFormatterAndExtractor.GetImages(1,1);
            //throw new System.NotImplementedException();
            return result;
        }
    }
}
