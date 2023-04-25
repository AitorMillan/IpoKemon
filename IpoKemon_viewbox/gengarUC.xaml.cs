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

namespace PokemonPruebas
{

    public sealed partial class gengarUC : UserControl
    {
        DispatcherTimer HealingDT;
        DispatcherTimer dtPokeball;
        double controlL = 0;
        double controlA = 0;
        public gengarUC()
        {
            this.InitializeComponent();
        }

        private void Potion1_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            HealingDT = new DispatcherTimer();
            HealingDT.Interval = TimeSpan.FromMilliseconds(50);
            HealingDT.Tick += subirVida;
            HealingDT.Start();
            this.Potion1_img.Opacity = 0.5;
        }

        private void subirVida(object sender, object e)
        {
            this.Life_Pb.Value += 0.5;
            controlL += 0.5;
            colorVida();

            if (Life_Pb.Value >= 20)
            {
                this.Potion1_img.Opacity = 1;
                this.Atack_img.Opacity = 1;

                this.Ojo_drch_down.Visibility = Visibility.Collapsed;
                this.Ojo_izq_down.Visibility = Visibility.Collapsed;
                this.Ojo_drch.Visibility = Visibility.Visible;
                this.Ojo_izq.Visibility = Visibility.Visible;
            }

            if (controlL == 20)
            {
                this.HealingDT.Stop();
                //this.Potion1_img.Opacity = 1;
                controlL = 0;
                //this.Atack_img.Opacity = 1;
            }

            if (Life_Pb.Value >= 100)
            {
                this.HealingDT.Stop();
                this.Potion1_img.Opacity = 0.0;
            }
        }
        private void colorVida()
        {
            if (Life_Pb.Value <= 20)
            {
                Life_Pb.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else if (Life_Pb.Value <= 50)
            {
                Life_Pb.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
            }
            else
                Life_Pb.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
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
            if (Life_Pb.Value <= 20)
            {
                num = conversorProbabilidadRojo();
            }
            else if (Life_Pb.Value <= 50)
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

        private void Atack_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.Animation_Zarpa_gr.Visibility = Visibility.Visible;
            this.Zarpa_img.Visibility = Visibility.Visible;

            Storyboard Atack = (Storyboard)this.Resources["Atack"];
            Atack.Begin();

            HealingDT = new DispatcherTimer();
            HealingDT.Interval = TimeSpan.FromMilliseconds(50);
            HealingDT.Tick += bajarVida;
            HealingDT.Start();
            this.Atack_img.Opacity = 0.5;
        }

        private void bajarVida(object sender, object e)
        {
            this.Life_Pb.Value -= 0.5;
            controlA += 0.5;
            colorVida();
            if (Life_Pb.Value == 0)
            {
                this.HealingDT.Stop();
                this.Atack_img.Opacity = 0.0;
                this.Ojo_drch_down.Visibility = Visibility.Visible;
                this.Ojo_izq_down.Visibility = Visibility.Visible;
                this.Ojo_drch.Visibility = Visibility.Collapsed;
                this.Ojo_izq.Visibility = Visibility.Collapsed;
            }
            if (controlA == 20 || Life_Pb.Value >= 100)
            {
                controlA = 0;
                this.HealingDT.Stop();
            }
        }
    }
}
