using ActuarialIntelligence.DependencyResolution;
using System.Drawing;
using System.Drawing.Imaging;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var formatter = DependencyResolution.pDFReformatter(@"C:\Users\rajiyer\Documents\Articles\RiemannZeta.pdf", 1, "");
            var domain = formatter.FormatAndReturn();
            var i2 = new Bitmap(domain[0]);
            i2.Save(@"C:\Users\rajiyer\Documents\Articles\Riemann.png", ImageFormat.Png);
        }
    }
}
