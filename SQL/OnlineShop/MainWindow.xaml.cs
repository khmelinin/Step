using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<OnlineShop.Item> _items;
        private List<OnlineShop.Category> _categories;
        private List<OnlineShop.Characteristic> _characteristics;
        private List<OnlineShop.ItemCharacteristic> _itemcharacteristics;
        List<string> filters = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new OnlineShopEntities1())
            {
                _items = db.Items.ToList();
                _categories = db.Categories.ToList();
                _characteristics = db.Characteristics.ToList();
                _itemcharacteristics = db.ItemCharacteristics.ToList();
            }
            gridItems.ItemsSource = _items;
            gridCategories.ItemsSource = _categories;
            gridCharacteristics.ItemsSource = _characteristics;
            gridItemCharacteristics.ItemsSource = _itemcharacteristics;
            FilterCategory.ItemsSource = _categories;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            new NewDialogWindow().ShowDialog();
            using (var db = new OnlineShopEntities1())
            {
                _items = db.Items.ToList();
                _itemcharacteristics = db.ItemCharacteristics.ToList();
                gridItems.ItemsSource = _items;
                gridItemCharacteristics.ItemsSource = _itemcharacteristics;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridItems.SelectedIndex != -1)
            {
                new EditDialogWindow(gridItems.SelectedIndex).ShowDialog();
                using (var db = new OnlineShopEntities1())
                {
                    _items = db.Items.ToList();
                    _itemcharacteristics = db.ItemCharacteristics.ToList();
                    gridItems.ItemsSource = _items;
                    gridItemCharacteristics.ItemsSource = _itemcharacteristics;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridItems.SelectedIndex != -1)
            {
                using (var db = new OnlineShopEntities1())
                {
                    
                    var tmp = gridItems.SelectedItem as OnlineShop.Item;
                    db.Items.Attach(tmp);
                    db.Entry(tmp).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    _items = db.Items.ToList();
                    _itemcharacteristics = db.ItemCharacteristics.ToList();
                    gridItems.ItemsSource = _items;
                    gridItemCharacteristics.ItemsSource = _itemcharacteristics;
                }
            }
        }

        private void FilterCategory_Selected(object sender, RoutedEventArgs e)
        {
            var tmp_items = new List<OnlineShop.Item>();
            for (int i = 0; i < _items.Count; i++)
            {
                if(_items[i].categoryId==FilterCategory.SelectedIndex+1)
                {
                    tmp_items.Add(_items[i]);
                }
            }
            gridItems.ItemsSource = tmp_items;
        }

        private void FilterAll_Selected(object sender, RoutedEventArgs e)
        {
            gridItems.ItemsSource = _items;
        }
    }
}
