using Charmander_UWP_ControlUsuario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using System.Threading.Tasks;
using Windows.Devices.Radios;
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

    public sealed partial class AronCU_NoViewBox : UserControl
    {
        private double INCREMENTOVIDA = 25;
        private double vidaASubir;
        DispatcherTimer miReloj;
        DispatcherTimer relojAnimaciones;
        Storyboard idle;
        private int danioAtaqueCabeza = 15;
        private int danioGolpeCuerpo = 20;
        public delegate void AtaqueRealizadoEventHandler(object sender, AtaqueEventArgs e);
        public event AtaqueRealizadoEventHandler AtaqueRealizado;
        public event EventHandler AccionRealizada;
        bool estaCansado;
        bool energico;
        public AronCU_NoViewBox()
        {
            this.InitializeComponent();
            miReloj = new DispatcherTimer();
            relojAnimaciones = new DispatcherTimer();

            idle = (Storyboard)this.Resources["sbIdle"];
            estaCansado = false;
            energico = false;
            idle.AutoReverse = true;
            idle.RepeatBehavior = RepeatBehavior.Forever;
            idle.Begin();
        }

        public void recibirDaño(int daño)
        {
            ataqueRecibido(daño);
        }

        public void ocultarDatosCombate()
        {
            verPocionEnergia(false);
            verPocionVida(false);
            verNombre(false);
            verImagenFondo(false);
            verBotonAtqueCabezaEnf(false);
        }
        public void ataqueCabeza()
        {
            int danioAtaque = danioAtaqueCabeza;
            if (energico)
                danioAtaque = (int)Math.Round(danioAtaqueCabeza * 1.5);
            else if (estaCansado)
                danioAtaque = 10;

            ataqueCabeza(danioAtaque);
        }
        public void ataqueCuerpo()
         {
             int danioAtaque = danioGolpeCuerpo;
             if (energico)
             {
                 danioAtaque = danioGolpeCuerpo * 2;
             }
             else if (estaCansado)
            {
                    danioAtaque = danioGolpeCuerpo / 2;
            }
             ataqueCuerpo(danioAtaque);
        }
        public void curarse()
        {
            imgPocionVida_PointerReleased(null, null);
        }
        private void OnAtaqueRealizado(AtaqueEventArgs e)
        {
            AtaqueRealizado?.Invoke(this, e);
        }

        public void restaurarEnergia()
        {
            imgPocionEnergia_PointerReleased(null, null);
        }

        private void OnAccionRealizada()
        {
            AccionRealizada?.Invoke(this, EventArgs.Empty);
        }
        public void invertirPokemon()
        {
            cvAron.RenderTransform = new ScaleTransform() { ScaleX = -1 };
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

        public void verImagenFondo(bool verImagenFondo) {
            if (!verImagenFondo)
                this.imgFondo.Source = null;
            else
                this.imgFondo.Source = new BitmapImage(new Uri("ms-appx:///Assests/Imagen fondo.png", UriKind.RelativeOrAbsolute));
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
        public void verBotonAtqueCabezaEnf(bool verBotonAtqueCabezaEnf)
        {
            if (!verBotonAtqueCabezaEnf)
                this.btnAtaqueCabezaEnfadado.Visibility = Visibility.Collapsed;
            else
                this.btnAtaqueCabezaEnfadado.Visibility = Visibility.Visible;
        }

        public void verNombre(bool verNombre)
        {
            if (!verNombre)
                this.txtBNombre.Visibility = Visibility.Collapsed;
            else
                this.txtBNombre.Visibility = Visibility.Visible;
        }
        private void imgPocionVida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            vidaASubir = pbVida.Value + INCREMENTOVIDA;
            miReloj.Interval = TimeSpan.FromMilliseconds(100);
            miReloj.Tick += subirVida;
            miReloj.Start();
            imgPocionVida.Opacity = 0.1;
        }
        private void subirVida(object sender, object e)
        {
            pbVida.Value += 1;
            double vidaActual = pbVida.Value;
            if (vidaActual == vidaASubir || (vidaActual == 100 && vidaASubir > 100))
            {
                OnAccionRealizada();
                miReloj.Tick -= subirVida;
                miReloj.Stop();
                imgPocionVida.Opacity = 1;
            }
        }
        private void subirEnergia(object sender, object e)
        {
            pbEnergia.Value += 1;
            double energiaActual = pbEnergia.Value;
            if (pbEnergia.Value > 50 && estaCansado )
            {
                Storyboard sb = (Storyboard)this.Resources["sbRecuperaEnergia"];
                sb.AutoReverse = false;
                sb.Begin();
                estaCansado = false;
            }
            else if (pbEnergia.Value >= 80 && !energico)
            {
                Storyboard sb = (Storyboard)this.Resources["sbEnergico"];
                sb.AutoReverse = false;
                sb.Begin();
                energico = true;
            }
            else if (pbEnergia.Value >= 100)
            {
                miReloj.Tick -= subirEnergia;
                miReloj.Stop();
                imgPocionEnergia.Opacity = 1;
                OnAccionRealizada();
            }
        }
        private void bajarEnergia(object sender, object e)
        {
            pbEnergia.Value -= 0.5;
            if ((pbEnergia.Value % 10) == 0)
            {
                miReloj.Stop();
                miReloj.Tick -= bajarEnergia;
                idle.Resume();
                if (pbEnergia.Value <= 50 && !estaCansado)
                {
                    Storyboard sb = (Storyboard)this.Resources["sbCansado"];
                    sb.AutoReverse = false;
                    sb.Begin();
                    estaCansado = true;
                }
                else if (pbEnergia.Value <= 90 && energico)
                {
                    energico = false;
                    Storyboard sb = (Storyboard)this.Resources["sbNoEnergico"];
                    sb.AutoReverse = false;
                    sb.Begin();
                }
            }
        }

        private void imgPocionEnergia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            miReloj.Interval = TimeSpan.FromMilliseconds(100);
            miReloj.Tick += subirEnergia;
            miReloj.Start();
            imgPocionEnergia.Opacity = 0.1;

        }

        private void Pupila_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!estaCansado)
            {
                Storyboard sb = (Storyboard)this.Resources["sbOjo"];
                sb.AutoReverse = true;
                sb.Begin();
            }
        }


        private async void ataqueCabeza(int danioAtaque)
        {
            idle.Pause();
            miReloj.Interval = TimeSpan.FromMilliseconds(100);
            miReloj.Tick += bajarEnergia;
            miReloj.Start();
            if (!estaCansado)
            {
                Storyboard sb = (Storyboard)this.Resources["sbAtaqueCabeza"];
                sb.AutoReverse = false;
                sb.Begin();
            }
            else
            {
                Storyboard sb = (Storyboard)this.Resources["sbAtaqueCabezaCansado"];
                sb.AutoReverse = false;
                sb.Begin();
            }
            await Task.Delay(3000);
            OnAtaqueRealizado(new AtaqueEventArgs(danioAtaque));
        }

        private void btnAtaqueCabezaEnfadado_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbAtaqueCabeza"];
            sb.AutoReverse = false;
            sb.Begin();
            Storyboard sbOjo = (Storyboard)this.Resources["sbOjo"];
            sbOjo.AutoReverse = true;
            sbOjo.Begin();
        }

        private void tocarEspalda(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbSonrojado"];
            sb.AutoReverse = true;
            sb.Begin();
        }

        private async void ataqueCuerpo(int danioAtaque)
        {
            idle.Pause();
            miReloj.Interval = TimeSpan.FromMilliseconds(100);
            miReloj.Tick += bajarEnergia;
            miReloj.Start();
            Storyboard sb = (Storyboard)this.Resources["sbAtaqueCuerpo"];
            sb.AutoReverse = true;
            sb.Begin();
            await Task.Delay(3400);
            OnAtaqueRealizado(new AtaqueEventArgs(danioAtaque));
        }
        private void ataqueRecibido(int daño)
        {
            pbVida.Value -= daño;
            idle.Pause();
            Storyboard sb = (Storyboard)this.Resources["sbRecibirAtaque"];
            sb.AutoReverse = false;
            sb.Begin();
        }
    }
}
