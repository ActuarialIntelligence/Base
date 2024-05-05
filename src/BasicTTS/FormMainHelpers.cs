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
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesBlinkAngry.png");
                default:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpMouths\L.png"); ;
            }
        }

        public static Bitmap GetRandomAngryEyeMoveImage(char vowel)
        {
            var rnd = new Random();
            var cse = rnd.Next(0, 100);

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
                case 8: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 9: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 10: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 11: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 12: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 13: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 14: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 15: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 16: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 17: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 18: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 19: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 20: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 21: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 22: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 23: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 24: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 25: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 26: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 27: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 28: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 29: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 30: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 31: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 32: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 33: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 34: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 35: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 36: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 37: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 38: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 39: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 40: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 41: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 42: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 43: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 44: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 45: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 46: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 47: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 48: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 49: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 50: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 51: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 52: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 53: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 54: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 55: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 56: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 57: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 58: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 59: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 60: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 61: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 62: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 63: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 64: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 65: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 66: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 67: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 68: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 69: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 70: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 71: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 72: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 73: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 74: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 75: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 76: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 77: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 78: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 79: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 80: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 81: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 82: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 83: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 84: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 85: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 86: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");
                case 87: return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesAngryNormal.png");

                case 88:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesLeftAngry.png");


                case 94:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 95:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 96:
                    return new Bitmap(@"C:\Users\Rajah\Pictures\SpEyes\EyesUpAngry.png");
                case 97:
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