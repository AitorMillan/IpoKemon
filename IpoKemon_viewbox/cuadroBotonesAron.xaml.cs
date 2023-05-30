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
            this.IsEnabledChanged += CuadroBotonesAron_IsEnabledChanged;
            Aron = aron;
        }

        public void accionAleatoria()
        {
            Random rnd = new Random();
            int accion = rnd.Next(1, 5);
            switch (accion)
            {
                case 1:
                    Aron.ataqueCabeza();
                    break;
                case 2:
                    Aron.ataqueCuerpo();
                    break;
                case 3:
                    Aron.curarse();
                    break;
                case 4:
                    Aron.restaurarEnergia();
                    break;
            }
        }

        public void curar()
        {
            Aron.curarse();
        }

        private void btnCurarse_Click(object sender, RoutedEventArgs e)
        {
            Aron.curarse();
            desactivarBotones();
        }

        private void btnAtaqueCabeza_Click(object sender, RoutedEventArgs e)
        {
            Aron.ataqueCabeza();
            desactivarBotones();
        }

        private void btnRestaurarEnergia_Click(object sender, RoutedEventArgs e)
        {
            Aron.restaurarEnergia();
            desactivarBotones();
        }

        private void btnGolpeCuerpo_Click(object sender, RoutedEventArgs e)
        {
            Aron.ataqueCuerpo();
            desactivarBotones();
        }
        private void CuadroBotonesAron_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                activarBotones();
            }
        }

        private void desactivarBotones()
        {
            btnAtaqueCabeza.IsEnabled = false;
            btnCurarse.IsEnabled = false;
            btnGolpeCuerpo.IsEnabled = false;
            btnRestaurarEnergia.IsEnabled = false;
        }

        private void activarBotones()
        {
            btnAtaqueCabeza.IsEnabled = true;
            btnCurarse.IsEnabled = true;
            btnGolpeCuerpo.IsEnabled = true;
            btnRestaurarEnergia.IsEnabled = true;
        }

    }
}
