namespace PhotoEditor
{
    partial class Edit
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.invertButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.brightnessBar = new System.Windows.Forms.TrackBar();
            this.lightLabel = new System.Windows.Forms.Label();
            this.DarkLabel = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 374);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // invertButton
            // 
            this.invertButton.Location = new System.Drawing.Point(492, 43);
            this.invertButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invertButton.Name = "invertButton";
            this.invertButton.Size = new System.Drawing.Size(80, 32);
            this.invertButton.TabIndex = 1;
            this.invertButton.Text = "Invert";
            this.invertButton.UseVisualStyleBackColor = true;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(265, 44);
            this.colorButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(81, 30);
            this.colorButton.TabIndex = 2;
            this.colorButton.Text = "Color...";
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // brightnessBar
            // 
            this.brightnessBar.AutoSize = false;
            this.brightnessBar.Location = new System.Drawing.Point(27, 44);
            this.brightnessBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brightnessBar.Name = "brightnessBar";
            this.brightnessBar.Size = new System.Drawing.Size(121, 44);
            this.brightnessBar.TabIndex = 3;
            this.brightnessBar.Tag = "";
            this.brightnessBar.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // lightLabel
            // 
            this.lightLabel.AutoSize = true;
            this.lightLabel.Location = new System.Drawing.Point(5, 26);
            this.lightLabel.Name = "lightLabel";
            this.lightLabel.Size = new System.Drawing.Size(39, 17);
            this.lightLabel.TabIndex = 4;
            this.lightLabel.Text = "Light";
            // 
            // DarkLabel
            // 
            this.DarkLabel.AutoSize = true;
            this.DarkLabel.Location = new System.Drawing.Point(131, 26);
            this.DarkLabel.Name = "DarkLabel";
            this.DarkLabel.Size = new System.Drawing.Size(38, 17);
            this.DarkLabel.TabIndex = 5;
            this.DarkLabel.Text = "Dark";
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(48, 73);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(75, 17);
            this.brightnessLabel.TabIndex = 6;
            this.brightnessLabel.Text = "Brightness";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.brightnessLabel);
            this.groupBox1.Controls.Add(this.invertButton);
            this.groupBox1.Controls.Add(this.brightnessBar);
            this.groupBox1.Controls.Add(this.DarkLabel);
            this.groupBox1.Controls.Add(this.colorButton);
            this.groupBox1.Controls.Add(this.lightLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 393);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(596, 102);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(509, 507);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(401, 507);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 550);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Edit";
            this.Text = "Edit Photo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button invertButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.TrackBar brightnessBar;
        private System.Windows.Forms.Label lightLabel;
        private System.Windows.Forms.Label DarkLabel;
        private System.Windows.Forms.Label brightnessLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button saveButton;
	}
}