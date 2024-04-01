using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace AI.TTS.Visual
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            string textfilePath = "path/to/your/text/file.txt";
            string outputVideoFilePath = "";

            double ScaleFactor = 0.3;

            // Initialize video writer
            VideoWriter writer = new VideoWriter("output.mp4", VideoWriter.Fourcc('X', 'V', 'I', 'D'), 10, new Size(800, 600), true);

            // Start recording images
            ImageDisplay imageDisplay = new ImageDisplay(outputVideoFilePath);
            Thread imageDisplayThread = new Thread(imageDisplay.StartRecording);
            imageDisplayThread.Start();

            // Read the text from the file
            string text = File.ReadAllText(textfilePath);

            // Split the text into words
            string[] words = text.Split(new char[] { ' ', ' ', ' ', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    // Check if the character is a vowel
                    WriteImagePerVowel(ScaleFactor, writer, c);

                    // Adjust the delay to simulate the speed of human speech for characters
                    Thread.Sleep(100);
                }
                // Adjust the delay to simulate the speed of human speech for words
                Thread.Sleep(1000); // Adjust this delay to simulate human speaking speed for words
            }

            // Stop recording images
            imageDisplay.StopRecording();
            imageDisplayThread.Join();

            // Release the video writer
            writer.Dispose();
        }

        private static void WriteImagePerVowel(double ScaleFactor, VideoWriter writer, char c)
        {
            if ("AEIOUaeiou".Contains(c))
            {
                // Get the corresponding mouth image for the vowel
                Bitmap mouthImage = GetMouthImage(c);

                // Scale the mouth image
                Bitmap scaledMouthImage = new Bitmap((int)(mouthImage.Width * ScaleFactor), (int)(mouthImage.Height * ScaleFactor));
                using (Graphics g = Graphics.FromImage(scaledMouthImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(mouthImage, 0, 0, scaledMouthImage.Width, scaledMouthImage.Height);
                }

                // Convert the Bitmap to Image<Bgr, byte>
                Image<Bgr, byte> emguImage = ImageDisplay.EmguImageFromBitmap(scaledMouthImage);

                // Add the frame to the video writer
                writer.Write(emguImage.Mat);
            }
        }

        // Method to get the mouth image for a vowel
        static Bitmap GetMouthImage(char vowel)
        {
            switch (vowel)
            {
                case 'A':
                case 'a':
                    return new Bitmap("mouth_a.bmp");
                case 'E':
                case 'e':
                    return new Bitmap("mouth_e.bmp");
                case 'I':
                case 'i':
                    return new Bitmap("mouth_i.bmp");
                case 'O':
                case 'o':
                    return new Bitmap("mouth_o.bmp");
                case 'U':
                case 'u':
                    return new Bitmap("mouth_u.bmp");
                case ' ':
                    return new Bitmap("partialOpenMouth.bmp");
                default:
                    return null;
            }
        }
    }
}
