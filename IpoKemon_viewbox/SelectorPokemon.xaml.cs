using Charmander_UWP_ControlUsuario;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SelectorPokemon : Page
    {
        public SelectorPokemon()
        {
            this.InitializeComponent();
            //aron_j1.verFondo(false);
            //aron_j1.verNombre(false);
        }

        private void ListViewControles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var userControlSeleccionado = listView.SelectedItem;

            if (userControlSeleccionado is AronCU)
            {
                // Acciones para cuando se selecciona AronCU.
            }
            else if (userControlSeleccionado is ucCharmander)
            {
                // Acciones para cuando se selecciona ucCharmander.
            }
            else if (userControlSeleccionado is gengarUC)
            {
                // Acciones para cuando se selecciona gengarUC.
            }
        }


    }
}
