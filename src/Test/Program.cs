using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text;
using System.IO;
using Nito.AsyncEx;

namespace Test
{
    class Program
    {
        private const string Filename = @"C:\Users\rajiyer\Documents\Articles\Arabic";

        public static void Main(string[] args)
        {
            //var formatter = DependencyResolution.pDFReformatter(@"C:\Users\rajiyer\Documents\Beginners_Guide_To_Arabic.pdf", 40, "");
            //var domain = formatter.FormatAndReturn(1,39);
            //for (int i = 0; i < 39; i++)
            //{
            //    var i2 = new Bitmap(domain[i]);
            //    i2.Save(Filename + i + ".png", ImageFormat.Png);
            //}
           
            AsyncContext.Run(() => MainAsync(args));
        }



        static async void MainAsync(string[] args)
        {
            var ocrType = await UploadAndRecognizeImageAsync(@"C:\Users\rajiyer\Documents\TestData\Arabic Text\Ariha.png", OcrLanguages.Ar);
        }

        internal static async Task<OcrResult> UploadAndRecognizeImageAsync(string imageFilePath, OcrLanguages language)
        {
            string key = "";
            string endPoint = "https://tasmu-ocr-solution.cognitiveservices.azure.com/";
            var credentials = new ApiKeyServiceClientCredentials(key);

            using (var client = new ComputerVisionClient(credentials) { Endpoint = endPoint })
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    OcrResult ocrResult = await client.RecognizePrintedTextInStreamAsync(false, imageFileStream, language);
                    return ocrResult;
                }
            }
        }

        internal static async Task<string> FormatOcrResult(OcrResult ocrResult)
        {
            var sb = new StringBuilder();
            foreach (OcrRegion region in ocrResult.Regions)
            {
                foreach (OcrLine line in region.Lines)
                {
                    foreach (OcrWord word in line.Words)
                    {
                        sb.Append(word.Text);
                        sb.Append(" ");
                    }
                    sb.Append("\r\n");
                }
                sb.Append("\r\n\r\n");
            }
            return sb.ToString();
        }
    }
}
