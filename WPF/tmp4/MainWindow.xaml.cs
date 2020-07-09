using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace tmp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Country> countries;
        List<Country> list_countries;
        List<Country> search_countries;
        bool saved = false;
        bool selected = true;

        SaveFileDialog sfd;
        OpenFileDialog ofd;

        public MainWindow()
        {
            InitializeComponent();
            list_countries = new List<Country>();
            search_countries = new List<Country>();
            countries = new List<Country>();
            InitializeCountries();

            sfd = new SaveFileDialog();
            sfd.Filter = "Pdf files(*.pdf)|*.pdf|Text files(*.txt)|*.txt|All files(*.*)|*.*";

            ofd = new OpenFileDialog();
            ofd.Filter = "Pdf files(*.pdf)|*.pdf|Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }

        private void InitializeCountries()
        {
            countries.Add(new Country(
                "USA",
                "https://img.salamnews.org/594e67df8f2b153a7b25bd9d9cd9290a/v-ssha-iz-moskvy-vsego-za-22500-tuda-obratno-photo-big_484.jpg",
                "https://www.youtube.com/watch?v=b7FNvq11CEw",
                "America",
                "English language",
                "burgers, hot-dogs",
                "dollar",
                "-6",
                "sunny",
                "Statue of liberty",
                "snakes",
                "600 - 800 home, 200 - 400 food"
                ));

            countries.Add(new Country(
                "Expensive USA",
                "https://europeanbusinessmagazine.com/wp-content/uploads/2019/08/mcdonalds-2.jpg",
                "https://www.youtube.com/watch?v=pNEO1RSWsmI&feature=emb_title",
                "America(expensive)",
                "English language",
                "lopsters, vine",
                "lots of dollars",
                "-7",
                "always sunny",
                "Wall street",
                "buisnessmen",
                "6000 - 8000 home, 2000 - 4000 food"
                ));
        }

        private void Search(string tmp)
        {
            if (tmp != "")
            {
                for (int i = 0; i < countries.Count; i++)
                {
                    if (
                        countries[i].Name.Contains(tmp) ||
                        countries[i].Curency.Contains(tmp) ||
                        countries[i].Description.Contains(tmp) ||
                        countries[i].Facts.Contains(tmp) ||
                        countries[i].Dishes.Contains(tmp) ||
                        countries[i].Sights.Contains(tmp) ||
                        countries[i].Timezone.Contains(tmp) ||
                        countries[i].Weather.Contains(tmp) ||
                        countries[i].Warnings.Contains(tmp) ||
                        countries[i].Prices.Contains(tmp)
                        )
                    {
                        search_countries.Add(countries[i]);
                    }
                }
            }
        }
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            search_countries.Clear();
            searchListBox.Items.Clear();
            if(e.Key==Key.Enter)
            {
                Search(searchTextBox.Text);
                for (int i = 0; i < search_countries.Count; i++)
                {
                    searchListBox.Items.Add(search_countries[i].ToStringShort());
                }
            }
        }

        private void New_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            New();
        }
        private void Open_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFull();
        }

        private void AddSelectedImage(string path)
        {
            ImageBox.Source = new BitmapImage(new Uri(path));
        }

        private void listListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list_countries.Count > 0 && selected)
            {
                if (selectedListBox.Items.Count > 0)
                {
                    selectedListBox.Items.Clear();
                    selectedListBox.Items.Add(list_countries[listListBox.SelectedIndex].ToStringLong());
                }
                else
                {
                    selectedListBox.Items.Add(list_countries[listListBox.SelectedIndex].ToStringLong());
                }
                AddSelectedImage(list_countries[listListBox.SelectedIndex].Photo);
            }
            else
            {
                listListBox.SelectedIndex = 0;
                selected = true;
            }
        }

        private void searchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (search_countries.Count > 0)
            {
                if (selectedListBox.Items.Count > 0)
                {
                    selectedListBox.Items.Clear();
                    selectedListBox.Items.Add(search_countries[searchListBox.SelectedIndex].ToStringLong());
                }
                else
                    selectedListBox.Items.Add(search_countries[searchListBox.SelectedIndex].ToStringLong());

                AddSelectedImage(search_countries[searchListBox.SelectedIndex].Photo);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(searchListBox.Items.Count>0 && searchListBox.SelectedIndex>=0)
            {
                Country tmp = new Country();
                tmp = search_countries[searchListBox.SelectedIndex];
                listListBox.Items.Add(tmp.ToStringShort());

                list_countries.Add(tmp);
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (listListBox.Items.Count > 0 && listListBox.SelectedIndex >= 0)
            {
                
                list_countries.RemoveAt(listListBox.SelectedIndex);
                selected = false;
                listListBox.Items.RemoveAt(listListBox.SelectedIndex);
                selectedListBox.Items.Clear();
                ImageBox.Source = null;
                
            }
        }

        private void clearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            search_countries.Clear();
            searchListBox.Items.Clear();
            selectedListBox.Items.Clear();
            ImageBox.Source = null;

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            list_countries.Clear();
            listListBox.Items.Clear();
            selectedListBox.Items.Clear();
            ImageBox.Source = null;
            listListBox.IsEnabled = true;
        }
        private void ClearAll()
        {
            
            search_countries.Clear();
            searchListBox.Items.Clear();
            list_countries.Clear();
            listListBox.Items.Clear();
            searchTextBox.Text = "";
            
            selectedListBox.Items.Clear();
            ImageBox.Source = null;
            listListBox.IsEnabled = true;
        }
        private void Load()
        {
            ClearAll();
            if (ofd.ShowDialog() == false)
                return;

            
            
            if (ofd.FileName.Contains(".pdf"))
            {
                StreamReader fs1 = new StreamReader(ofd.FileName);
                listListBox.Items.Add(fs1.ReadToEnd());
                fs1.Close();
                saved = true;
                listListBox.IsEnabled = false;
            }
            else
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                list_countries = (List<Country>)bf.Deserialize(fs);
                fs.Close();
                saved = true;
                for (int i = 0; i < list_countries.Count; i++)
                {
                    listListBox.Items.Add(list_countries[i].ToStringShort());
                }
            }
        }

        private void SaveFull()
        {
            listListBox.IsEnabled = true;
            if (sfd.ShowDialog() == false)
                return;

            if (sfd.FileName.Contains(".pdf"))
            {
                StreamWriter fs1 = new StreamWriter(sfd.FileName);
                for (int i = 0; i < list_countries.Count; i++)
                {
                    fs1.Write(list_countries[i].ToStringLong() + "\r\n");
                }
                fs1.Close();
                saved = true;
            }
            else
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list_countries);
                fs.Close();
                saved = true;
            }
        }
        private void New()
        {
            listListBox.IsEnabled = true;
            MessageBoxResult result;
            if (listListBox.Items.Count > 0)
            {
                result = MessageBox.Show("Save ?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    SaveFull();
                else if (result == MessageBoxResult.No)
                {
                    ClearAll();
                }
            }
        }

    }
}
