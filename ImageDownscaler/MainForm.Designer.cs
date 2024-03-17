namespace ImageDownscaler
{
    partial class MainForm
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
            this.browseImageBtn = new System.Windows.Forms.Button();
            this.ImageTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DownsizeNumberTextBox = new System.Windows.Forms.TextBox();
            this.seqBtn = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.parallelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // browseImageBtn
            // 
            this.browseImageBtn.Location = new System.Drawing.Point(351, 25);
            this.browseImageBtn.Name = "browseImageBtn";
            this.browseImageBtn.Size = new System.Drawing.Size(75, 23);
            this.browseImageBtn.TabIndex = 0;
            this.browseImageBtn.Text = "Browse";
            this.browseImageBtn.UseVisualStyleBackColor = true;
            this.browseImageBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageTextBox
            // 
            this.ImageTextBox.Location = new System.Drawing.Point(43, 25);
            this.ImageTextBox.Name = "ImageTextBox";
            this.ImageTextBox.Size = new System.Drawing.Size(283, 22);
            this.ImageTextBox.TabIndex = 1;
            this.ImageTextBox.Text = "Choose image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(43, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 417);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(619, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(545, 417);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // DownsizeNumberTextBox
            // 
            this.DownsizeNumberTextBox.Location = new System.Drawing.Point(43, 553);
            this.DownsizeNumberTextBox.Name = "DownsizeNumberTextBox";
            this.DownsizeNumberTextBox.Size = new System.Drawing.Size(175, 22);
            this.DownsizeNumberTextBox.TabIndex = 4;
            // 
            // seqBtn
            // 
            this.seqBtn.Location = new System.Drawing.Point(399, 553);
            this.seqBtn.Name = "seqBtn";
            this.seqBtn.Size = new System.Drawing.Size(115, 23);
            this.seqBtn.TabIndex = 5;
            this.seqBtn.Text = "Sequential";
            this.seqBtn.UseVisualStyleBackColor = true;
            this.seqBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(40, 525);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(177, 16);
            this.label.TabIndex = 6;
            this.label.Text = "Choose downsize factor in %";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // parallelBtn
            // 
            this.parallelBtn.Location = new System.Drawing.Point(252, 552);
            this.parallelBtn.Name = "parallelBtn";
            this.parallelBtn.Size = new System.Drawing.Size(115, 23);
            this.parallelBtn.TabIndex = 7;
            this.parallelBtn.Text = "Parallel";
            this.parallelBtn.UseVisualStyleBackColor = true;
            this.parallelBtn.Click += new System.EventHandler(this.parallelBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 626);
            this.Controls.Add(this.parallelBtn);
            this.Controls.Add(this.label);
            this.Controls.Add(this.seqBtn);
            this.Controls.Add(this.DownsizeNumberTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ImageTextBox);
            this.Controls.Add(this.browseImageBtn);
            this.Name = "MainForm";
            this.Text = "ImageDownscaler";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseImageBtn;
        private System.Windows.Forms.TextBox ImageTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox DownsizeNumberTextBox;
        private System.Windows.Forms.Button seqBtn;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button parallelBtn;
    }
}

