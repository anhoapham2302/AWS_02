using Amazon.Rekognition;
using Amazon.Rekognition.Model;
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
using Label = System.Windows.Controls.Label;

namespace AWS2_01
{
    /// <summary>
    /// Interaction logic for FindTextInImage.xaml
    /// </summary>
    public partial class FindTextInImage : Page
    {
        public FindTextInImage()
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
        private void FindText_Click(object sender, RoutedEventArgs e)
        {
            var source = ToBytesStream(@"C:\Users\A715-72\Desktop\cnm\AWS2_01\AWS2_01\img\page2\1.jpg");

            var client = new AmazonRekognitionClient();
            var request = new DetectTextRequest
            {
                Image = source
            };

            var respone = client.DetectText(request);
            var n = 360;
            foreach (var label in respone.TextDetections)
            {
                Label lb = new Label
                {
                    Content = label.DetectedText,
                    FontSize = 15,
                    Margin = new Thickness(100, n, 0, 0)
                };
                n = n + 20;
                canvas.Children.Add(lb);
            }
        }
    }
}
