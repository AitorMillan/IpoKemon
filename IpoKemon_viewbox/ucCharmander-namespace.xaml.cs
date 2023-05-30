using IpoKemon_viewbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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


    public sealed partial class ucCharmander_namespace : UserControl
    {
        private double INCREMENTOVIDA = 25;
        private double vidaASubir;
        private int danio = 15;
        private bool estaEnfadado = false;
        private bool escudoActivado = false;
        public delegate void AtaqueRealizadoEventHandler(object sender, AtaqueEventArgs e);
        public event AtaqueRealizadoEventHandler AtaqueRealizado;
        public event EventHandler AccionRealizada;
        public const int VIDA_CRITICA = 25;
        public bool componentesCargados = false;
        DispatcherTimer dtTimeVida; //temporizador
        DispatcherTimer dtTimeEnergia;

        public ucCharmander_namespace()
        {
            this.InitializeComponent();
            componentesCargados = true;
            movimientoCola();
        }
        private void OnAtaqueRealizado(AtaqueEventArgs e)
        {
            AtaqueRealizado?.Invoke(this, e);
        }
        private void OnAccionRealizada()
        {
            AccionRealizada?.Invoke(this, EventArgs.Empty);
        }

        public void ocultarDatosCombate()
        {
            verPocionEnergia(false);
            verPocionVida(false);
            verBotonActivarEscudo(false);
            verNombre(false);
            verImagenFondo(false);
        }


        public void recibirDaño(int daño)
        {
            if (escudoActivado)
            {
                escudoActivado = false;
                btnActivarEscudo_Click(null, null);
            }
            else 
            {
                pbVida.Value -= daño;
            }

        }
        public void enfadado()
        {
            if (escudoActivado)
            {
                btnActivarEscudo_Click(null, null);
                escudoActivado = false;
            }
            estadoEnfadado();
            estaEnfadado = true;
        }

        public void curarse()
        {
            if (estaEnfadado)
                estaEnfadado = false;

            if (escudoActivado)
            {
                btnActivarEscudo_Click(null, null);
                escudoActivado = false;
            }
            imgPocionVida_PointerReleased(null, null);
            
        }

        public void activarEscudo()
        {
            if(estaEnfadado)
                estaEnfadado = false;

            if (escudoActivado)
            {
                btnActivarEscudo_Click(null, null); //para desactivarlo
                //escudoActivado = false;
            }
                

            btnActivarEscudo_Click(null, null);
            escudoActivado = true;
            OnAccionRealizada();
        }
        public void atacar()
        {
            if (escudoActivado)
            {
                btnActivarEscudo_Click(null, null);
                escudoActivado = false;
            }
            int danioAtaque = danio;
            if (estaEnfadado)
            {
                danioAtaque = danio * 2;
                estaEnfadado = false;
            }
            lanzarBolaFuego(danioAtaque);
        }
        public void invertirPokemon()
        {
            cvPrincipal.RenderTransform = new ScaleTransform() { ScaleX = -1 };
        }
        public double Vida
        {
            get { return pbVida.Value; }
            set { pbVida.Value = value; }
        }

        public double Energia
        {
            get { return pbEnergia.Value; }
            set { pbEnergia.Value = value; }
        }

        public bool HayEscudo
        {
            get { return imgEscudo.Visibility == Visibility.Visible; }
            set
            {
                if (value)
                    imgEscudo.Visibility = Visibility.Visible;
                else
                    imgEscudo.Visibility = Visibility.Collapsed;
            }
        }

        public void soloVerPokemon()
        {
            verBarraVida(false);
            verBarraEnergia(false);
            verImagenVida(false);
            verImagenEnergia(false);
            verPocionVida(false);
            verPocionEnergia(false);
            //ocultar botones
            verBotonActivarEscudo(false);
            verNombre(false);

        }

        public void verBarraVida(bool verBarraVida)
        {
            if (!verBarraVida)
                this.pbVida.Visibility = Visibility.Collapsed;
            else
                this.pbVida.Visibility = Visibility.Visible;
        }

        public void verBarraEnergia(bool verBarraEnergia)
        {
            if (!verBarraEnergia)
                this.pbEnergia.Visibility = Visibility.Collapsed;
            else
                this.pbEnergia.Visibility = Visibility.Visible;
        }
        public void verImagenVida(bool verImagenVida)
        {
            if (!verImagenVida)
                this.imgVida.Source = null;
            else
                this.imgVida.Source = new BitmapImage(new Uri("ms-appx:///Assets/Vida.png", UriKind.RelativeOrAbsolute));
        }
        public void verImagenEnergia(bool verImagenEnergia)
        {
            if (!verImagenEnergia)
                this.imgEnergia.Source = null;
            else
                this.imgEnergia.Source = new BitmapImage(new Uri("ms-appx:///Assets/Energia.png", UriKind.RelativeOrAbsolute));
        }
        public void verPocionVida(bool verPocionVida)
        {
            if (!verPocionVida)
                this.imgPocionVida.Source = null;
            else
                this.imgPocionVida.Source = new BitmapImage(new Uri("ms-appx:///Assets/PocionVida.png", UriKind.RelativeOrAbsolute));
        }
        public void verPocionEnergia(bool verPocionEnergia)
        {
            if (!verPocionEnergia)
                this.imgPocionEnergia.Source = null;
            else
                this.imgPocionEnergia.Source = new BitmapImage(new Uri("ms-appx:///Assets/PocionEnergia.png", UriKind.RelativeOrAbsolute));
        }

        public void verBotonActivarEscudo(bool verBotonActivarEscudo)
        {
            if (!verBotonActivarEscudo)
                this.btnActivarEscudo.Visibility = Visibility.Collapsed;
            else
                this.btnActivarEscudo.Visibility = Visibility.Visible;
        }
        public void verImagenFondo(bool verImagenFondo)
        {
            if (verImagenFondo)
                imgFondo.Visibility = Visibility.Visible;
            else
                imgFondo.Visibility = Visibility.Collapsed;
        }

        public void verNombre(bool verNombre)
        {
            if (!verNombre)
                this.txtBNombre.Visibility = Visibility.Collapsed;
            else
                this.txtBNombre.Visibility = Visibility.Visible;
        }

        private void movimientoCola()
        {
            Storyboard sb = (Storyboard)this.Resources["sbMovimientoCola"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }

        private void imgPocionVida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeVida = new DispatcherTimer();
            vidaASubir = pbVida.Value + INCREMENTOVIDA;
            dtTimeVida.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeVida.Tick += increaseHealth;
            dtTimeVida.Start();
            imgPocionVida.Opacity = 0.5;

        }

        private void increaseHealth(object sender, object e)
        {
            pbVida.Value += 1;
            double vidaActual = pbVida.Value;
            if (vidaActual == vidaASubir || (vidaActual == 100 && vidaASubir>100))
            {
                OnAccionRealizada();
                dtTimeVida.Tick -= increaseHealth;
                dtTimeVida.Stop();
                imgPocionVida.Opacity = 1;
            }
        }

        private async void estadoEnfadado()
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqRojoKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerRojoKey"];
            sb.Begin();
            sb2.Begin();
            await Task.Delay(3000);
            OnAccionRealizada();
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

        private void btnActivarEscudo_Click(object sender, RoutedEventArgs e)
        {
            if (imgEscudo.Visibility == Visibility.Collapsed)
                imgEscudo.Visibility = Visibility.Visible;
            else
                imgEscudo.Visibility = Visibility.Collapsed;

        }

        private async void lanzarBolaFuego(int danioAtaque)
        {
            Storyboard sb = (Storyboard)this.Resources["sbBolaFuego"];
            sb.AutoReverse = false;
            sb.Begin();
            await Task.Delay(2500);
            OnAtaqueRealizado(new AtaqueEventArgs(danioAtaque));
        }

        private void imgPocionEnergia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtTimeEnergia = new DispatcherTimer();
            dtTimeEnergia.Interval = TimeSpan.FromMilliseconds(100);
            dtTimeEnergia.Tick += incrementarEnergia;
            dtTimeEnergia.Start();
            imgPocionEnergia.Opacity = 0.5;

        }

        private void incrementarEnergia(object sender, object e)
        {
            pbEnergia.Value += 0.2;
            if (pbEnergia.Value >= 100)
            {
                dtTimeEnergia.Stop();
                imgPocionEnergia.Opacity = 1;
            }
        }
    }

}