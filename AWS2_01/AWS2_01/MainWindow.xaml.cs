using System;
using System.Collections.Generic;
using System.IO;
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


namespace AWS2_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DetectingUnsafeContent_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DetectingUnsafeContent();
        }

        private void FindTextInImage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new FindTextInImage();
        }

        private void TranslatePage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Translate();
        }

        private void TextToSpeech_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TextToSpeech();
        }
    }
}
