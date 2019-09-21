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

	public partial class Transforming : Form {

		public delegate void Cancel();
		public event Cancel OnCancel;

		public int ProgressPercentage {

			set {

				progressBar.Value = value;
			}
		}

		public Transforming() {

			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e) {

			OnCancel();
			this.Close();
		}
	}
}
