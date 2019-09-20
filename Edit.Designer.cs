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
			this.pictureBox1.Location = new System.Drawing.Point(10, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(449, 304);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// invertButton
			// 
			this.invertButton.Location = new System.Drawing.Point(369, 35);
			this.invertButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.invertButton.Name = "invertButton";
			this.invertButton.Size = new System.Drawing.Size(60, 26);
			this.invertButton.TabIndex = 1;
			this.invertButton.Text = "Invert";
			this.invertButton.UseVisualStyleBackColor = true;
			// 
			// colorButton
			// 
			this.colorButton.Location = new System.Drawing.Point(199, 36);
			this.colorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.colorButton.Name = "colorButton";
			this.colorButton.Size = new System.Drawing.Size(61, 24);
			this.colorButton.TabIndex = 2;
			this.colorButton.Text = "Color...";
			this.colorButton.UseVisualStyleBackColor = true;
			// 
			// brightnessBar
			// 
			this.brightnessBar.AutoSize = false;
			this.brightnessBar.Location = new System.Drawing.Point(20, 36);
			this.brightnessBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.brightnessBar.Name = "brightnessBar";
			this.brightnessBar.Size = new System.Drawing.Size(91, 36);
			this.brightnessBar.TabIndex = 3;
			this.brightnessBar.Tag = "";
			this.brightnessBar.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// lightLabel
			// 
			this.lightLabel.AutoSize = true;
			this.lightLabel.Location = new System.Drawing.Point(4, 21);
			this.lightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lightLabel.Name = "lightLabel";
			this.lightLabel.Size = new System.Drawing.Size(30, 13);
			this.lightLabel.TabIndex = 4;
			this.lightLabel.Text = "Light";
			// 
			// DarkLabel
			// 
			this.DarkLabel.AutoSize = true;
			this.DarkLabel.Location = new System.Drawing.Point(98, 21);
			this.DarkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.DarkLabel.Name = "DarkLabel";
			this.DarkLabel.Size = new System.Drawing.Size(30, 13);
			this.DarkLabel.TabIndex = 5;
			this.DarkLabel.Text = "Dark";
			// 
			// brightnessLabel
			// 
			this.brightnessLabel.AutoSize = true;
			this.brightnessLabel.Location = new System.Drawing.Point(36, 59);
			this.brightnessLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.brightnessLabel.Name = "brightnessLabel";
			this.brightnessLabel.Size = new System.Drawing.Size(56, 13);
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
			this.groupBox1.Location = new System.Drawing.Point(10, 319);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(447, 83);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(382, 412);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(301, 412);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 9;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// Edit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 447);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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