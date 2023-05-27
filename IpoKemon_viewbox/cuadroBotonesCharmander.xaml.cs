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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IpoKemon_viewbox
{
    public sealed partial class cuadroBotonesCharmander : UserControl
    {
        private ucCharmander_sinBarras Charmie;
        public cuadroBotonesCharmander(ucCharmander_sinBarras charmander)
        {
            this.InitializeComponent();
            Charmie = charmander;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Charmie.enfadado();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Charmie.atacar();
        }
    }
}
