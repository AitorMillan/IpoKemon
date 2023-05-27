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

namespace IpoKemon_viewbox
{
    public class AtaqueEventArgs : EventArgs
    {
        public int CantidadDanio { get; set; }

        public AtaqueEventArgs(int cantidadDanio)
        {
            CantidadDanio = cantidadDanio;
        }
    }
    public sealed partial class ucCharmander_sinBarras : UserControl
    {
        private int danio = 15;
        private bool estaEnfadado = false;
        public delegate void AtaqueRealizadoEventHandler(object sender, AtaqueEventArgs e);
        public event AtaqueRealizadoEventHandler AtaqueRealizado;
        public ucCharmander_sinBarras()
        {
            this.InitializeComponent();
            movimientoCola();
        }

        public void atacar()
        {
            int danioAtaque = danio;
            if (estaEnfadado)
            {
                danioAtaque = danio*2;
                estaEnfadado = false;
            }
            OnAtaqueRealizado(new AtaqueEventArgs(danioAtaque));
            
        }

        private void OnAtaqueRealizado(AtaqueEventArgs e)
        {
            AtaqueRealizado?.Invoke(this, e);
        }
        public void enfadado()
        {
            btnEstadoEnfadado_Click(null, null);
            estaEnfadado = true;
        }

        public void invertirPokemon()
        {
            cvPrincipal.RenderTransform = new ScaleTransform() { ScaleX = -1 };
        }
        private void movimientoCola()
        {
            Storyboard sb = (Storyboard)this.Resources["sbMovimientoCola"];
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Begin();
        }
        private void btnEstadoEnfadado_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.ptPupilaIzq.Resources["ojoIzqRojoKey"];
            Storyboard sb2 = (Storyboard)this.ptPupilaDer.Resources["ojoDerRojoKey"];
            sb.Begin();
            sb2.Begin();

        }
    }
}
