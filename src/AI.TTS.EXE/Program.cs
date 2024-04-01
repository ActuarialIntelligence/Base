using System;
using System.IO;
using System.Threading;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;


namespace TextToSpeechWithMouthImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the text file
            string filePath = "path/to/your/text/file.txt";

            // Initialize video writer
            VideoWriter writer = new VideoWriter("output.mp4", VideoWriter.Fourcc('X', 'V', 'I', 'D'), 10, new Size(800, 600), true);

            // Load mouth images for vowels
            Bitmap mouthA = new Bitmap("mouth_a.bmp");
            Bitmap mouthE = new Bitmap("mouth_e.bmp");
            Bitmap mouthI = new Bitmap("mouth_i.bmp");
            Bitmap mouthO = new Bitmap("mouth_o.bmp");
            Bitmap mouthU = new Bitmap("mouth_u.bmp");
            Bitmap mouth6 = new Bitmap("mouth_6.bmp"); // New mouth image between words

            // Start recording images
            ImageDisplay imageDisplay = new ImageDisplay(writer);
            Thread imageDisplayThread = new Thread(imageDisplay.StartRecording);
            imageDisplayThread.Start();

            // Read the text from the file
            string text = File.ReadAllText(filePath);

            // Split the text into words
            string[] words = text.Split(new char[] { ' ', ' ', ' ', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    // Check if the character is a vowel
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
                        Image<Bgr, byte> emguImage = new Image<Bgr, byte>(scaledMouthImage);

                        // Add the frame to the video writer
                        writer.WriteFrame(emguImage.Mat);
                    }

                    // Adjust the delay to simulate the speed of human speech for characters
                    Thread.Sleep(100);
                }

                // Display mouth image 6 between words
                Bitmap scaledMouth6 = new Bitmap((int)(mouth6.Width * ScaleFactor), (int)(mouth6.Height * ScaleFactor));
                using (Graphics g = Graphics.FromImage(scaledMouth6))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(mouth6, 0, 0, scaledMouth6.Width, scaledMouth6.Height);
                }
                Image<Bgr, byte> emguImage6 = new Image<Bgr, byte>(scaledMouth6);
                writer.WriteFrame(emguImage6.Mat);

                // Adjust the delay to simulate the speed of human speech for words
                Thread.Sleep(1000); // Adjust this delay to simulate human speaking speed for words
            }

            // Stop recording images
            imageDisplay.StopRecording();
            imageDisplayThread.Join();

            // Release the video writer
            writer.Dispose();
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
                default:
                    return null;
            }
        }
    }


    public class ImageDisplay
    {
        private VideoWriter writer;
        private string outputFilePath;

        public ImageDisplay(string outputFilePath)
        {
            this.outputFilePath = outputFilePath;
        }

        public void StartRecording()
        {
            writer = new VideoWriter(outputFilePath, VideoWriter.Fourcc('X', 'V', 'I', 'D'), 10, new Size(800, 600), true);

            // Start threads for displaying images at specified intervals
            Thread displayThread1 = new Thread(DisplayImage1);
            Thread displayThread2 = new Thread(DisplayImage2);
            Thread displayThread3 = new Thread(DisplayImage3);
            Thread displayThread4 = new Thread(DisplayImage4);

            displayThread1.Start();
            displayThread2.Start();
            displayThread3.Start();
            displayThread4.Start();
        }

        public void StopRecording()
        {
            // Release the video writer
            writer.Dispose();
        }

        private void DisplayImage1()
        {
            // Display the image every 2 seconds
            while (true)
            {
                Bitmap image = new Bitmap("image1.bmp");
                AddFrameToVideo(image);
                Thread.Sleep(2000);
            }
        }

        private void DisplayImage2()
        {
            // Display random images every 5 seconds
            Random random = new Random();
            string[] imageFiles = { "image2.bmp", "image3.bmp", "image4.bmp", "image5.bmp", "image6.bmp" };

            while (true)
            {
                string randomImageFile = imageFiles[random.Next(imageFiles.Length)];
                Bitmap image = new Bitmap(randomImageFile);
                AddFrameToVideo(image);
                Thread.Sleep(5000);
            }
        }

        private void DisplayImage3()
        {
            // Display an image whenever '!' appears in the text for 5 seconds
            while (true)
            {
                if (CheckTextForCharacter('!'))
                {
                    Bitmap image = new Bitmap("image3.bmp");
                    AddFrameToVideo(image);
                    Thread.Sleep(5000);
                }
                else
                {
                    Thread.Sleep(1000); // Check every second
                }
            }
        }

        private void DisplayImage4()
        {
            // Custom logic for displaying images
            // Add your own requirements here
        }

        private bool CheckTextForCharacter(char character)
        {
            // Custom logic to check if the given character appears in the text
            // Add your own requirements here
            return true; // For demonstration purposes, always return true
        }

        private void AddFrameToVideo(Bitmap image)
        {
            // Convert the Bitmap to Image<Bgr, byte>
            Image<Bgr, byte> emguImage = new Image<Bgr, byte>(image);

            // Add the frame to the video writer
            writer.WriteFrame(emguImage.Mat);
        }
    }
}