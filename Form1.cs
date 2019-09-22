using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace PhotoEditor
{
    public partial class Main : Form
    {
        public static CancellationTokenSource canceler = new CancellationTokenSource();
        CancellationToken token = canceler.Token;
        public Main()
        {
            InitializeComponent();
            PopulateTreeView(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)); //Defaults to the solution folder
			detailToolStripMenuItem_Click(this, null);

			listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Date", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("Size", -2, HorizontalAlignment.Left);
		}

        private void PopulateTreeView(string filePath)
        {
            TreeNode rootNode;

            DirectoryInfo directInfo = new DirectoryInfo(filePath);
            if (directInfo.Exists)
            {
                rootNode = new TreeNode(directInfo.Name);
                rootNode.Tag = directInfo;
                GetDirectories(directInfo.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        async Task GetFiles(DirectoryInfo filePath, CancellationToken cancelled)
        {
			//When loading the images from disk into the ListView, you will need to use an async method and Task so the UI
			//thread is not locked. The code below discovers all the JPEG images in a directory

			await Task.Run(() =>
            {
                DirectoryInfo homeDir = filePath;
                ImageList smallmageList = new ImageList();
				ImageList largeImageList = new ImageList();
				largeImageList.ImageSize = new Size(64, 64);

				int i = 0;
                Invoke((Action)delegate ()
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    progressBar1.MarqueeAnimationSpeed = 30;
                    progressBar1.Show();
                });
                foreach (FileInfo file in homeDir.GetFiles("*.jpg"))
                {
                    if (cancelled.IsCancellationRequested)
                    {
                        break;
                    }
                    ListViewItem item = null;
                    Image img = null;
                    item = new ListViewItem(file.Name, i++);
					item.Tag = file.FullName;
                    try
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(file.FullName);
                        MemoryStream ms = new MemoryStream(bytes);
                        img = Image.FromStream(ms); // Use this instead of Image.FromFile()
                        smallmageList.Images.Add(file.FullName, img);
						largeImageList.Images.Add(file.FullName, img);
						Console.WriteLine("Filename: " + file.Name);
                        Console.WriteLine("Last mod: " + file.LastWriteTime.ToString());
                        Console.WriteLine("File size: " + file.Length);

						item.SubItems.Add(file.LastWriteTime.ToString());
						item.SubItems.Add((file.Length / 1000000).ToString() + " MB");
					}
                    catch
                    {
                        Console.WriteLine("This is not an image file");
					}
					Invoke((Action)delegate () 
                    {
						listView1.Items.Add(item);
					});
                }
                Invoke((Action)delegate ()
                {
                    //Cursor.Current = Cursors.Default;
                    progressBar1.Hide();
                    listView1.SmallImageList = smallmageList;
					listView1.LargeImageList = largeImageList;
					listView1.StateImageList = smallmageList;
                });
            });
        }

        private void locateOnDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Directly locates an image
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFile.FileName;
                if(Path.GetExtension(filePath) != ".jpg")
                {
                    MessageBox.Show("Must Choose a '.jpg' file.", "Filetype Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                     MemoryStream ms = new MemoryStream(bytes);
                     Image img = Image.FromStream(ms);
                     Edit editor = new Edit(img, filePath);
                     editor.Show();
                }
               
            }
        }

        private void rootFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Selects a root folder to search for images from
            FolderBrowserDialog openFolder = new FolderBrowserDialog();

            if(openFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFolder.SelectedPath;
                PopulateTreeView(filePath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
			detailToolStripMenuItem.Checked = true;
            smallToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
			//Small image Icons and Image data (creation date, size)
			listView1.View = View.Details;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailToolStripMenuItem.Checked = false;
			smallToolStripMenuItem.Checked = true;
			largeToolStripMenuItem.Checked = false;
			//Small image Icons
			listView1.View = View.SmallIcon;
		}

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailToolStripMenuItem.Checked = false;
            smallToolStripMenuItem.Checked = false;
			largeToolStripMenuItem.Checked = true;
			//Large image Icons
			listView1.View = View.LargeIcon;
		}

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About aboutbox = new About();
            aboutbox.Show();
        }

       async private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)selected.Tag;

            canceler.Cancel();
            canceler.Dispose();
            canceler = new CancellationTokenSource();
            token = canceler.Token;

            await GetFiles(nodeDirInfo, token);

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int i = 0;
            int selectedIndex = 0;
            foreach (ListViewItem items in listView1.Items)
            {
                if(listView1.Items[i].Selected)
                {
                    selectedIndex = i;
                }
                i++;
            }
            string fileName = (string)listView1.Items[selectedIndex].Tag;
            //MessageBox.Show(fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            Edit editor = new Edit(img, fileName);
            editor.Show();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
			DirectoryInfo nodeDirInfo = (DirectoryInfo)treeView1.Nodes[0].Tag;
			await GetFiles(nodeDirInfo, token);

			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
    }
}
