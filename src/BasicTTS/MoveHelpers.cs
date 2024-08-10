using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace BasicTTS
{
    public static class MoveHelpers
    {

        public static async Task GenerateFacialExpressionsBasedOnText(Form form, PictureBox pictureBoxApplicableMouth, PictureBox pictureBoxApplicableEyes,
            string inputTextPath)
        {

            string textfilePath = inputTextPath;
            

            double ScaleFactor = 0.3;
            var tmr = new System.Windows.Forms.Timer();
            var timer = new System.Windows.Forms.Timer();
            timer.Start();
            string text = File.ReadAllText(textfilePath);
            //BlinkeEyes(pictureBoxApplicableEyes);
            // Split the text into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var blinkAngry = true;
            // Iterate through each word
            foreach (string word in words)
            {
                Console.WriteLine(word + " ");
                // Iterate through each character in the word
                foreach (char c in word)
                {

                    MouthMove(pictureBoxApplicableMouth, c); 
                    EyesBlink(pictureBoxApplicableEyes, c);
                     RandomlyMoveAngryEyes(form,pictureBoxApplicableEyes, word, c);
                    //character = c;
                    
                }
                // Adjust the delay to simulate the speed of human speech for words
                Thread.Sleep(6); // Adjust this delay to simulate human speaking speed for words
            }

        }


        private static async Task MouthMove(PictureBox pictureBoxApplicableMouth, char c)
        {
            // Check if the character is a vowel
            var bitmap = FormMainHelpers.GetMouthImage(c);
            pictureBoxApplicableMouth.Image = bitmap;
            pictureBoxApplicableMouth.Refresh();
            // Adjust the delay to simulate the speed of human speech for characters
            Thread.Sleep(35);
        }


        private static async Task EyesBlink(PictureBox pictureBoxApplicable, char c)
        {

            if (c == 'o')
            {
                var bitmap = FormMainHelpers.GetBlinkImage('!');
                Thread.Sleep(2);
            }

        }


        private static async Task RandomlyMoveAngryEyes(Form form, PictureBox pictureBoxApplicable, string word, char c)
        {
            // Check if the character is a vowel

            var bitmap = FormMainHelpers.GetRandomAngryEyeMoveImage(c);
            pictureBoxApplicable.Image = bitmap;
            pictureBoxApplicable.Refresh();
            switch (word)
            {
                case "fuck":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyEff;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
                case "you":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyYou;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
                case "me":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyMe;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
                case "them":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case "there":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
                case "these":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
                case "wait":
                    form.BackgroundImage = Properties.Resources.CartmanDefaultBodyWait;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                    form.Refresh();
                    break;
            }
            Thread.Sleep(2);
        }

        public static async Task MoveWorriedEyesRandomly( Form form, PictureBox pictureBoxApplicable)
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

                switch(word)
                {
                    case "fuck":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyEff;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "you":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyYou;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "me":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyMe;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "them":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "there":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "these":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyThere;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "wait":
                        form.BackgroundImage = Properties.Resources.CartmanDefaultBodyWait;
                        form.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                }

                foreach (char c in word)
                {
                    // Check if the character is a vowel
                    var bitmap = FormMainHelpers.GetRandomWorriedEyeMoveImage(c);
                    pictureBoxApplicable.Image = bitmap;
                    pictureBoxApplicable.Refresh();

                    Task.Delay(1800);
                }
            }

        }

    }
}