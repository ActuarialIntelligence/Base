using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text;
using System.IO;
using Nito.AsyncEx;
using System.Windows.Documents;

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
            var ocrTypeEnglish = await UploadAndRecognizeImageAsync(@"C:\Users\rajiyer\Documents\TestData\Arabic Text\Ariha.png", OcrLanguages.En);
            var ocrTypeArabic = await UploadAndRecognizeImageAsync(@"C:\Users\rajiyer\Documents\TestData\Arabic Text\Ariha.png", OcrLanguages.Ar);
            string ocrbounds = "";
            foreach (var region in ocrTypeEnglish.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        // The separation character should be a configurable one
                         ocrbounds = word.Text=="ocr" || word.Text == "OCR"?word.BoundingBox : "";
                        if (!ocrbounds.Equals(""))
                        {
                            break;
                        }
                    }
                }
            }

            var allText = "";
            var ocrBounds = ocrbounds.Split(',');
            foreach (var region in ocrTypeArabic.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        // The separation character should be a configurable one
                        var bounds = word.BoundingBox.Split(',');
                        //Check to see if the words are within the region
                        //The region values are returned from the step that returns position of characters OCR on the document 
                        if((int.Parse(bounds[0]) > int.Parse(ocrBounds[0])) // + a preconfigured
                            && (int.Parse(bounds[1]) > int.Parse(ocrBounds[1])) // + b preconfigured
                            && (int.Parse(bounds[2]) < int.Parse(ocrBounds[2])) // + c preconfigured
                            && (int.Parse(bounds[3]) < int.Parse(ocrBounds[3]))) // + d preconfigured
                        {
                            allText += "," + word.Text;
                        }
                    }
                }
            }
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
