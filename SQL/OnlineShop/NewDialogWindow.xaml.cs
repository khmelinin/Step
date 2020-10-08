using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineShop
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class NewDialogWindow : Window
    {
        private List<OnlineShop.Item> _items;
        private List<OnlineShop.Category> _categories;
        private List<OnlineShop.Characteristic> _characteristics;
        private List<OnlineShop.ItemCharacteristic> _itemcharacteristics;
        private OnlineShop.Item tmp;
        private OnlineShop.ItemCharacteristic tmp1;
        public NewDialogWindow()
        {
            InitializeComponent();
            using (var db = new OnlineShopEntities1())
            {
                _items = db.Items.ToList();
                _categories = db.Categories.ToList();
                _characteristics = db.Characteristics.ToList();
                _itemcharacteristics = db.ItemCharacteristics.ToList();
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new OnlineShopEntities1())
            {
                db.Items.Attach(tmp);
                db.Entry(tmp).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                this.DialogResult = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (titleText.Text.Length > 0 && categoryText.Text.Length > 0 && creatorText.Text.Length > 0)
            {
                using (var db = new OnlineShopEntities1())
                {
                    tmp = new OnlineShop.Item { itemTitle = titleText.Text, categoryId = Int32.Parse(categoryText.Text), creator = creatorText.Text, info = infoText.Text };

                    gridItems.ItemsSource = new List<OnlineShop.Item> { tmp };
                }
            }
            else
            {
                MessageBox.Show("Fill all form");
            }
        }

        private void AddCharacteristicButton_Click(object sender, RoutedEventArgs e)
        {
            if (characteristicsText.Text.Length > 0)
            {
                tmp1 = new ItemCharacteristic { itemId = tmp.itemId, characteristicId = Int32.Parse(characteristicsText.Text) };
                using (var db = new OnlineShopEntities1())
                {
                    db.ItemCharacteristics.Attach(tmp1);
                    db.Entry(tmp1).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Fill all form");
            }
        }
    }
}
