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
        public FormMain()
        {
            InitializeComponent();
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
            if (Play)
            {
                var runningTasks = new List<Task>();

                foreach (var taskFunc in tasks)
                {
                    runningTasks.Add(taskFunc());
                }
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
