using Charmander_UWP_ControlUsuario;
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
        private ucCharmander_namespace Charmie;
        public cuadroBotonesCharmander(ucCharmander_namespace charmander)
        {
            this.InitializeComponent();
            Charmie = charmander;
            this.IsEnabledChanged += CuadroBotonesCharmander_IsEnabledChanged;
        }

        public void activarBotones()
        {
            btnAtacar.IsEnabled = true;
            btnCurarse.IsEnabled = true;
            btnEnfadarse.IsEnabled = true;
            btnActivarEscudo.IsEnabled = true;
        }

        private void btnAtacar_Click(object sender, RoutedEventArgs e)
        {
           Charmie.atacar();
           desactivarBotones();
        }

        private void CuadroBotonesCharmander_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                activarBotones();
            }
        }

        private void btnEnfadarse_Click(object sender, RoutedEventArgs e)
        {
            Charmie.enfadado();
            desactivarBotones();
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Charmie.curarse();
            desactivarBotones();
        }

        private void btnActivarEscudo_Click(object sender, RoutedEventArgs e)
        {
            Charmie.activarEscudo();
            desactivarBotones();
        }

        private void desactivarBotones()
        {
            btnAtacar.IsEnabled = false;
            btnCurarse.IsEnabled = false;
            btnEnfadarse.IsEnabled = false;
            btnActivarEscudo.IsEnabled = false;
        }

    }
}
