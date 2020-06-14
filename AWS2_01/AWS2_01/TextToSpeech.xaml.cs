using Amazon.Polly;
using Amazon.Polly.Model;
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
    /// Interaction logic for TextToSpeech.xaml
    /// </summary>
    public partial class TextToSpeech : Page
    {
        public TextToSpeech()
        {
            InitializeComponent();
        }
        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            var client = new AmazonPollyClient();
            var request = new SynthesizeSpeechRequest
            {
                Text = MyTextBox.Text,
                OutputFormat = OutputFormat.Mp3,
                VoiceId = VoiceId.Mia
            };

            var response = client.SynthesizeSpeech(request);

            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var filename = $"{folder}{Guid.NewGuid()}.mp3";

            using (var fs = File.Create(filename))
            {
                response.AudioStream.CopyTo(fs);
                fs.Flush();
                fs.Close();
            }

            var player = new MediaPlayer();
            player.Open(new Uri(filename, UriKind.Absolute));
            player.MediaEnded += (s2, e2) => Title = "Player ended";
            player.Play();
            Title = "Playing audio...";
        }
    }
}
