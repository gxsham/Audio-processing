using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SoundManipulation
{
     
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double time1;
        double time2; 
        
        public MainPage()
        {
            this.InitializeComponent();
           
        }

        private async Task<IRandomAccessStream> file_pick()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".mp3");
            openPicker.FileTypeFilter.Add(".wav");
            openPicker.FileTypeFilter.Add(".m4a");
            openPicker.FileTypeFilter.Add(".wma");
            openPicker.FileTypeFilter.Add(".aac");
            StorageFile file = await openPicker.PickSingleFileAsync();
            return await file.OpenAsync(FileAccessMode.Read);
            
           
        }

        private async void Open1_Click(object sender, RoutedEventArgs e)
        {
           
            mediaElement1.SetSource(await file_pick(), "");

        }


        private async void Open2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.SetSource(await file_pick(), "");
        }

        private void Speed1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement1.PlaybackRate = e.NewValue; 
        }

        private void Speed2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement2.PlaybackRate = e.NewValue; 
        }

        private void Pause1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
        }

        private void Play1_Click(object sender, RoutedEventArgs e)
        {
            time1 = mediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
           
            mediaElement1.Play();
          

        }

        private void Stop1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
            Volume1.Value = 0.5;
            Speed1.Value = 1;
            Progress1.Value = 0; 
        }

        private void Pause2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Pause();
            
        }

        private void Play2_Click(object sender, RoutedEventArgs e)
        {
            time2 = mediaElement2.NaturalDuration.TimeSpan.TotalSeconds;
            mediaElement2.Play();
            
            
        }

        private void Stop3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Stop();
            Volume1.Value = 0.5;
            Volume1.Value = 1;
            Progress2.Value = 0; 
        }

        private void Progress1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

            mediaElement1.Position = TimeSpan.FromSeconds((e.NewValue * (time1+0.1)/ 100));
            
           
        }

        private void Progress2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement2.Position = TimeSpan.FromSeconds((e.NewValue * (time2 + 0.1) / 100));

        }

        private void Volume1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement1.Volume = e.NewValue;
        }

        private void Volume2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement2.Volume = e.NewValue; 
        }

        private void Balance1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement1.Balance = e.NewValue; 
        }

        private void Balance2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            mediaElement2.Balance = e.NewValue; 
        }

        private void Metronome1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Source = new Uri("ms-appx:///Assets/60 BPM Metronome.mp3");
        }

        private void Metronome2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Source = new Uri("ms-appx:///Assets/60 BPM Metronome.mp3");
        }
    }
}
