using PokemonPruebas;
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
    public sealed partial class cuadroBotonesGengar : UserControl
    {
        private gengarUC_namespace Gengar;
        public cuadroBotonesGengar(gengarUC_namespace gengar)
        {
            this.InitializeComponent();
            Gengar = gengar;
        }

        private void btnBolaSombra_Click(object sender, RoutedEventArgs e)
        {
            Gengar.atacar();
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Gengar.curarse();
        }

        private void btnRecuperarEnergia_Click(object sender, RoutedEventArgs e)
        {
            Gengar.resutarEnergia();
        }
    }
}
