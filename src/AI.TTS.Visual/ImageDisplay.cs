using System;
using System.IO;
using System.Threading;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AI.TTS.Visual
{
    public class ImageDisplay
    {
        public VideoWriter writer;
        private string outputFilePath;

        public ImageDisplay(string outputFilePath)
        {
            this.outputFilePath = outputFilePath;
            writer = new VideoWriter(outputFilePath, VideoWriter.Fourcc('X', 'V', 'I', 'D'), 10, new Size(800, 600), true);
        }

        public void StartRecording()
        {
            

            // Start threads for displaying images at specified intervals
            Thread displayThread1 = new Thread(BlinkImage);
            Thread displayThread2 = new Thread(EyeballMovementImage);
            Thread displayThread3 = new Thread(ExcitedEyes);
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

        private void BlinkImage()
        {
            // Display the image every 2 seconds
            while (true)
            {
                Bitmap image = new Bitmap("image1.bmp");
                AddFrameToVideo(image);
                Thread.Sleep(2000);
            }
        }

        private void EyeballMovementImage()
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

        private void ExcitedEyes()
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

            Image<Bgr, byte> emguImage = EmguImageFromBitmap(image);

            // Add the frame to the video writer
            writer.Write(emguImage);

        }

        public static Image<Bgr, byte> EmguImageFromBitmap(Bitmap image)
        {
            // Convert Bitmap to byte array
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(stride) * image.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            image.UnlockBits(bmpData);

            // Create Emgu.CV image from byte array
            Image<Bgr, byte> emguImage = new Image<Bgr, byte>(image.Width, image.Height);
            int k = 0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    emguImage[i, j] = new Bgr(rgbValues[k + 2], rgbValues[k + 1], rgbValues[k]);
                    k += 3;
                }
            }

            return emguImage;
        }
    }
}
