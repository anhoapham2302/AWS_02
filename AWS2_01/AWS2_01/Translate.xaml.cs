using Amazon.Translate;
using Amazon.Translate.Model;
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


namespace AWS2_01
{
    /// <summary>
    /// Interaction logic for Translate.xaml
    /// </summary>
    public partial class Translate : Page
    {
        public Translate()
        {
            InitializeComponent();
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            var accessKey = "AKIAUBMTEBYUP272NQGE";
            var secretKey = "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";

            var client = new AmazonTranslateClient();
            var request = new TranslateTextRequest
            {
                Text = MyTextBox.Text,
                SourceLanguageCode = "en",
                TargetLanguageCode = "vi",
            };
            var respone = client.TranslateText(request);
            MyLable.Content = respone.TranslatedText;       
        }
    }
}
