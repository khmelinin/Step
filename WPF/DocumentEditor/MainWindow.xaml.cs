using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DocumentEditor
{
    internal sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bold_button(object sender, RoutedEventArgs e)
        {
            TextBlock1.FontWeight = FontWeights.Bold;
        }

        private void Italic_button(object sender, RoutedEventArgs e)
        {
            TextBlock1.FontStyle = FontStyles.Italic;
        }

        private void Underline_button(object sender, RoutedEventArgs e)
        {
            TextBlock1.TextDecorations = TextDecorations.Underline;
        }

        private void Clear_button(object sender, RoutedEventArgs e)
        {
            TextBlock1.TextDecorations = null;
            TextBlock1.FontSize = 13;
            TextBlock1.FontWeight = FontWeights.Normal;
            TextBlock1.Foreground = Brushes.Black;
            TextBlock1.FontStyle = FontStyles.Normal;
        }

        private void Color_combobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch(Color_combobox.SelectedIndex)
            {
                case 0:
                    TextBlock1.Foreground = Brushes.Black;
                    break;
                case 1:
                    TextBlock1.Foreground = Brushes.Blue;
                    break;
                case 2:
                    TextBlock1.Foreground = Brushes.Green;
                    break;
                case 3:
                    TextBlock1.Foreground = Brushes.Orange;
                    break;
                case 4:
                    TextBlock1.Foreground = Brushes.Purple;
                    break;
                case 5:
                    TextBlock1.Foreground = Brushes.Red;
                    break;
                case 6:
                    TextBlock1.Foreground = Brushes.Yellow;
                    break;
            }
        }

        private void Font_combobox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            TextBlock1.FontSize = (Font_combobox.SelectedIndex+4)*2;
        }
    }
}