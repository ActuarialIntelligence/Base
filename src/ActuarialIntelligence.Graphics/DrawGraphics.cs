using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Mathematical_Technique_Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActuarialIntelligence.Graphics
{
    /// <summary>
    /// Draws lines between all points that exist in the model vector pair list, and renders a Bitmap
    /// This layer aims to separate the concern of drawing from the model and associated objects.
    /// </summary>
    public static class DrawGraphics // 
    {
        public static _3Matrix DrawBitmap(MouseEventArgs e, PictureBox graphicsDisplayBox, IList<Point<_3Vector, _3Vector>> pointsList, double pivotX, double pivotY)
        {

            decimal scaleX = 4 / (decimal)graphicsDisplayBox.Width;
            decimal rotationCounterX = scaleX * e.X;

            decimal scaleY = 4 / (decimal)graphicsDisplayBox.Height;
            decimal rotationCounterY = scaleY * e.Y;

            graphicsDisplayBox.Image = new Bitmap(graphicsDisplayBox.Width, graphicsDisplayBox.Height);
            var rotationResult = RotationMatrices.RotateByAngles((float)rotationCounterY, 0, (float)rotationCounterX);

            foreach (var pointPair in pointsList)
            {
                using (var g = System.Drawing.Graphics.FromImage(graphicsDisplayBox.Image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    _3Vector pointA, pointB;
                    Pen pen;
                    EffectColourScheme(rotationResult, pointPair, out pointA, out pointB, out pen);

                    g.DrawLine(pen, (float)((pointA.a) + pointA.b + pivotX)
                                , (float)((pointA.c) + pivotY)
                                , (float)((pointB.a) + pointB.b + pivotX)
                                , (float)((pointB.c) + pivotY));
                }
            }
            return rotationResult;
        }

        private static void EffectColourScheme(_3Matrix rotationResult, Domain.ContainerObjects.Point<_3Vector, _3Vector> pointPair, out _3Vector pointA, out _3Vector pointB, out Pen pen)
        {
            double blue = 0;
            double red = 0;
            pointA = rotationResult.MultiplyByVector(pointPair.Xval);
            pointB = rotationResult.MultiplyByVector(pointPair.Yval);
            var gradient = (pointPair.Yval.c - pointPair.Xval.c) / (pointPair.Yval.a - pointPair.Xval.a);
            if (Math.Abs(gradient) > 1)
            {
                if (Math.Abs(gradient) > 5000)
                {
                    gradient = 5000;
                }
                blue = 255 * (Math.Abs(gradient) / 5000);
            }

            if (Math.Abs(gradient) < 1)
            {
                if (gradient == 0)
                {
                    gradient = 0.001;
                }
                //19.60
                red = 255 * (1 - Math.Abs(gradient));
            }

            pen = new Pen(Color.FromArgb((int)Math.Round(red, 0), 100, (int)Math.Round(blue, 0)));
        }

        public static void AngleAxis(_3Matrix rotationResult, PictureBox AnglePictureBox,
            _3Vector AngleX,
            _3Vector AngleY,
            _3Vector AngleZ)
        {
            AnglePictureBox.Image = new Bitmap(AnglePictureBox.Width, AnglePictureBox.Height);
            using (var g = System.Drawing.Graphics.FromImage(AnglePictureBox.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var resX = rotationResult.MultiplyByVector(AngleX);
                var resY = rotationResult.MultiplyByVector(AngleY);
                var resZ = rotationResult.MultiplyByVector(AngleZ);

                for (int i = 1; i <= 19; i++)
                {
                    g.DrawLine(Pens.Gray, i * 10, 0, i * 10, 200);//x
                    g.DrawLine(Pens.Gray, 0, i * 10, 200, i * 10);//y
                }
                var penX = new Pen(Color.LightGreen, 2);
                var penY = new Pen(Color.Blue, 2);
                var penZ = new Pen(Color.Red, 2);
                g.DrawLine(penX, 100, 100, (float)resX.a + 100, (float)resX.c + 100);
                g.DrawLine(penY, 100, 100, (float)resY.a + 100, (float)resY.c + 100);
                g.DrawLine(penZ, 100, 100, (float)resZ.a + 100, (float)resZ.c + 100);

            }
        }
    }
}

