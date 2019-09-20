using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor {

	// TODO: Anchor the picture box to all sides after inserting an image to see if it scales correctly without going behind or in front of other items
	public partial class Edit : Form {

		public Edit() {

			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e) {

			this.Close();
		}
	}
}
