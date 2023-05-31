using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Ayuda : Page
    {
        public Ayuda()
        {
            this.InitializeComponent();
        }
        private async void sonidoAron()
        {
            // Obtenemos la canción, ajustamos su sonido y la reproducimos
            MediaPlayer mediaPlayer = new MediaPlayer();


            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("sonidoAron.ogg");

            mediaPlayer.SetFileSource(file);
            mediaPlayer.Volume = 0.2;
            mediaPlayer.Play();
        }

        private async void sonidoCharmander()
        {
            // Obtenemos la canción, ajustamos su sonido y la reproducimos
            MediaPlayer mediaPlayer = new MediaPlayer();


            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("sonidoCharmander.ogg");

            mediaPlayer.SetFileSource(file);
            mediaPlayer.Volume = 0.2;
            mediaPlayer.Play();
        }

        private async void sonidoGengar()
        {
            // Obtenemos la canción, ajustamos su sonido y la reproducimos
            MediaPlayer mediaPlayer = new MediaPlayer();


            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("sonidoGengar.ogg");

            mediaPlayer.SetFileSource(file);
            mediaPlayer.Volume = 0.2;
            mediaPlayer.Play();
        }

        private void btnAron_Click(object sender, RoutedEventArgs e)
        {
            sonidoAron();
            this.Frame.Navigate(typeof(AyudaAron));
        }

        private void btnCharmander_Click(object sender, RoutedEventArgs e)
        {
            sonidoCharmander();
            this.Frame.Navigate(typeof(AyudaCharmander));
        }

        private void btnGengar_Click(object sender, RoutedEventArgs e)
        {
            sonidoGengar();
            this.Frame.Navigate(typeof(AyudaGengar));
        }
    }
}
