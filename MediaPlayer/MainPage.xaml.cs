using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MediaPlayer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        const int REWIND_MILISECONDS = 2;
        const String URL_STREAM_VIDEO = "http://kona2.alc.upv.es/video/2016-06-16_Incendi%20Carcaixent%20i%20Terrateig.mp4";
        const String URL_LOCAL_VIDEO = "ms-appx:///Video/caballeros.mp4";
        public MainPage()
        {
            this.InitializeComponent();
            mediaPlayer.IsFullWindow = true;
            mediaPlayer.AreTransportControlsEnabled = true;
        }

        private void stopButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }


        private void playButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void forwardButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, REWIND_MILISECONDS);
            mediaPlayer.Position = mediaPlayer.Position.Add(timeSpan);
        }

        private void backButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, -REWIND_MILISECONDS);
            mediaPlayer.Position = mediaPlayer.Position.Add(timeSpan);
        }

        private void onTappedChangeVideoMethodButton(object sender, TappedRoutedEventArgs e)
        {
            Button currentTappedBtn = sender as Button;

            mediaPlayer.Stop();
            if (currentTappedBtn.Name.Equals("localVideoButton"))
            {
                
                LoadVideo(URL_LOCAL_VIDEO);
            }else
            {
                LoadVideo(URL_STREAM_VIDEO);
            }
            mediaPlayer.Play();
        }



        private void LoadVideo(String name)
        {
            try
            {
                Uri pathUri = new Uri(name);
                mediaPlayer.Source = pathUri;
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
       
                }
            }
        }
    }
}
