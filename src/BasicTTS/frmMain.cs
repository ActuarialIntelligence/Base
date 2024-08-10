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
using Vlc.DotNet.Forms;

namespace BasicTTS
{
    public partial class FormMain : Form
    {
        bool Play = true;
        private VlcControl vlcControl;
        private float rotationAngle = 0;

        public FormMain()
        {
            InitializeComponent();
            // Hook up the Paint event for pctrFace (formerly pbox3)
            pctrFace.Paint += PctrFace_Paint;
        }

        private void RotateBoxes(float angle)
        {
            Point center = new Point(pctrFace.Width / 2, pctrFace.Height / 2);

            Point relativePictBoxEyes = new Point(pictBoxEyes.Left + pictBoxEyes.Width / 2 - center.X, pictBoxEyes.Top + pictBoxEyes.Height / 2 - center.Y);
            Point relativePictureBox = new Point(pictureBox.Left + pictureBox.Width / 2 - center.X, pictureBox.Top + pictureBox.Height / 2 - center.Y);

            Point newPictBoxEyesCenter = RotatePoint(relativePictBoxEyes, center, angle);
            Point newPictureBoxCenter = RotatePoint(relativePictureBox, center, angle);

            pictBoxEyes.Left = newPictBoxEyesCenter.X - pictBoxEyes.Width / 2;
            pictBoxEyes.Top = newPictBoxEyesCenter.Y - pictBoxEyes.Height / 2;

            pictureBox.Left = newPictureBoxCenter.X - pictureBox.Width / 2;
            pictureBox.Top = newPictureBoxCenter.Y - pictureBox.Height / 2;
        }

        private Point RotatePoint(Point point, Point center, float angle)
        {
            double radians = angle * Math.PI / 180;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            int x = center.X + (int)(cos * (point.X - center.X) - sin * (point.Y - center.Y));
            int y = center.Y + (int)(sin * (point.X - center.X) + cos * (point.Y - center.Y));

            return new Point(x, y);
        }

        private void PctrFace_Paint(object sender, PaintEventArgs e)
        {
            //RotateBoxes(rotationAngle);
        }

        // Method to update the rotation angle and refresh pctrFace
        private void UpdateRotation(float angle)
        {
            rotationAngle = angle;
            pctrFace.Invalidate(); // This will trigger the Paint event
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //2711, 1647
            this.Size = new System.Drawing.Size(811, 550);


        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            string textfilePath = txtTalkPath.Text;
            //string text = File.ReadAllText(textfilePath);
            var tasks = new List<Func<Task>>() {
                ()=> MoveHelpers.GenerateFacialExpressionsBasedOnText(this.pictureBox, this.pictBoxEyes,textfilePath)
             };
            //RotateBoxes(45);
            var runningTasks = new List<Task>();

                foreach (var taskFunc in tasks)
                {
                    runningTasks.Add(taskFunc());
                }


        }

        private void pictBoxEyes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vlcControl_Click(object sender, EventArgs e)
        {

        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            // https://www.youtube.com/watch?v=pVgSY-i2L_w
           
            string mediaPath = txtPnlContentMP4Path.Text;
            this.vlcControl.SetMedia(new Uri(mediaPath));
            this.vlcControl.Play();
        }

        private void txtTalkPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
