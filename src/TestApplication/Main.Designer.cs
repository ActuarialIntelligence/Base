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
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayBox
            // 
            this.DisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DisplayBox.Location = new System.Drawing.Point(-1, -2);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(1039, 557);
            this.DisplayBox.TabIndex = 7;
            this.DisplayBox.TabStop = false;
            this.DisplayBox.Click += new System.EventHandler(this.DisplayBox_Click);
            this.DisplayBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayBox_MouseMove);
            // 
            // AnglePictureBox
            // 
            this.AnglePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AnglePictureBox.Location = new System.Drawing.Point(-1, -2);
            this.AnglePictureBox.Name = "AnglePictureBox";
            this.AnglePictureBox.Size = new System.Drawing.Size(198, 200);
            this.AnglePictureBox.TabIndex = 8;
            this.AnglePictureBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 554);
            this.Controls.Add(this.AnglePictureBox);
            this.Controls.Add(this.DisplayBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Actuarial Intelligence";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnglePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox DisplayBox;
        private System.Windows.Forms.PictureBox AnglePictureBox;
    }
}

