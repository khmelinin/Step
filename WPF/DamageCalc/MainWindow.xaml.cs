using Microsoft.Win32;
using System;
using System.IO;
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
using System.Runtime.Serialization.Formatters.Binary;

namespace DamageCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int math_rounding = 4;
        int selected = -1;
        double hp = -1;
        double multiplayer = 1;
        double dmg = -1;
        double rpm = -1;

        double ttk = -1;
        double rtk = -1;
        double dps = -1;

        SaveFileDialog sfd;
        OpenFileDialog ofd;

        bool ok = true;

        List<Weapon> weapons;
        public MainWindow()
        {
            InitializeComponent();

            weapons = new List<Weapon>();

            math_roundingLabel.IsEnabled = false;
            math_roundingLabel.Visibility = Visibility.Hidden;
            math_roundingTextBox.IsEnabled = false;
            math_roundingTextBox.Visibility = Visibility.Hidden;
            math_roundingButton.IsEnabled = false;
            math_roundingButton.Visibility = Visibility.Hidden;

            sfd = new SaveFileDialog();
            sfd.Filter = "App files(*.dmgc)|*.dmgc|Text files(*.txt)|*.txt|All files(*.*)|*.*";

            ofd = new OpenFileDialog();
            ofd.Filter = "App files(*.dmgc)|*.dmgc|Text files(*.txt)|*.txt|All files(*.*)|*.*";

            //###########################//
            rpsCheckBox.IsEnabled = false;
            rpsCheckBox.Visibility = Visibility.Hidden;
            //###########################//

        }

        // Clear

        private void Clear()
        {
            //hpTextBox.Text = "";
            multiplayerTextBox.Text = "1";
            damageTextBox.Text = "";
            rpmTextBox.Text = "";
            ttkTextBox.Text = "";
            rtkTextBox.Text = "";
            dpsTextBox.Text = "";
            nameTextBox.Text = "";

            multiplayer = 1;
            dmg = -1;
            rpm = -1;

            ttk = -1;
            rtk = -1;
            dps = -1;
        }

        // Calculating

        private void Calc_Button_Click(object sender, RoutedEventArgs e)
        {
            if(damageTextBox.Text!="" && hpTextBox.Text !="" && rpmTextBox.Text!="" && rpsCheckBox.IsChecked==false)
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rpm);
                Double.TryParse(multiplayerTextBox.Text, out multiplayer);

                rtk = Math.Ceiling(hp * multiplayer / dmg);
                ttk = Math.Round((1 / (rpm / 60)) * rtk, math_rounding);
                dps = Math.Round(((rpm / 60) * dmg), math_rounding);

                ttkTextBox.Text = ttk.ToString();
                rtkTextBox.Text = rtk.ToString();
                dpsTextBox.Text = dps.ToString();
            }
            else
            if (damageTextBox.Text != "" && hpTextBox.Text != "" && rpmTextBox.Text != "" && rpsCheckBox.IsChecked == true)
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rpm);
                Double.TryParse(multiplayerTextBox.Text, out multiplayer);

                rtk = Math.Ceiling(hp * multiplayer / dmg);
                ttk = Math.Round((1 / (rpm / 60)) * rtk, math_rounding);
                dps = (rpm * dmg);

                ttkTextBox.Text = (Math.Round(ttk, math_rounding)).ToString();
                rtkTextBox.Text = rtk.ToString();
                dpsTextBox.Text = dps.ToString();
            }
        }

        private void rpsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            RPM_label.Content = "RPS";
        }

        private void rpsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            RPM_label.Content = "RPM";
        }

        /*
        private void hp100button_Click(object sender, RoutedEventArgs e)
        {
            hpTextBox.Text = "100";
        }

        private void hp200button_Click(object sender, RoutedEventArgs e)
        {
            hpTextBox.Text = "200";
        }

        private void hp300button_Click(object sender, RoutedEventArgs e)
        {
            hpTextBox.Text = "300";
        }
        */

        // List Buttons

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Calc_Button_Click(sender, e);
            if (nameTextBox.Text != "" && hpTextBox.Text!="" && multiplayerTextBox.Text!="" && damageTextBox.Text!="" && rpmTextBox.Text!="" && ttkTextBox.Text!="" && dpsTextBox.Text!="")
            {
                Weapon tmp = new Weapon(nameTextBox.Text, hp, multiplayer, dmg, rpm, ttk, rtk, dps);
                weapons.Add(tmp);
                listBox1.Items.Add(tmp.ToStringShort());
                Clear();
            }
            
        }
        private void Del_Button_Click(object sender, RoutedEventArgs e)
        {
            ok = false;
            if (listBox1.SelectedIndex > -1)
            {
                weapons.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                Clear();
                listBox2.Items.Clear();
            }
            ok = true;
        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            ok = false;
            Calc_Button_Click(sender, e);
            if (selected!=-1 && nameTextBox.Text != "" && hpTextBox.Text != "" && multiplayerTextBox.Text!="" && damageTextBox.Text != "" && rpmTextBox.Text != "" && ttkTextBox.Text != "" && dpsTextBox.Text != "")
            {
                Weapon tmp = new Weapon(nameTextBox.Text, hp, multiplayer, dmg, rpm, ttk, rtk, dps);
                weapons[selected] = tmp;
                listBox1.Items[selected] = tmp.ToStringShort();
                Clear();
                listBox2.Items.Clear();
            }

            selected = -1;
            ok = true;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ok && listBox1.Items.Count>0)
            {
                selected = listBox1.SelectedIndex;

                if (listBox2.Items.Count > 0)
                    listBox2.Items.RemoveAt(0);
                listBox2.Items.Add(weapons[listBox1.SelectedIndex].ToString());


                hp = weapons[listBox1.SelectedIndex].Hp;
                multiplayer = weapons[listBox1.SelectedIndex].Multiplayer;
                dmg = weapons[listBox1.SelectedIndex].Dmg;
                rpm = weapons[listBox1.SelectedIndex].Rpm;
                ttk = weapons[listBox1.SelectedIndex].Ttk;
                rtk = weapons[listBox1.SelectedIndex].Rtk;
                dps = weapons[listBox1.SelectedIndex].Dps;

                nameTextBox.Text = weapons[listBox1.SelectedIndex].Name;
                hpTextBox.Text = hp.ToString();
                multiplayerTextBox.Text = multiplayer.ToString();
                damageTextBox.Text = dmg.ToString();
                rpmTextBox.Text = rpm.ToString();
                ttkTextBox.Text = ttk.ToString();
                rtkTextBox.Text = rtk.ToString();
                dpsTextBox.Text = dps.ToString();
            }
            
        }

        private void devOptionsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            math_roundingLabel.IsEnabled = true;
            math_roundingLabel.Visibility = Visibility.Visible;

            math_roundingTextBox.IsEnabled = true;
            math_roundingTextBox.Visibility = Visibility.Visible;

            math_roundingButton.IsEnabled = true;
            math_roundingButton.Visibility = Visibility.Visible;
        }

        private void devOptionsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            math_roundingLabel.IsEnabled = false;
            math_roundingLabel.Visibility = Visibility.Hidden;

            math_roundingTextBox.IsEnabled = false;
            math_roundingTextBox.Visibility = Visibility.Hidden;

            math_roundingButton.IsEnabled = false;
            math_roundingButton.Visibility = Visibility.Hidden;
        }

        private void math_roundingButton_Click(object sender, RoutedEventArgs e)
        {
            if(math_roundingTextBox.Text!="")
            {
                Int32.TryParse(math_roundingTextBox.Text, out math_rounding);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sfd.ShowDialog() == false)
                return;
            FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, weapons);
            fs.Close();
            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            if (ofd.ShowDialog() == false)
                return;
            listBox2.Items.Clear();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            weapons = (List<Weapon>)bf.Deserialize(fs);
            fs.Close();
            listBox1.Items.Clear();
            for (int i = 0; i < weapons.Count; i++)
            {
                listBox1.Items.Add(weapons[i].ToStringShort());
            }
        }

        private void qestioButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "HP - health points\r\n" +
                "MULTIPLAYER - health points multiplayer\r\n" +
                "DMG - damage\r\n" +
                "RPM - rounds per minute\r\n" +
                "TTK - time to kill\r\n" +
                "RTK - rounds to kill\r\n" +
                "DPS - damage per second\r\n" +
                "Name - weapon name",
                "Help", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}
