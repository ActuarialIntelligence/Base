using System;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
namespace BasicTTS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.pictBoxEyes = new System.Windows.Forms.PictureBox();
            this.pnlStream = new System.Windows.Forms.Panel();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTalkPath = new System.Windows.Forms.TextBox();
            this.txtPnlContentMP4Path = new System.Windows.Forms.TextBox();
            this.pctrFace = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxEyes)).BeginInit();
            this.pnlStream.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Location = new System.Drawing.Point(1440, 653);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(421, 252);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(-2, -2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(196, 62);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // pictBoxEyes
            // 
            this.pictBoxEyes.BackColor = System.Drawing.Color.Transparent;
            this.pictBoxEyes.Location = new System.Drawing.Point(1351, 300);
            this.pictBoxEyes.Name = "pictBoxEyes";
            this.pictBoxEyes.Size = new System.Drawing.Size(597, 391);
            this.pictBoxEyes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBoxEyes.TabIndex = 2;
            this.pictBoxEyes.TabStop = false;
            this.pictBoxEyes.Click += new System.EventHandler(this.pictBoxEyes_Click);
            // 
            // pnlStream
            // 
            this.pnlStream.Controls.Add(this.vlcControl);
            this.pnlStream.Location = new System.Drawing.Point(97, 146);
            this.pnlStream.Name = "pnlStream";
            this.pnlStream.Size = new System.Drawing.Size(863, 508);
            this.pnlStream.TabIndex = 3;
            this.pnlStream.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.BackgroundImage = global::BasicTTS.Properties.Resources.back;
            this.vlcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcControl.Location = new System.Drawing.Point(0, 0);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(863, 508);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 0;
            this.vlcControl.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcControl.VlcLibDirectory")));
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.Click += new System.EventHandler(this.vlcControl_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "Panel Play";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // txtTalkPath
            // 
            this.txtTalkPath.Location = new System.Drawing.Point(419, -2);
            this.txtTalkPath.Name = "txtTalkPath";
            this.txtTalkPath.Size = new System.Drawing.Size(764, 38);
            this.txtTalkPath.TabIndex = 5;
            this.txtTalkPath.Text = "C:\\Users\\Rajah\\Documents\\Test Data\\TextScripts\\input.txt";
            this.txtTalkPath.TextChanged += new System.EventHandler(this.txtTalkPath_TextChanged);
            // 
            // txtPnlContentMP4Path
            // 
            this.txtPnlContentMP4Path.Location = new System.Drawing.Point(419, 42);
            this.txtPnlContentMP4Path.Name = "txtPnlContentMP4Path";
            this.txtPnlContentMP4Path.Size = new System.Drawing.Size(764, 38);
            this.txtPnlContentMP4Path.TabIndex = 6;
            this.txtPnlContentMP4Path.Text = "C:\\Users\\Rajah\\Videos\\CartmanVids\\Cartman1.mp4";
            // 
            // pctrFace
            // 
            this.pctrFace.BackColor = System.Drawing.Color.Transparent;
            this.pctrFace.Image = global::BasicTTS.Properties.Resources.CartmanDefaultFace;
            this.pctrFace.Location = new System.Drawing.Point(662, 398);
            this.pctrFace.Name = "pctrFace";
            this.pctrFace.Size = new System.Drawing.Size(597, 391);
            this.pctrFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrFace.TabIndex = 7;
            this.pctrFace.TabStop = false;
            this.pctrFace.Visible = false;
            this.pctrFace.Paint += new System.Windows.Forms.PaintEventHandler(this.PctrFace_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BasicTTS.Properties.Resources.CartmanDefaultBodyMe;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1921, 1186);
            this.Controls.Add(this.pctrFace);
            this.Controls.Add(this.txtPnlContentMP4Path);
            this.Controls.Add(this.txtTalkPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlStream);
            this.Controls.Add(this.pictBoxEyes);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxEyes)).EndInit();
            this.pnlStream.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.PictureBox pictBoxEyes;
        private System.Windows.Forms.Panel pnlStream;
        private Button button1;
        private TextBox txtTalkPath;
        private TextBox txtPnlContentMP4Path;
        private PictureBox pctrFace;
    }
}

