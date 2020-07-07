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

namespace DamageCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Weapon
    {
        string name;
        double hp = -1;
        double dmg = -1;
        double rpm = -1;

        double ttk = -1;
        double dps = -1;

        public Weapon(string name, double hp, double dmg, double rpm, double ttk, double dps)
        {
            this.name = name;
            this.hp = hp;
            this.dmg = dmg;
            this.rpm = rpm;
            this.ttk = ttk;
            this.dps = dps;
        }

        public double Hp { get => hp; set => hp = value; }
        public double Dmg { get => dmg; set => dmg = value; }
        public double Rpm { get => rpm; set => rpm = value; }
        public double Ttk { get => ttk; set => ttk = value; }
        public double Dps { get => dps; set => dps = value; }
        public string Name { get => name; set => name = value; }

        public string ToStringShort()
        {
            return "|"+name + "| dmg=" + dmg.ToString() + " rpm=" + rpm.ToString();
        }

        public override string ToString()
        {
            return name + "\r\ndmg=" + dmg.ToString() + " rpm=" + rpm.ToString() + " (with hp=" + hp.ToString() + " ttk=" + ttk.ToString() + " dps=" + dps.ToString() + ")";
        }
    }
    public partial class MainWindow : Window
    {
        double hp = -1;
        double dmg = -1;
        double rpm = -1;

        double ttk = -1;
        double dps = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(damageTextBox.Text!="" && hpTextBox.Text !="" && rpmTextBox.Text!="" && rpsCheckBox.IsChecked==false)
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rpm);

                ttk = (1 / (rpm / 60)) * Math.Round(hp/dmg);
                dps = ((rpm / 60) * dmg);

                ttkTextBbox.Text = (Math.Round(ttk,13)).ToString();
                dpsTextBbox.Text = (Math.Round(dps, 13)).ToString();
            }
            else
            if (damageTextBox.Text != "" && hpTextBox.Text != "" && rpmTextBox.Text != "" && rpsCheckBox.IsChecked == true)
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rpm);

                ttk = (1 / rpm) * Math.Round(hp / dmg);
                dps = (rpm * dmg);

                ttkTextBbox.Text = (Math.Round(ttk, 13)).ToString();
                dpsTextBbox.Text = dps.ToString();
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

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                listBox1.Items.Add(new Weapon(nameTextBox.Text, hp, dmg, rpm, ttk, dps).ToStringShort());
            }
        }
        private void Del_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
