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

namespace BasicTTS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }



        // Method to get the mouth image for a vowel
        static Bitmap GetMouthImage(char vowel)
        {
            switch (vowel)
            {
                case 'A':
                case 'a':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\A.png");
                case 'E':
                case 'e':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\E.png");
                case 'I':
                case 'i':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\I.png");
                case 'O':
                case 'o':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\O.png");
                case 'U':
                case 'u':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\U.png");
                case ' ':
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\L.png");
                default:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\L.png"); ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveMouth();
        }

        private void MoveMouth()
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            string outputVideoFilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\output.mp4";

            double ScaleFactor = 0.3;
            var tmr = new System.Windows.Forms.Timer();

            // Initialize video writer

            // Start recording images
            //ImageDisplay imageDisplay = new ImageDisplay(outputVideoFilePath);
            //VideoWriter writer = imageDisplay.writer; // Sharing the writer,

            //Thread imageDisplayThread = new Thread(imageDisplay.StartRecording);
            //imageDisplayThread.Start();

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
                    // WriteImagePerVowel(ScaleFactor, writer, c);
                    var bitmap = GetMouthImage(c);
                    this.pictureBox.Image = bitmap;
                    this.pictureBox.Refresh();
                    // Adjust the delay to simulate the speed of human speech for characters
                    Thread.Sleep(50);
                }
                // Adjust the delay to simulate the speed of human speech for words
                Thread.Sleep(300); // Adjust this delay to simulate human speaking speed for words
            }

            // Stop recording images
            //imageDisplay.StopRecording();
            //imageDisplayThread.Join();

            // Release the video writer
            // writer.Dispose();
        }
    }
}
