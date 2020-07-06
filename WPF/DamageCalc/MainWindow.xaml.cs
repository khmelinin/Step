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
    public partial class MainWindow : Window
    {
        double hp = -1;
        double dmg = -1;
        double rpm = -1;
        double rps = -1;

        double ttk = -1;
        double dps = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(damageTextBox.Text!="" && hpTextBox.Text!="" && rpmTextBox.Text!="")
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rpm);

                ttk = (1 / (rpm / 60)) * Math.Round(hp/dmg);
                dps = ((rpm / 60) * dmg);
            }
            else
            if (damageTextBox.Text != "" && hpTextBox.Text != "" && rpsTextBox.Text != "")
            {
                Double.TryParse(hpTextBox.Text, out hp);
                Double.TryParse(damageTextBox.Text, out dmg);
                Double.TryParse(rpmTextBox.Text, out rps);

                ttk = (1 / (rps / 60)) * Math.Round(hp / dmg);
                dps = (rps * dmg);
            }
        }
    }
}
