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

namespace BasicTTS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string textfilePath = @"C:\Users\Rajah\Documents\Test Data\TextScripts\input.txt";
            //string text = File.ReadAllText(textfilePath);
            var tasks = new List<Func<Task>>() {
            ()=> MoveHelpers.MoveMouth(this.pictureBox, this.pictBoxEyes)
        };

            var runningTasks = new List<Task>();

            foreach(var taskFunc in tasks)
            {
                runningTasks.Add(taskFunc());
            }

            //await Task.WhenAll(runningTasks);

        }

        private void pictBoxEyes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
