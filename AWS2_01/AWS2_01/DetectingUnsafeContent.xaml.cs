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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Image = System.Windows.Controls.Image;
using Label = System.Windows.Controls.Label;

namespace AWS2_01
{
    /// <summary>
    /// Interaction logic for DetectingUnsafeContent.xaml
    /// </summary>
    public partial class DetectingUnsafeContent : Page
    {
        public DetectingUnsafeContent()
        {
            InitializeComponent();
        }

        static Amazon.Rekognition.Model.Image ToBytesStream(string filename)
        {
            var image = new Amazon.Rekognition.Model.Image();
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                var data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                image.Bytes = new MemoryStream(data);
            }
            return image;
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            var source = ToBytesStream(@"C:\Users\A715-72\Desktop\cnm\AWS2_01\AWS2_01\img\page1\2.jpg");

            var client = new AmazonRekognitionClient();
            var request = new DetectModerationLabelsRequest
            {
                Image = source
            };

            var respone = client.DetectModerationLabels(request);
            var n = 360;
            foreach (var label in respone.ModerationLabels)
            {
                Label lb = new Label
                {
                    Content = label.Name,
                    FontSize = 15,
                    Margin = new Thickness(100, n, 0, 0)
                };
                n = n + 20;
                canvas.Children.Add(lb);
            }


            //myLabel.Content = respone.ModerationLabels;

        }
    }
}
