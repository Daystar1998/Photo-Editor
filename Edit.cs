using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhotoEditor {

	// TODO: Anchor the picture box to all sides after inserting an image to see if it scales correctly without going behind or in front of other items
	public partial class Edit : Form {

		private Image image;
		private string fileName;

		public Edit(Image image, string fileName) {

			InitializeComponent();

			if(image == null) {

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
	}
}
