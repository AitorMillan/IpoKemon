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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate : Page
    {

        int numJugadores;
        
        public Combate()
        {
            this.InitializeComponent();

        }

        private void BtnUnJugador_Click(object sender, RoutedEventArgs e)
        {
            numJugadores = 1;
            Frame aux = (Frame)this.Parent;
            aux.Navigate(typeof(SelectorPokemon), numJugadores);
        }

        private void BtnDosJugadores_Click(object sender, RoutedEventArgs e)
        {
            numJugadores = 2;
            Frame aux = (Frame)this.Parent;
            aux.Navigate(typeof(SelectorPokemon), numJugadores);
        }
    }
}
