namespace TestApplication
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.DisplayBox = new System.Windows.Forms.PictureBox();
            this.AnglePictureBox = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayBox
            // 
            this.DisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DisplayBox.Location = new System.Drawing.Point(1, -1);
            this.DisplayBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(2461, 1333);
            this.DisplayBox.TabIndex = 7;
            this.DisplayBox.TabStop = false;
            this.DisplayBox.Click += new System.EventHandler(this.DisplayBox_Click);
            this.DisplayBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayBox_MouseMove);
            this.DisplayBox.Resize += new System.EventHandler(this.DisplayBox_Resize);
            // 
            // AnglePictureBox
            // 
            this.AnglePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AnglePictureBox.Location = new System.Drawing.Point(1, -1);
            this.AnglePictureBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.AnglePictureBox.Name = "AnglePictureBox";
            this.AnglePictureBox.Size = new System.Drawing.Size(528, 477);
            this.AnglePictureBox.TabIndex = 8;
            this.AnglePictureBox.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox2.Location = new System.Drawing.Point(2013, -1);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(435, 38);
            this.textBox2.TabIndex = 10;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(1004, -1);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1015, 38);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(528, 75);
            this.button1.TabIndex = 11;
            this.button1.Text = "Animate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2452, 1321);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AnglePictureBox);
            this.Controls.Add(this.DisplayBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Main";
            this.Text = "Actuarial Intelligence";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox DisplayBox;
        private System.Windows.Forms.PictureBox AnglePictureBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

