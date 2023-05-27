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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IpoKemon_viewbox
{
    public sealed partial class AronCU : UserControl
    {
        DispatcherTimer miReloj;
        DispatcherTimer relojAnimaciones;
        Storyboard idle;
        Storyboard cansado;
        public AronCU()
        {
            this.InitializeComponent();
            miReloj = new DispatcherTimer();
            relojAnimaciones = new DispatcherTimer();

            idle = (Storyboard)this.Resources["sbIdle"];
            cansado = (Storyboard)this.Resources["sbCansado"];
            cansado.AutoReverse = true; 
            idle.AutoReverse = true;
            idle.RepeatBehavior = RepeatBehavior.Forever;
            idle.Begin();
        }
       /* public void verNombre(bool verNombre)
        {
            if (!verNombre)
                this.txtBNombre.Visibility = Visibility.Collapsed;
            else
            {
                this.txtBNombre.Visibility = Visibility.Visible;
            }
        }*/
        private void Pupila_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbOjo"];
            sb.AutoReverse = true;
            sb.Begin();
        }
       /* public void verFondo(bool verFondo)
        {
            if (!verFondo)
                this.imgFondo.Source = null;
            else
                this.imgFondo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Imagen fondo.jpg", UriKind.RelativeOrAbsolute));
        }*/

        private void tocarEspalda(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbSonrojado"];
            sb.AutoReverse = true;
            sb.Begin();
        }
    }
}
