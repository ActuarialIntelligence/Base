using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text;
using System.IO;
using Nito.AsyncEx;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        private const string Filename = @"C:\Users\rajiyer\Documents\Articles\Arabic";
        

        /// <summary>
        /// The following is for Demonstration purposes only
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //objServer.Disconnect();
            //var formatter = DependencyResolution.pDFReformatter(@"C:\Users\rajiyer\Documents\Beginners_Guide_To_Arabic.pdf", 40, "");
            //var domain = formatter.FormatAndReturn(1,39);
            //for (int i = 0; i < 39; i++)
            //{
            //    var i2 = new Bitmap(domain[i]);
            //    i2.Save(Filename + i + ".png", ImageFormat.Png);
            //}

            //AsyncContext.Run(() => MainAsync(args));
            RandomDataGenerator();

        }

        private static void RandomDataGenerator()
        {
            var displayNoOfLines = 10;
            IFormatter formatter = new BinaryFormatter();
            var rnd = new Random();
            var RandomLList = new List<string>();
            Console.WriteLine("Starting: " + DateTime.Now.ToString());
            var cntr = 0;
            var allTxt = "";
            for (int i = 0; i < 2000000; i++)
            {
                // var tmp = rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString();
                RandomLList.Add(rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString() + "|" + rnd.NextDouble().ToString());

                cntr++;
            }

            Console.WriteLine("RandomGen Process Ended: " + DateTime.Now.ToString());

            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, RandomLList);
                var Mbs = ((double)stream.Length) / (1024 * 1024);
                Console.WriteLine("Size in MB: " + Mbs.ToString());
            }


            for (int i = 0; i < displayNoOfLines; i++)
            {
                Console.WriteLine(RandomLList[i]);
            }
            Console.WriteLine("No Of Lines: " + cntr.ToString());
            Console.WriteLine("Writing to file...c:\\TestData\\rnd.txt");
            var sw = new StreamWriter("c:\\TestData\\rnd.txt");
            cntr = 0;
            foreach (var row in RandomLList)
            {
                sw.WriteLine(row);
                cntr++;
            }



            sw.Close();
            Console.WriteLine("DONE : Writing to file. ENTER to EXIT");
            Console.ReadLine();
        }

        static async void MainAsync(string[] args)
        {
            #region Load Data
            var ocrTypeEnglish = await UploadAndRecognizeImageAsync(@"C:\Users\rajiyer\Documents\TestData\Arabic Text\Ariha.png", OcrLanguages.En);
            var ocrTypeArabic = await UploadAndRecognizeImageAsync(@"C:\Users\rajiyer\Documents\TestData\Arabic Text\Ariha.png", OcrLanguages.Ar);
            string ocrbounds = "";
            #endregion
            foreach (var region in ocrTypeEnglish.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        // The separation character should be a configurable one
                         ocrbounds = word.Text=="HS Code" || word.Text == "HS CODE"?word.BoundingBox : "";
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
                        if(word.Text == "الإطلاق؛") // Example Word
                        {
                            // If word is ~ 'HS Code' 
                            // Applies to all words within the Document that has been OCR'd
                            System.Console.WriteLine(word.Text);
                        }
                        //Check to see if the words are within the region
                        //The region values are returned from the step that returns position of characters OCR on the document 
                        //if((int.Parse(bounds[0]) > int.Parse(ocrBounds[0])) // + a preconfigured
                        //    && (int.Parse(bounds[1]) > int.Parse(ocrBounds[1])) // + b preconfigured
                        //    && (int.Parse(bounds[2]) < int.Parse(ocrBounds[2])) // + c preconfigured
                        //    && (int.Parse(bounds[3]) < int.Parse(ocrBounds[3]))) // + d preconfigured
                        //{
                        //    allText += "," + word.Text;
                        //}

                    }
                }
            }
        }

        internal static async Task<OcrResult> UploadAndRecognizeImageAsync(string imageFilePath, OcrLanguages language)
        {
            string key = "Key";
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
