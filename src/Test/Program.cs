using ActuarialIntelligence.DependencyResolution;
using System.Drawing;
using System.Drawing.Imaging;

namespace Test
{
    class Program
    {
        private const string Filename = @"C:\Users\rajiyer\Documents\Articles\Arabic";

        static void Main(string[] args)
        {
            var formatter = DependencyResolution.pDFReformatter(@"C:\Users\rajiyer\Documents\Beginners_Guide_To_Arabic.pdf", 21, "");
            var domain = formatter.FormatAndReturn(1,12);
            for (int i = 0; i < 12; i++)
            {
                var i2 = new Bitmap(domain[i]);
                i2.Save(Filename + i + ".png", ImageFormat.Png);
            }
        }
    }
}
