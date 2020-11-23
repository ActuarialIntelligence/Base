using ActuarialIntelligence.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PDFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var formatter = DependencyResolution.pDFReformatter(@"C:\Users\rajiyer\Documents\Articles\RiemannZeta.pdf", 1, "");
            var domain = formatter.FormatAndReturn();
            var help = "";
        }
    }
}
