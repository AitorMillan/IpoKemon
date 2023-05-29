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
    public sealed partial class cuadroBotonesAron : UserControl
    {
        private AronCU_NoViewBox Aron;
        public cuadroBotonesAron(AronCU_NoViewBox aron)
        {
            this.InitializeComponent();
            Aron = aron;
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Aron.curarse();
        }

        private void btnAtaqueCabeza_Click(object sender, RoutedEventArgs e)
        {
            Aron.ataqueCabeza();
        }

        private void btnRestaurarEnergia_Click(object sender, RoutedEventArgs e)
        {
            Aron.restaurarEnergia();
        }

        private void btnGolpeCuerpo_Click(object sender, RoutedEventArgs e)
        {
            Aron.ataqueCuerpo();
        }
    }
}
