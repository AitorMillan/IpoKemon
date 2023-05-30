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

    public sealed partial class gengarUC_namespace : UserControl
    {
        DispatcherTimer HealingDT;
        DispatcherTimer dtPokeball;
        public delegate void AtaqueRealizadoEventHandler(object sender, AtaqueEventArgs e);
        public event AtaqueRealizadoEventHandler AtaqueRealizado;
        public event EventHandler RendicionRealizada;
        public event EventHandler AccionRealizada;
        int danio = 15;
        double controlL = 0;
        double controlA = 0;
        public gengarUC_namespace()
        {
            this.InitializeComponent();
        }
    
        private void onRendicionRealizada()
        {
            RendicionRealizada?.Invoke(this, EventArgs.Empty);
        }

        private void OnAccionRealizada()
        {
            AccionRealizada?.Invoke(this, EventArgs.Empty);
        }
        public void atacar()
        {
            garraSombría();
        }

        public void rendirse()
        {
            onRendicionRealizada();
        }

        public void restaurarEnergia()
        {
            aumentarEnergia();
        }

        public void recibirDaño(int daño)
        {
            pbVida.Value -= daño;
            colorVida();
        }

        public void ocultarDatosCombate()
        {
            verPocionEnergia(false);
            verPocionVida(false);
            verNombre(false);
            verImagenFondo(false);
            verBotonBolaSombras(false);
        }

        public void curarse()
        {
            Potion1_img_PointerReleased(null, null);
        }
        private void OnAtaqueRealizado(AtaqueEventArgs e)
        {
            AtaqueRealizado?.Invoke(this, e);
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

        private void aumentarEnergia()
        {
            pbEnergia.Value += 50;
            OnAccionRealizada();
        }

        private void Potion1_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            HealingDT = new DispatcherTimer();
            HealingDT.Interval = TimeSpan.FromMilliseconds(50);
            HealingDT.Tick += subirVida;
            HealingDT.Start();
            this.imgPocionVida.Opacity = 0.5;
        }
        public void verBarraEnergia(bool verBarraEnergia)
        {
            if (!verBarraEnergia)
                this.pbEnergia.Visibility = Visibility.Collapsed;
            else
                this.pbEnergia.Visibility = Visibility.Visible;
        }
        private void subirVida(object sender, object e)
        {
            this.pbVida.Value += 0.5;
            controlL += 0.5;
            colorVida();

            if (pbVida.Value >= 20)
            {
                this.imgPocionVida.Opacity = 1;

                this.Ojo_drch_down.Visibility = Visibility.Collapsed;
                this.Ojo_izq_down.Visibility = Visibility.Collapsed;
                this.Ojo_drch.Visibility = Visibility.Visible;
                this.Ojo_izq.Visibility = Visibility.Visible;
            }

            if (controlL == 20)
            {
                OnAccionRealizada();
                this.HealingDT.Stop();
                //this.Potion1_img.Opacity = 1;
                controlL = 0;
                //this.Atack_img.Opacity = 1;
            }

            if (pbVida.Value >= 100)
            {
                OnAccionRealizada();
                this.HealingDT.Stop();
                this.imgPocionVida.Opacity = 0.0;
            }
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

        public void verImagenFondo(bool verImagenFondo)
        {
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

        public void verBotonBolaSombras(bool verBotonBolaSombras)
        {
            if (!verBotonBolaSombras)
                this.BolaSombra_btn.Visibility = Visibility.Collapsed;
            else
                this.BolaSombra_btn.Visibility = Visibility.Visible;
        }

        public void verPocionEnergia(bool verPocionEnergia)
        {
            if (!verPocionEnergia)
                this.imgPocionEnergia.Source = null;
            else
                this.imgPocionEnergia.Source = new BitmapImage(new Uri("ms-appx:///Assets/PocionEnergia.png", UriKind.RelativeOrAbsolute));
        }
        public void verNombre(bool verNombre)
        {
            if (!verNombre)
                this.txtBNombre.Visibility = Visibility.Collapsed;
            else
                this.txtBNombre.Visibility = Visibility.Visible;
        }
        private void colorVida()
        {
            if (pbVida.Value <= 20)
            {
                pbVida.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else if (pbVida.Value <= 50)
            {
                pbVida.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
            }
            else
                pbVida.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void Pokeball_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dtPokeball = new DispatcherTimer();
            dtPokeball.Tick += Pokeball;
            dtPokeball.Start();
            this.Pokeball_img_Animated.Visibility = Visibility.Visible;
            this.Pokeball_img.Opacity = 0.5;
        }
        private void Pokeball(object sender, object e)
        {
            Storyboard Sucessfull = (Storyboard)this.Resources["CatchSuccesfull"];
            Storyboard Fail = (Storyboard)this.Resources["CatchFail"];

            int aux = capturaAleatoria();
            if (aux == 1)
            {
                Sucessfull.Begin();
                this.dtPokeball.Stop();
                this.Pokeball_img.Opacity = 0.0;
            }
            else if (aux == 2)
            {
                Fail.Begin();
                this.dtPokeball.Stop();
                this.Pokeball_img.Opacity = 1;
            }
        }
        private int capturaAleatoria()
        {
            int num = 0;
            if (pbVida.Value <= 20)
            {
                num = conversorProbabilidadRojo();
            }
            else if (pbVida.Value <= 50)
            {
                num = conversorProbabilidadAmarillo();
            }
            else
            {
                num = conversorProbabilidadVerde();
            }
            return num;
        }
        private int conversorProbabilidadRojo()
        {
            Random r = new Random();
            int num = r.Next(1, 10);

            int tipoCaptura = 0;

            if (num == 1 || num == 2)
            {
                tipoCaptura = 1;
            }
            else if (num == 3 || num == 4 || num == 5 || num == 6 || num == 7 || num == 8 || num == 9 || num == 10)
            {
                tipoCaptura = 2;
            }

            return tipoCaptura;
        }
        private int conversorProbabilidadAmarillo()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2 || num == 3 || num == 4 || num == 5)
            {
                tipoCaptura = 1;
            }
            else if (num == 6 || num == 7 || num == 8 || num == 9 || num == 10)
            {
                tipoCaptura = 2;
            }

            return tipoCaptura;
        }
        private int conversorProbabilidadVerde()
        {
            Random r = new Random();
            int num = r.Next(1, 20);

            int tipoCaptura = 0;

            if (num == 1 || num == 2)
            {
                tipoCaptura = 2;
            }
            else if (num == 3 || num == 4 || num == 5 || num == 6 || num == 7 || num == 8 || num == 9 || num == 10)
            {
                tipoCaptura = 1;
            }

            return tipoCaptura;
        }

        private async void garraSombría()
        {
            this.Animation_Zarpa_gr.Visibility = Visibility.Visible;
            this.Zarpa_img.Visibility = Visibility.Visible;

            Storyboard Atack = (Storyboard)this.Resources["Atack"];
            Atack.Begin();
            await Task.Delay(1000);
            OnAtaqueRealizado(new AtaqueEventArgs(danio));
        }

        private void bajarVida(object sender, object e)
        {
            this.pbVida.Value -= 0.5;
            controlA += 0.5;
            colorVida();
            if (pbVida.Value == 0)
            {
                this.HealingDT.Stop();
                this.Ojo_drch_down.Visibility = Visibility.Visible;
                this.Ojo_izq_down.Visibility = Visibility.Visible;
                this.Ojo_drch.Visibility = Visibility.Collapsed;
                this.Ojo_izq.Visibility = Visibility.Collapsed;
            }
            if (controlA == 20 || pbVida.Value >= 100)
            {
                controlA = 0;
                this.HealingDT.Stop();
            }
        }

        private void BolaSombra_btn_Click(object sender, RoutedEventArgs e)
        {
            Storyboard BolaSombra = (Storyboard)this.Resources["BolaSombra"];
            BolaSombra.Begin();
        }
    }
}
