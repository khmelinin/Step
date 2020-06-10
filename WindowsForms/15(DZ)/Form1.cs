using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15_DZ_
{
    public partial class Form1 : Form
    {
        TreeView _tree;
        ImageList _gallery;
        
        public Form1()
        {
            InitializeComponent();

            _tree = new TreeView();
            Controls.Add(_tree);
            _tree.AfterSelect += _tree_AfterSelect;
            _tree.SetBounds(10, 10, 300, 300);
            _gallery = new ImageList();
            _tree.ImageList = _gallery;
            _gallery.ImageSize = new Size(20, 20);
            _gallery.Images.Add(new Bitmap(Properties.Resources.disk));
            _gallery.Images.Add(new Bitmap(Properties.Resources.Image1));
            _gallery.Images.Add(new Bitmap(Properties.Resources.file));
            
            
            var drivers = DriveInfo.GetDrives();

            foreach (var drive in drivers)
            {
                TreeNode node = new TreeNode(drive.Name, 3, 2);
                node.Name = drive.Name;
                node.ImageKey = Properties.Resources.disk.ToString();
                _tree.Nodes.Add(node);
            }

            

        }

        private void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var selected = _tree.SelectedNode;
                var directories = Directory.GetDirectories(selected.Text);
                var files = Directory.GetFiles(selected.Text);

                foreach (var dir in directories)
                {

                    var node = new TreeNode(dir, 0, 2);
                    node.Text = Path.GetFullPath(dir);
                    selected.Nodes.Add(node);
                }

                foreach (var file in files)
                {
                    selected.Nodes.Add(new TreeNode(file, 1, 2));
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
