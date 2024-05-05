using System;
using System.Drawing;

namespace BasicTTS
{
    public static class FormMainHelpers
    {

        private static bool GetAngerNormalIndicator(char mark)
        {
            switch(mark)
            {
                case '!':
                    return true;
                case '.':
                    return false;
                default:
                    return false;
            }
        }

        // Method to get the mouth image for a vowel
        public static Bitmap GetMouthImage(char vowel)
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

        public static Bitmap GetBlinkImage(char vowel)
        {
            var mark = GetAngerNormalIndicator(vowel)== true?"angry":"normal";

            switch (mark)
            {
                case "normal":
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesBlinkWorried.png");
                case "angry":
                    return new Bitmap(@"C: \Users\Rajah\Pictures\SpEyes\EyesBlinkAngry.png");
                default:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\L.png"); ;
            }
        }

        public static Bitmap GetRandomAngryEyeMoveImage(char vowel)
        {
            var rnd = new Random();
            var cse = rnd.Next(0, 19);

            switch (cse)
            {
                case 0:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 1:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 2:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 3:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 4:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 5:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 6:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 7:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 8:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesLeftAngry.png");
                case 9:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesLeftAngry.png");
                case 10:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesLeftAngry.png");
                case 11:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                case 12:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                case 13:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                case 14:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 15:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 16:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 17:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                case 18:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                case 19:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesRightAngry.png");
                default:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
            }

        }

        public static Bitmap GetRandomWorriedEyeMoveImage(char vowel)
        {
            var rnd = new Random();
            var cse = rnd.Next(0, 19);

            switch (cse)
            {
                case 0:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 1:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 2:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 3:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 4:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 5:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 6:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 7:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 8:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedLeft.png");
                case 9:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedLeft.png");
                case 10:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedLeft.png");
                case 11:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedRight.png");
                case 12:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedRight.png");
                case 13:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedRight.png");
                case 14:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedDown.png");
                case 15:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedDown.png");
                case 16:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedDown.png");
                case 17:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedUp.png");
                case 18:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedUp.png");
                case 19:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesWorriedUp.png");
                default:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
            }

        }
    }
}