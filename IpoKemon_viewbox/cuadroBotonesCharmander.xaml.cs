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
        }
        private void btnAtacar_Click(object sender, RoutedEventArgs e)
        {
           Charmie.atacar();
        }

        private void btnEnfadarse_Click(object sender, RoutedEventArgs e)
        {
            Charmie.enfadado();
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Charmie.curarse();
        }

        private void btnActivarEscudo_Click(object sender, RoutedEventArgs e)
        {
            Charmie.activarEscudo();
        }
    }
}
