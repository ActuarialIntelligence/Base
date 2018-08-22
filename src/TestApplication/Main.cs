using ActuarialIntelligence.Domain.ContainerObjects;
using ActuarialIntelligence.Domain.Model_Containers;
using ActuarialIntelligence.Domain.Model_Containers.ModelInterfaces;
using ActuarialIntelligence.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            pivotX = DisplayBox.Width / 2;
            pivotY = DisplayBox.Height / 2;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            width = DisplayBox.Width;
            height = DisplayBox.Height;
            this.DisplayBox.Image = new Bitmap(DisplayBox.Width, DisplayBox.Height);
            InitializeAngleGrid();
        }

        private void DisplayBox_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DisplayBox_MouseMove(object sender, MouseEventArgs e)
        {
            var result = DrawGraphics.DrawBitmap(e, this.DisplayBox, vectorPointsList, pivotX, pivotY);
            DrawGrids();
            DrawAngleAxis(result);
            DisplayBox.Refresh();
        }

        public Main()
        {
            InitializeComponent();
            AnglePictureBox.BackColor = Color.Transparent;
            pivotX = DisplayBox.Width / 2;
            pivotY = DisplayBox.Height / 2;
            container = new SimpleFunctionContainer((u, v) => (Math.Pow(u, 3) * v - Math.Pow(v, 3) * u) / 3900000, 8, 8, 20);
            vectorPointsList = container.VectorPointsList;
            model = new ModelContainer(container);
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
