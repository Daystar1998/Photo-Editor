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

		public Image Photo { get; private set; }
		private string fileName;
		private int brightnessBarValue;

		public Edit(Image image, string fileName) {

			InitializeComponent();

			if (image == null) {

				throw new ArgumentNullException(nameof(image));
			}

			if (fileName == null) {

				throw new ArgumentNullException(nameof(fileName));
			}

			this.Photo = (Image)image.Clone();
			pictureBox1.Image = this.Photo;
			this.fileName = fileName;
		}

		private void CancelButton_Click(object sender, EventArgs e) {

			this.Close();
		}

		private void SaveButton_Click(object sender, EventArgs e) {

			this.Photo = pictureBox1.Image;
			Photo.Save(fileName, ImageFormat.Jpeg);
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

		private async void ColorButton_Click(object sender, EventArgs e) {

			ColorDialog colorDialog = new ColorDialog();

			DisableComponents();

			if (colorDialog.ShowDialog() == DialogResult.OK) {

				Bitmap image = (Bitmap)pictureBox1.Image.Clone();

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

					for (int y = 0; y < image.Height && !cancellationToken.IsCancellationRequested; y++) {

						for (int x = 0; x < image.Width && !cancellationToken.IsCancellationRequested; x++) {

							Color color = image.GetPixel(x, y);
							double averageColorPercentage = ((color.R + color.G + color.B) / 3.0) / 255.0;
							Color newColor = Color.FromArgb((int)(colorDialog.Color.R * averageColorPercentage), (int)(colorDialog.Color.G * averageColorPercentage), (int)(colorDialog.Color.B * averageColorPercentage));
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
			}

			EnableComponents();
		}

		private void BrightnessBar_MouseDown(object sender, MouseEventArgs e) {

			brightnessBarValue = brightnessBar.Value;
		}

		private async void BrightnessBar_MouseUp(object sender, MouseEventArgs e) {

			if (brightnessBar.Value != brightnessBarValue) {

				brightnessBarValue = brightnessBar.Value;

				Bitmap image = (Bitmap)pictureBox1.Image.Clone();

				DisableComponents();

				Transforming transformingWindow = new Transforming();

				CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
				CancellationToken cancellationToken = cancellationTokenSource.Token;

				transformingWindow.OnCancel += () => {

					cancellationTokenSource.Cancel();
				};

				transformingWindow.Show();

				int amount = Convert.ToInt32(2 * (50 - brightnessBar.Value) * 0.01 * 255);

				await Task.Run(() => {

					int currentPercentage = 0;
					int totalPixels = image.Width * image.Height;

					for (int y = 0; y < image.Height && !cancellationToken.IsCancellationRequested; y++) {

						for (int x = 0; x < image.Width && !cancellationToken.IsCancellationRequested; x++) {

							Color color = image.GetPixel(x, y);
							int newRed = color.R - amount;
							int newGreen = color.G - amount;
							int newBlue = color.B - amount;

							if (newRed < 0)
								newRed = 0;
							else if (newRed > 255)
								newRed = 255;

							if (newGreen < 0)
								newGreen = 0;
							else if (newGreen > 255)
								newGreen = 255;

							if (newBlue < 0)
								newBlue = 0;
							else if (newBlue > 255)
								newBlue = 255;

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
		}

		private void SaveAsButton_Click(object sender, EventArgs e) {

			SaveFileDialog saveFileDialog = new SaveFileDialog();

			int indexOfFinalBackSlash = fileName.LastIndexOf('\\');

			saveFileDialog.InitialDirectory = fileName.Substring(0, indexOfFinalBackSlash);
			saveFileDialog.FileName = fileName.Substring(indexOfFinalBackSlash + 1, fileName.Length - indexOfFinalBackSlash - 1);
			saveFileDialog.Filter = "JPeg Image|*.jpg";
			saveFileDialog.DefaultExt = ".jpg";
			saveFileDialog.AddExtension = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK) {

				this.Photo = pictureBox1.Image;
				this.fileName = saveFileDialog.FileName;
				Photo.Save(fileName, ImageFormat.Jpeg);
				this.Close();
			}
		}
	}
}
