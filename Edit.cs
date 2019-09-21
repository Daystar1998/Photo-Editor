using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhotoEditor {

	public partial class Edit : Form {

		private Image image;
		private string fileName;

		public Edit(Image image, string fileName) {

			InitializeComponent();

			if (image == null) {

				throw new ArgumentNullException(nameof(image));
			}

			if (fileName == null) {

				throw new ArgumentNullException(nameof(fileName));
			}

			this.image = (Image)image.Clone();
			pictureBox1.Image = this.image;
			this.fileName = fileName;
		}

		private void CancelButton_Click(object sender, EventArgs e) {

			this.Close();
		}

		private void SaveButton_Click(object sender, EventArgs e) {

			image.Save(fileName, ImageFormat.Jpeg);
			this.Close();
		}

		private async void InvertButton_Click(object sender, EventArgs e) {

			Bitmap image = (Bitmap)pictureBox1.Image.Clone();

			DisableComponents();

			Transforming transformingWindow = new Transforming();

			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken cancellationToken = cancellationTokenSource.Token;

			transformingWindow.OnCancel += () => {

				cancellationTokenSource.Cancel();
			};

			transformingWindow.Show();

			await Task.Run(() => {

				int currentPercentage = 0;
				int totalPixels = image.Width * image.Height;

				// Teacher provided code
				for (int y = 0; y < image.Height && !cancellationToken.IsCancellationRequested; y++) {

					for (int x = 0; x < image.Width && !cancellationToken.IsCancellationRequested; x++) {

						Color color = image.GetPixel(x, y);
						int newRed = Math.Abs(color.R - 255);
						int newGreen = Math.Abs(color.G - 255);
						int newBlue = Math.Abs(color.B - 255);
						Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
						image.SetPixel(x, y, newColor);

						int pixelsChanged = y * image.Width + x;
						int percentage = pixelsChanged * 100 / totalPixels;

						if (currentPercentage < percentage) {

							currentPercentage = percentage;

							transformingWindow.Invoke((Action)delegate () {

								// Hacky way of keeping the progress bar updating at the correct speed
								transformingWindow.ProgressPercentage = currentPercentage + 1;
								transformingWindow.ProgressPercentage = currentPercentage;
							});
						}
					}
				}

				if (!cancellationToken.IsCancellationRequested) {

					this.Invoke((Action)delegate () {

						pictureBox1.Image = image;
					});
				}
			});

			transformingWindow.Close();

			EnableComponents();
		}

		private void DisableComponents() {

			brightnessBar.Enabled = false;
			colorButton.Enabled = false;
			invertButton.Enabled = false;
			saveButton.Enabled = false;
			cancelButton.Enabled = false;
		}

		private void EnableComponents() {

			brightnessBar.Enabled = true;
			colorButton.Enabled = true;
			invertButton.Enabled = true;
			saveButton.Enabled = true;
			cancelButton.Enabled = true;
		}
	}
}
