using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.Globalization;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SolidColorBrush botonPulsado = new SolidColorBrush(Windows.UI.Color.FromArgb(80, 184, 199, 200));
        string pestanaAnterior = "Inicio";

        public MainPage()
        {
            this.InitializeComponent();
            fmMain.Navigate(typeof(Inicio));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Windows.Foundation.Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView.IsPaneOpen = false;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
                sView.IsPaneOpen = false;
            }
        }

        private void Color_Pestana_Anterior(String pestana)
        {
            if (pestana == "Pokedex")
                btnPokedex.Background = null;
            else if (pestana == "Combate")
                btnCombate.Background = null;
            else if (pestana == "Inicio")
                btnInicio.Background = null;
            else if (pestana == "Configuración")
                btnAjustes.Background = null;
            else if (pestana == "Ayuda")
                btnAyuda.Background = null;
        }

        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(PokeDex));
            Color_Pestana_Anterior(pestanaAnterior);
            btnPokedex.Background = botonPulsado;
            pestanaAnterior = "Pokedex";

        }

        private void btnCombate_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Combate));
            Color_Pestana_Anterior(pestanaAnterior);
            btnCombate.Background = botonPulsado;
            pestanaAnterior = "Combate";
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Inicio));
            Color_Pestana_Anterior(pestanaAnterior);
            btnInicio.Background = botonPulsado;
            pestanaAnterior = "Inicio";
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen;
        }

        private void btnAjustes_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Configuración));
            Color_Pestana_Anterior(pestanaAnterior);
            btnAjustes.Background = botonPulsado;
            pestanaAnterior = "Configuración";
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            fmMain.Navigate(typeof(Ayuda));
            Color_Pestana_Anterior(pestanaAnterior);
            btnAyuda.Background = botonPulsado;
            pestanaAnterior = "Ayuda";
        }
    }
}
