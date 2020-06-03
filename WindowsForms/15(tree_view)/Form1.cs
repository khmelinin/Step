using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15_tree_view_
{
    public partial class Form1 : Form
    {
        ListBox _lb;
        ImageList _gallery;
        TreeView _tree;
        public Form1()
        {
            InitializeComponent();


            treeView1.SetBounds(12, 10, 300, 200);

            _lb = new ListBox();
            _lb.SetBounds(12, 230, 300, 200);
            Controls.Add(_lb);
            RecurceList(treeView1.Nodes, string.Empty);

            _tree = new TreeView();
            Controls.Add(_tree);
            _tree.SetBounds(322, 10, 460, 520);
            TreeNode node1 = new TreeNode("Root node 1");
            _tree.Nodes.Add(node1);
            _gallery = new ImageList();
            _tree.ImageList = _gallery;
            _gallery.ImageSize = new Size(100, 70);
            Bitmap bmp = new Bitmap(Properties.Resources.PixelCitySkyline);
            _gallery.Images.Add(bmp);
            bmp = new Bitmap(Properties.Resources._124);
            _gallery.Images.Add(bmp);
            bmp = new Bitmap(Properties.Resources._VATAR_sity_skyline_);
            _gallery.Images.Add(bmp);
            bmp = new Bitmap(Properties.Resources.Rick_and_morty_on_t_shortPNG);
            _gallery.Images.Add(bmp);

            node1 = new TreeNode("Root node 2", 1, 2);
            _tree.Nodes.Add(node1);
            _tree.Nodes.Add(new TreeNode("Root node 3", 2, 3));

            node1.Nodes.Add(new TreeNode("Child Image", 0, 3));
        }

        void RecurceList(TreeNodeCollection nodes, string qName)
        {
            foreach (TreeNode node in nodes)
            {
                _lb.Items.Add(qName + node.Text);
                if (node.Nodes.Count > 0)
                    RecurceList(node.Nodes, qName + node.Text + " : ");
            }
        }
    }
}
