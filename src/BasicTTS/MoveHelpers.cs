using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicTTS
{
    public static class MoveHelpers
    {

        public static async Task MoveMouth( PictureBox pictureBoxApplicableMouth, PictureBox pictureBoxApplicableEyes)
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            string outputVideoFilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\output.mp4";

            double ScaleFactor = 0.3;
            var tmr = new System.Windows.Forms.Timer();

            string text = File.ReadAllText(textfilePath);
            //BlinkeEyes(pictureBoxApplicableEyes);
            // Split the text into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var blinkAngry = true;
            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    MouthMove(pictureBoxApplicableMouth, c);
                    EyesBlink(pictureBoxApplicableEyes, c);
                    RandomlyMoveAngryEyes(pictureBoxApplicableEyes, c);
                }
                // Adjust the delay to simulate the speed of human speech for words
                Task.Delay(100); // Adjust this delay to simulate human speaking speed for words
            }

        }

        private static async Task MouthMove(PictureBox pictureBoxApplicableMouth, char c)
        {
            // Check if the character is a vowel
            var bitmap = FormMainHelpers.GetMouthImage(c);
            pictureBoxApplicableMouth.Image = bitmap;
            pictureBoxApplicableMouth.Refresh();
            // Adjust the delay to simulate the speed of human speech for characters
            Task.Delay(20);
        }

        public static async Task BlinkEyes(PictureBox pictureBoxApplicable)
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            string outputVideoFilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\output.mp4";

            double ScaleFactor = 0.3;
            var tmr = new System.Windows.Forms.Timer();

            string text = File.ReadAllText(textfilePath);

            // Split the text into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    EyesBlink(pictureBoxApplicable, c);
                    // Adjust the delay to simulate the speed of human speech for characters

                }
            }

        }

        private static async Task EyesBlink(PictureBox pictureBoxApplicable, char c)
        {
            bool blinkAngry = true;
            if ((c == '!' && c != '.') || (c != '!')) blinkAngry = true;
            if (c == '.') blinkAngry = false;
            if (blinkAngry)
            {
                // Check if the character is a vowel
                var bitmap = FormMainHelpers.GetBlinkImage('!');
                pictureBoxApplicable.Image = bitmap;
                pictureBoxApplicable.Refresh();
                Task.Delay(1500);
            }
            else
            {
                var bitmap = FormMainHelpers.GetBlinkImage('.');
                pictureBoxApplicable.Image = bitmap;
                pictureBoxApplicable.Refresh();
                Task.Delay(1500);
            }
        }

        public static async Task MoveAngryEyesRandomly( PictureBox pictureBoxApplicable)
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            var tmr = new System.Windows.Forms.Timer();

            string text = File.ReadAllText(textfilePath);

            // Split the text into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    RandomlyMoveAngryEyes(pictureBoxApplicable, c);
                }
            }

        }

        private static async Task RandomlyMoveAngryEyes(PictureBox pictureBoxApplicable, char c)
        {
            // Check if the character is a vowel
            var bitmap = FormMainHelpers.GetRandomAngryEyeMoveImage(c);
            pictureBoxApplicable.Image = bitmap;
            pictureBoxApplicable.Refresh();

            Task.Delay(300);
        }

        public static async Task MoveWorriedEyesRandomly( PictureBox pictureBoxApplicable)
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            var tmr = new System.Windows.Forms.Timer();

            string text = File.ReadAllText(textfilePath);

            // Split the text into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate through each word
            foreach (string word in words)
            {
                // Iterate through each character in the word
                foreach (char c in word)
                {
                    // Check if the character is a vowel
                    var bitmap = FormMainHelpers.GetRandomWorriedEyeMoveImage(c);
                    pictureBoxApplicable.Image = bitmap;
                    pictureBoxApplicable.Refresh();

                    Task.Delay(300);
                }
            }

        }
    }
}