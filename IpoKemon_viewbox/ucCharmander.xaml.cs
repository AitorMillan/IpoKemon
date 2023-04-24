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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236


namespace Charmander_UWP_ControlUsuario
{
    public sealed partial class ucCharmander : UserControl
    {

        public const int VIDA_CRITICA = 25;
        public bool componentesCargados = false;
        DispatcherTimer dtTimeVida; //temporizador
        DispatcherTimer dtTimeEnergia;

        public ucCharmander()
        {
            this.InitializeComponent();
            componentesCargados = true;
            movimientoCola();
        }

        public double Vida
        {
            get { return pbVida.Value;  }
            set { pbVida.Value = value; }
        }

        public double Energia
        {
            get { return pbEnergia.Value;}  
            set { pbEnergia.Value = value;}
        }

        public bool HayEscudo
        {
            get { return imgEscudo.Visibility == Visibility.Visible;}
            set
            {
                if (value)
                    imgEscudo.Visibility = Visibility.Visible;
                else
                    imgEscudo.Visibility=Visibility.Collapsed; 
            }
        }

        public void verImagenFondo(bool verImagenFondo) {
            if (verImagenFondo)
                imgFondo.Visibility = Visibility.Visible;
            else
                imgFondo.Visibility = Visibility.Collapsed;
        }

        private void movimientoCola()
        {
            Storyboard sb = (Storyboard)this.Resources["sbMovimientoCola"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }

        private void imgPocionRoja_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeVida = new DispatcherTimer();
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeVida.Tick += increaseHealth;
            dtTimeVida.Start();
            imgPocionRoja.Opacity = 0.5;

        }

        private void increaseHealth(object sender, object e)
        {
            pbVida.Value += 0.2;
            if (pbVida.Value >= 100)
            {
                dtTimeVida.Stop();
                imgPocionRoja.Opacity = 1;
            }
        }



        private void btnEstadoEnfadado_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqRojoKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerRojoKey"];
            sb.Begin();
            sb2.Begin();

        }

        private void pbVida_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (componentesCargados)
            {
                Console.WriteLine("Vida: " + pbVida.Value);
                if (pbVida.Value <= VIDA_CRITICA)
                    cambiarVisibilidad(imgFuegoCola, false);
                else
                    cambiarVisibilidad(imgFuegoCola, true);
            }

        }

        private void cambiarVisibilidad(Image imagen, bool visible)
        {
            Visibility vb = Visibility.Visible;
            if (!visible)
                vb = Visibility.Collapsed;
            try
            {
                imagen.Visibility = vb;

            }
            catch (Exception)
            {
                //Se igonora la excepción
            }


        }

        private void btnQuitarVida_Click(object sender, RoutedEventArgs e)
        {
            pbVida.Value -= 15;

        }

        private void btnActivarEscudo_Click(object sender, RoutedEventArgs e)
        {
            if (imgEscudo.Visibility == Visibility.Collapsed)
                imgEscudo.Visibility = Visibility.Visible;
            else
                imgEscudo.Visibility = Visibility.Collapsed;

        }

        private void btnLanzarBolaFuego_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbBolaFuego"];
            sb.AutoReverse = false;
            sb.Begin();

        }

        private void imgPocionAmarilla_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEnergia.Tick += incrementarEnergia;
            dtTimeEnergia.Start();
            imgPocionAmarilla.Opacity = 0.5;

        }

        private void incrementarEnergia(object sender, object e)
        {
            pbEnergia.Value += 0.2;
            if (pbEnergia.Value >= 100)
            {
                dtTimeEnergia.Stop();
                imgPocionAmarilla.Opacity = 1;
            }
        }

    }

}

