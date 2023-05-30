using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
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
    public sealed partial class Configuración : Page
    {
        public Configuración()
        {
            this.InitializeComponent();
        }
        private async void hplEspaña_Click(object sender, RoutedEventArgs e)
        {
            //Cambiar idioma a español
            ApplicationLanguages.PrimaryLanguageOverride = "es-ES";

            await Task.Delay(1);

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame?.Navigate(typeof(MainPage));

            //Reiniciar la aplicación para que el cambio de idioma tenga efecto
            //CoreApplication.GetCurrentView().Reload();
        }

        private async void hplIngles_Click(object sender, RoutedEventArgs e)
        {
            //Cambiar idioma a inglés
            ApplicationLanguages.PrimaryLanguageOverride = "en-US";
            
            await Task.Delay(1);
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame?.Navigate(typeof(MainPage));
        }
    }
}
