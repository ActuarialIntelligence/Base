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
        private IModel model;
        double width, height;
        SimpleFunctionContainer container;
        IList<Point<_3Vector, _3Vector>> vectorPointsList;
        double pivotX = 0, pivotY = 0;
        _3Vector AngleX, AngleY, AngleZ, AngleZero;

        private void Main_Resize(object sender, EventArgs e)
        {
            //1419, 1075

        }

        private void Main_Load(object sender, EventArgs e)
        {

            this.DisplayBox.Image = new Bitmap(DisplayBox.Width, DisplayBox.Height);
            InitializeAngleGrid();
        }

        private void DisplayBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DisplayBox_Resize(object sender, EventArgs e)
        {
            //pivotX = 1419 / 2;
            //pivotY = 1075 / 2;
        }

        private void DisplayBox_MouseMove(object sender, MouseEventArgs e)
        {
            pivotX = 1419 / 2;
            pivotY = 1075 / 2;
            textBox1.Text = pivotX.ToString() + ";" + pivotY.ToString() + ":" +
                DisplayBox.Width.ToString() + ";" + DisplayBox.Height.ToString();
            var result = DrawGraphics.DrawBitmap(e, this.DisplayBox, vectorPointsList, 340, 250);
            DrawGrids();
            DrawAngleAxis(result);
            DisplayBox.Refresh();
        }

        public Main()
        {
            InitializeComponent();
            AnglePictureBox.BackColor = Color.Transparent;
            container = new SimpleFunctionContainer((u, v) => (-v * (2* u -1)) / (Math.Pow((u - 1), 2) + Math.Pow(v, 2)) * 80, 8, 8, 20);
            //container = new SimpleFunctionContainer((u, v) => (u*(1-u) - Math.Pow(v,2))/(Math.Pow((u - 1),2) + Math.Pow(v, 2)) * 200  + 200, 8, 8, 20);
            //container = new SimpleFunctionContainer((u, v) => (Math.Pow(Math.Cos(u), 5) * v - Math.Pow(v, 5) * u) / 3900000, 8, 8, 20);
            vectorPointsList = container.VectorPointsList;
            model = new ModelContainer(container);
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
               
            container = new SimpleFunctionContainer((u, v) => VariableFunctionContainer.GetCurrentValue(1,x,y,z,t)*(u) + VariableFunctionContainer.GetCurrentValue(2, x, y, z, t) * (Math.Pow(u,2)), 8, 8, 20);
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
