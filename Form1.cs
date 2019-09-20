using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /*
             When loading the images from disk into the ListView, you will need to use an async method and Task so the UI
             thread is not locked. The code below discovers all the JPEG images in a directory:

                 DirectoryInfo homeDir = new DirectoryInfo("C:\photos");
                    foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
                    {
                        try
                         {
                             byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                             MemoryStream ms = new MemoryStream(bytes);
                             Image img = Image.FromStream(ms); // Use this instead of Image.FromFile()
                             Console.WriteLine("Filename: " + file.Name);
                             Console.WriteLine("Last mod: " + file.LastWriteTime.ToString());
                             Console.WriteLine("File size: " + file.Length);
                         }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                     }
             */

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Directly locates an image
        }

        private void rootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Selects a root folder to search for images from
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            //Small image Icons and Image data (creation date, size)
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            //Small image Icons
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailToolStripMenuItem.Checked = false;
            smallToolStripMenuItem.Checked = false;
            //Large image Icons
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About aboutbox = new About();
            aboutbox.Show();
        }
    }
}
