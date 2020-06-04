using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_list_view_
{
    public partial class Form1 : Form
    {
        ListView _table;
        ListBox _listbox;
        public Form1()
        {
            InitializeComponent();
            this.Height = 640;
            this.Width = 640;

            _table = new ListView();
            _table.SetBounds(300, 12, 300, 200);
            Controls.Add(_table);

            _table.Items.Add(new ListViewItem("First"));
            _table.Items.Add(new ListViewItem("Second"));
            _table.Items.Add(new ListViewItem("Third"));
            _table.Items.Add(new ListViewItem("Fourth"));
            _table.Items.Add(new ListViewItem("Fifth"));

            _table.View = View.Details;

            _table.Columns.Add("Column1");
            _table.Columns[0].Width = 100;
            _table.Columns.Add("Column2");
            _table.Columns[1].Width = 100;

            int i = 1;
            foreach (ListViewItem item in _table.Items)
            {
                item.SubItems.Add($"Sub element {i++}");
            }

            _listbox = new ListBox();
            _listbox.SetBounds(12, 330, 300, 200);
            Controls.Add(_listbox);

            ViewList();
            _table.DoubleClick += _table_DoubleClick;
        }

        private void _table_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ListView).SelectedItems[0].Text);
            _table.Items.Remove((sender as ListView).SelectedItems[0]);
        }

        void ViewList()
        {
            foreach (ListViewItem item in _table.Items)
            {
                var text = item.Text;
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    text += $": {subitem.Text}";
                }
                _listbox.Items.Add(text);
            }
        }
    }
}
