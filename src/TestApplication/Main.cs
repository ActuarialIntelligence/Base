using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.MathContainers;
using ActuarialIntelligence.Domain.Model_Containers;
using ActuarialIntelligence.Domain.Model_Containers.ModelInterfaces;
using ActuarialIntelligence.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Main : Form
    {
        private MouseEventArgs mouseEventArgs = new MouseEventArgs(MouseButtons.None, 0, 1, 1, 1);
        private IModel model;
        private double a = 1, b = 1, c = 1;
        double width, height;
        SimpleFunctionContainer container;
        SimpleFunctionContainer container2;
        IList<Point<_3Vector, _3Vector>> vectorPointsList;
        double pivotX = 400, pivotY = 350;
        _3Vector AngleX, AngleY, AngleZ, AngleZero;
        double freezeX, freezeY;
        bool freezeFrame = false;
        private void Main_Resize(object sender, EventArgs e)
        {
            //1419, 1075

        }

        private void Main_Load(object sender, EventArgs e)
        {



            this.DisplayBox.Image = new Bitmap(DisplayBox.Width, DisplayBox.Height);
            InitializeAngleGrid();
            pivotX = DisplayBox.Width / 2;
            pivotY = DisplayBox.Height / 2;
        }

        private void DisplayBox_Click(object sender, EventArgs e)
        {
            if (freezeFrame)
            {
                freezeFrame = false;
            }
            else
            {
                freezeFrame = true;
            }
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {

        }

        private void DisplayBox_Resize(object sender, EventArgs e)
        {
            //pivotX = 1419 / 2;
            //pivotY = 1075 / 2;
        }

        private void DisplayBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!freezeFrame)
            {
                mouseEventArgs = e;
                RenderGraphics(e);
            }

                foreach (var pair in DrawGraphics.actualPoints)
                {
                    if ((Math.Round(pair.transformed.Xval, 0) == e.X) && (Math.Round(pair.transformed.Yval, 0) == e.Y))
                    {

                        textBox1.Text = e.X.ToString() + "||" + e.Y.ToString() + "||" + pair.actual.Xval.a + "||" + pair.actual.Xval.b + "||" + pair.actual.Xval.c;
                    }
                }
            

        }
        /// <summary>
        /// Calls VecpointList and passes values only
        /// </summary>
        /// <param name="e"></param>
        private void RenderGraphics(MouseEventArgs e)
        {
            if (!freezeFrame)
            {
                //pivotX = 400;
                //pivotY = 350;
                //textBox1.Text = pivotX.ToString() + ";" + pivotY.ToString() + ":" +
                //    DisplayBox.Width.ToString() + ";" + DisplayBox.Height.ToString() + ":" +
                //    e.X.ToString() + ":" + e.Y.ToString();
                var result = DrawGraphics.RotateAndDrawBitmap(e, this.DisplayBox, vectorPointsList, pivotX, pivotY);
                DrawGrids();
                DrawAngleAxis(result);
                DisplayBox.Refresh();
            }
        }

        private void DisplayBox_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void DisplayBox_MouseClick(object sender, MouseEventArgs e)
        {

            freezeX = e.X;
            freezeY = e.Y;
            pivotX = freezeX;
            pivotY = freezeY;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Timer
            // Create a new timer
            Timer myTimer = new Timer();

            // Set the interval (in milliseconds) for the timer to tick
            myTimer.Interval = 80; // 1000 milliseconds = 1 second

            // Subscribe to the Tick event with a method
            myTimer.Tick += MyTimer_Tick;

            // Start the timer
            myTimer.Start();

            #endregion
        }

        private void DisplayBox_MouseDown(object sender, MouseEventArgs e)
        {


        }

        public Main()
        {
            InitializeComponent();
            AnglePictureBox.BackColor = Color.Transparent;
            //container = new SimpleFunctionContainer((u, v) => (-v * (2* u -1)) / (Math.Pow((u - 1), 2) + Math.Pow(v, 2)) * 80, 8, 8, 20);
            //container2 = new SimpleFunctionContainer((u, v) => (u*(1-u) - Math.Pow(v,2))/(Math.Pow((u - 1),2) + Math.Pow(v, 2)) * 200  + 200, 8, 8, 20);
            InitializeModelPointsWithFunctionParameters();
        }
        /// <summary>
        /// Adds values to vecpointlist
        ///         /// For animaions one can vary a,b,c with each call 
        /// I would say introduce a timer tick event and call this, where each tick 
        /// changes values of a,b,c 
        /// </summary>
        private void InitializeModelPointsWithFunctionParameters()
        {
            container2 = new SimpleFunctionContainer((u, v) => a * Math.Pow(Math.Sqrt(Math.Pow(u, 2) + Math.Pow(v, 2)), 3) * Math.Sin(3 * Math.Acos(u / (Math.Sqrt(Math.Pow(u, 2) + Math.Pow(v, 2))))) / 69000, 8, 8, 20);
            container = new SimpleFunctionContainer((u, v) => a * Math.Pow(Math.Sqrt(Math.Pow(u, 2) + Math.Pow(v, 2)), 3) * Math.Cos(3 * Math.Acos(u / (Math.Sqrt(Math.Pow(u, 2) + Math.Pow(v, 2))))) / 69000, 8, 8, 20);

            #region Test
            //var TdTrig = new List<Point<_3Vector, _3Vector>>();
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(0, 0, 0), new _3Vector(0, 0, 200)));
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(0, 0, 0), new _3Vector(0, 200, 0)));
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(0, 0, 0), new _3Vector(160 * Math.Cos(160), 160 * Math.Sin(160), 0)));
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(160 * Math.Cos(160), 160 * Math.Sin(160), 0), new _3Vector(0, 0, 200)));
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(160 * Math.Cos(160), 160 * Math.Sin(160), 0), new _3Vector(0, 200, 0)));
            //TdTrig.Add(new Point<_3Vector, _3Vector>(new _3Vector(0, 200, 0), new _3Vector(0, 0, 200)));
            #endregion


            vectorPointsList = container.VectorPointsList;
            foreach (var point in container2.VectorPointsList)
            {
                vectorPointsList.Add(point);
            }
            model = new ModelContainer(container);
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            a += 0.1;
            InitializeModelPointsWithFunctionParameters();
            var result = DrawGraphics.RotateAndDrawBitmap(mouseEventArgs, this.DisplayBox, vectorPointsList, pivotX, pivotY);
            DrawGrids();
            DrawAngleAxis(result);
            DisplayBox.Refresh();
        }


        /// <summary>
        /// Call/use this function, when you want the vector points to change.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="t"></param>
        public void CallToChange(double x, double y, double z, double t)
        {
            //Dont forget to set the following outside of this function. 
            //VariableFunctionContainer.FunctionCoEfficientList = new List<Func<double, double, double, double, double>>()

            container = new SimpleFunctionContainer((u, v) => VariableFunctionContainer.GetCurrentValue(1, x, y, z, t) * (u) + VariableFunctionContainer.GetCurrentValue(2, x, y, z, t) * (Math.Pow(u, 2)), 8, 8, 20);
            //container = new SimpleFunctionContainer((u, v) => (u*(1-u) - Math.Pow(v,2))/(Math.Pow((u - 1),2) + Math.Pow(v, 2)) * 200  + 200, 8, 8, 20);
            //container = new SimpleFunctionContainer((u, v) => (Math.Pow(Math.Cos(u), 5) * v - Math.Pow(v, 5) * u) / 3900000, 8, 8, 20);
            vectorPointsList = container.VectorPointsList;
        }


        private void DrawGrids()
        {
            using (var g = System.Drawing.Graphics.FromImage(DisplayBox.Image))
            {
                g.DrawLine(Pens.Gray, (float)pivotX, (float)pivotY, DisplayBox.Width, (float)pivotY);
                g.DrawLine(Pens.Gray, (float)pivotX, 0, (float)pivotX, DisplayBox.Height);
                DisplayBox.Refresh();
            }
        }

        private void InitializeAngleGrid()
        {
            AngleZero = new _3Vector(0, 0, 0);
            AngleY = new _3Vector(0, 70, 0);
            AngleZ = new _3Vector(0, 0, 70);
            AngleX = new _3Vector(70, 0, 0);
        }

        private void DrawAngleAxis(_3Matrix rotationResult)
        {
            DrawGraphics.AngleAxis(rotationResult, AnglePictureBox, AngleX, AngleY, AngleZ);
            AnglePictureBox.Refresh();
        }
    }
}
