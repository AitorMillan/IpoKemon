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
            this.IsEnabledChanged += CuadroBotonesGengar_IsEnabledChanged;
            Gengar = gengar;
        }

        public void accionAleatoria()
        {
            Random rnd = new Random();
            int accion = rnd.Next(1, 5);
            switch (accion)
            {
                case 1:
                    Gengar.atacar();
                    break;
                case 2:
                    Gengar.curarse();
                    break;
                case 3:
                    Gengar.restaurarEnergia();
                    break;
                case 4:
                    Gengar.rendirse();
                    break;
            }
        }

        public void curar()
        {
            Gengar.curarse();
        }

        private void btnBolaSombra_Click(object sender, RoutedEventArgs e)
        {
            Gengar.atacar();
            desactivarBotones();
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Gengar.curarse();
            desactivarBotones();
        }

        private void btnRecuperarEnergia_Click(object sender, RoutedEventArgs e)
        {
            Gengar.restaurarEnergia();
            desactivarBotones();
        }

        private void btnRendirse_Click(object sender, RoutedEventArgs e)
        {
            Gengar.rendirse();
        }

        private void CuadroBotonesGengar_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                activarBotones();
            }
        }

        private void desactivarBotones()
        {
            btnBolaSombra.IsEnabled = false;
            btnCurarse.IsEnabled = false;
            btnRecuperarEnergia.IsEnabled = false;
            btnRendirse.IsEnabled = false;
        }

        private void activarBotones()
        {
            btnBolaSombra.IsEnabled = true;
            btnCurarse.IsEnabled = true;
            btnRecuperarEnergia.IsEnabled = true;
            btnRendirse.IsEnabled = true;
        }
    }
}
