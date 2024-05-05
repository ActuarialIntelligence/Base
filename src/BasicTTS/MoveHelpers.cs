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
        private static char character = ' ';
        private static PictureBox _pictureBoxApplicableMouth;
        private static PictureBox _pictureBoxApplicableEyes;
        public static async Task GenerateFacialExpressionsBasedOnText( PictureBox pictureBoxApplicableMouth, PictureBox pictureBoxApplicableEyes)
        {
            //_pictureBoxApplicableMouth = pictureBoxApplicableMouth;
            //_pictureBoxApplicableEyes = pictureBoxApplicableEyes; 
            ////var timer1 = new System.Timers.Timer(2000); // Timer 1 ticks every 2 seconds
            //var timerMoveEyes = new System.Timers.Timer(3000); // Timer 2 ticks every 3 seconds
            //var timerBlink =  new System.Timers.Timer(5000);

            ////timer1.Elapsed += (sender, e) => TimerElapsed(e.SignalTime, "Timer 1");
            //timerMoveEyes.Elapsed += (sender, e) => TimerElapsed(e.SignalTime, "timerMoveEyes");
            //timerBlink.Elapsed += (sender, e) => TimerElapsed(e.SignalTime, "timerBlink");


            //// Start the timers
           
            //timerMoveEyes.Start();
            //timerBlink.Start();

            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            string outputVideoFilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\output.mp4";

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
                // Iterate through each character in the word
                foreach (char c in word)
                {

                    MouthMove(pictureBoxApplicableMouth, c); 
                    EyesBlink(pictureBoxApplicableEyes, c);
                     RandomlyMoveAngryEyes(pictureBoxApplicableEyes, c);
                    //character = c;

                }
                // Adjust the delay to simulate the speed of human speech for words
                Thread.Sleep(2); // Adjust this delay to simulate human speaking speed for words
            }
            //timerMoveEyes.Stop();
            //timerBlink.Stop();
        }

        //static void TimerElapsed(DateTime signalTime, string timerName)
        //{
        //    switch (timerName)
        //    {
        //        case "timerMoveEyes":
        //            RandomlyMoveAngryEyes(_pictureBoxApplicableEyes, character);
        //            break;
        //        case "timerBlink":
        //            EyesBlink(_pictureBoxApplicableEyes, character);
        //            break;
        //    }
        //}

        private static async Task MouthMove(PictureBox pictureBoxApplicableMouth, char c)
        {
            // Check if the character is a vowel
            var bitmap = FormMainHelpers.GetMouthImage(c);
            pictureBoxApplicableMouth.Image = bitmap;
            pictureBoxApplicableMouth.Refresh();
            // Adjust the delay to simulate the speed of human speech for characters
            Thread.Sleep(1);
        }


        private static async Task EyesBlink(PictureBox pictureBoxApplicable, char c)
        {

            if (c == 'o')
            {
                var bitmap = FormMainHelpers.GetBlinkImage('!');
                Thread.Sleep(2);
            }

        }


        private static async Task RandomlyMoveAngryEyes(PictureBox pictureBoxApplicable, char c)
        {
            // Check if the character is a vowel

            var bitmap = FormMainHelpers.GetRandomAngryEyeMoveImage(c);
            pictureBoxApplicable.Image = bitmap;
            pictureBoxApplicable.Refresh();

            Thread.Sleep(50);
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

                    Task.Delay(1800);
                }
            }

        }
    }
}