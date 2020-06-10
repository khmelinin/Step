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

namespace _16_DZ_
{
    public partial class Form1 : Form
    {
        TreeView _tree;
        RichTextBox _rtBox;

        public Form1()
        {
            InitializeComponent();

            _tree = new TreeView();
            _rtBox = new RichTextBox();
            Controls.Add(_tree);
            Controls.Add(_rtBox);
            _tree.AfterSelect += _tree_AfterSelect;
            _tree.SetBounds(10, 10, 300, 300);

            _rtBox.SetBounds(330,10,400,300);

            _tree.MouseDown += _tree_MouseDown;
            _rtBox.DragEnter += _rtBox_DragEnter;
            _rtBox.DragDrop += _rtBox_DragDrop;


            var drivers = DriveInfo.GetDrives();

            foreach (var drive in drivers)
            {
                TreeNode node = new TreeNode(drive.Name, 3, 2);
                node.Name = drive.Name;
                _tree.Nodes.Add(node);
            }



        }

        private void _rtBox_DragDrop(object sender, DragEventArgs e)
        {
            _rtBox.Text = e.Data.GetData(DataFormats.StringFormat).ToString();
        }

        private void _rtBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void _tree_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            _tree.DoDragDrop(_tree.SelectedNode.Text, DragDropEffects.Copy);
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        void LoadFromTxt(string p)
        {
            try
            {
                using (StreamReader sr = new StreamReader(p))
                {
                    _rtBox.Text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
