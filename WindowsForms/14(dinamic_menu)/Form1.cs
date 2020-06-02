using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_dinamic_menu_
{
    public partial class Form1 : Form
    {
        MenuStrip _mainMenu;
        ContextMenuStrip _contextMenuTextBox;
        ToolBar _tBar;
        ImageList _imageList;
        public Form1()
        {
            InitializeComponent();
            CreateMenu();
            CreateContextMenu();

            _imageList = new ImageList();
            _imageList.ImageSize = new Size(30, 30);
            // _imageList.Images.Add(new Bitmap(""));
            _imageList.Images.Add(Properties.Resources.open_png);
            _imageList.Images.Add(Properties.Resources.save);
            _imageList.Images.Add(Properties.Resources.close);

            _tBar = new ToolBar();
            _tBar.ImageList = _imageList;

            ToolBarButton toolBarButton1 = new ToolBarButton();
            ToolBarButton toolBarButton2 = new ToolBarButton();
            ToolBarButton toolBarButton3 = new ToolBarButton();
            ToolBarButton separator = new ToolBarButton();

            separator.Style = ToolBarButtonStyle.Separator;

            toolBarButton1.ImageIndex = 0; //open
            toolBarButton2.ImageIndex = 1; // save
            toolBarButton3.ImageIndex = 2; //close

            _tBar.Buttons.Add(toolBarButton1);
            _tBar.Buttons.Add(separator);
            _tBar.Buttons.Add(toolBarButton2);
            _tBar.Buttons.Add(separator);
            _tBar.Buttons.Add(toolBarButton3);
            _tBar.BorderStyle = BorderStyle.Fixed3D;
            _tBar.ButtonClick += _tBar_ButtonClick;
            this.Controls.Add(_tBar);

        }

        private void _tBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch(e.Button.ImageIndex)
            {
                case 0:
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        if(file.ShowDialog()==DialogResult.OK)
                        {
                            using (StreamReader sr = new StreamReader(file.FileName))
                            {
                                textBox1.Text = sr.ReadToEnd();
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        SaveFileDialog file = new SaveFileDialog();
                        if(file.ShowDialog()== DialogResult.OK)
                        {
                            using(StreamWriter sw = new StreamWriter(file.FileName))
                            {
                                sw.Write(textBox1.Text);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        this.Close();
                        break;
                    }
            }
        }

        void CreateContextMenu()
        {
            closeToolStripMenuItem.Click += Close_Click;

            _contextMenuTextBox = new ContextMenuStrip();
            var copy = _contextMenuTextBox.Items.Add("Copy");
            //copy.Click += delegate (object sender, EventArgs e) { textBox1.Copy(); };
            copy.Click += CopyText;
            _contextMenuTextBox.Items.Add("Cut");
            _contextMenuTextBox.Items.Add("Paste");
            textBox1.ContextMenuStrip = _contextMenuTextBox;
        }
        void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void CopyText(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
        void CreateMenu()
        {
            _mainMenu = new MenuStrip();
            ToolStripMenuItem file = (ToolStripMenuItem)_mainMenu.Items.Add("File");
            ToolStripMenuItem edit = (ToolStripMenuItem)_mainMenu.Items.Add("Edit");

            this.MainMenuStrip = _mainMenu;
            this.Controls.Add(_mainMenu);

            var copy = edit.DropDownItems.Add("Copy");
            copy.Click += CopyText;

            edit.DropDownItems.Add("Cut");
            edit.DropDownItems.Add("Paste");

            ToolStripMenuItem close = (ToolStripMenuItem)file.DropDownItems.Add("Close");
            close.ShortcutKeys = Keys.Alt | Keys.C;
            close.ShowShortcutKeys = true;
            close.Click += new EventHandler(Close_Click);

            file.DropDownItems.Add(new ToolStripSeparator());
            file.DropDownItems.Add(new ToolStripTextBox());

        }
    }
}
