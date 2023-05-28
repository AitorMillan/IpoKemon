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
    public sealed partial class PaginaPrueba : Page
    {
        // Constructor sin parámetros requerido para la navegación
        private UserControl Pokemon1;
        private string nombrePokemon1;
        private string nombrePokemon2;
        private UserControl Pokemon2;
        private UserControl CBotones1;
        private UserControl CBotones2;
        public PaginaPrueba()
        {
            InitializeComponent();
        }

        private void Pokemon1AtaqueRealizado(object sender, AtaqueEventArgs e)
        {
            // Obtener la cantidad de daño del ataque
            int cantidadDanio = e.CantidadDanio;

            // Realizar la lógica para quitarle vida al otro Pokemon
            ((AronCU_NoViewBox)Pokemon2).recibirAtaque2(cantidadDanio);
        }
        private void cargarControlUsuario1(String pokemon1)
        {
            if (pokemon1 == "Charmander")
            {
                Pokemon1 = new ucCharmander_sinBarras();
                CBotones1 = new cuadroBotonesCharmander(Pokemon1 as ucCharmander_sinBarras);
                ContenedorPokemon1.Content = Pokemon1;
                ContenedorBotones1.Content = CBotones1;
                ((ucCharmander_sinBarras)Pokemon1).invertirPokemon();
                ((ucCharmander_sinBarras)Pokemon1).AtaqueRealizado += Pokemon1AtaqueRealizado;
            }
            else if (pokemon1 == "Aron")
            {
                ContenedorPokemon1.Content = new AronCU_NoViewBox();
            }
            else if (pokemon1 == "Gengar")
            {
                ContenedorPokemon1.Content = new gengarUC();
            }
        }

        private void cargarControlUsuario2(String pokemon2)
        {
            if (pokemon2 == "Charmander")
            {
                Pokemon2 = new ucCharmander_sinBarras();
                CBotones2 = new cuadroBotonesCharmander(Pokemon2 as ucCharmander_sinBarras);
                ContenedorPokemon1.Content = Pokemon2;
                ContenedorBotones1.Content = CBotones2;
                ((ucCharmander_sinBarras)Pokemon1).AtaqueRealizado += Pokemon1AtaqueRealizado;
            }
            else if (pokemon2 == "Aron")
            {
                Pokemon2 = new AronCU_NoViewBox();
                ContenedorPokemon2.Content = Pokemon2;
                CBotones2 = new cuadroBotonesAron(Pokemon2 as AronCU_NoViewBox);
                ContenedorBotones2.Content = CBotones2;
               // ((AronCU_NoViewBox)Pokemon2).AtaqueRealizado += Pokemon1AtaqueRealizado;
            }
            else if (pokemon2 == "Gengar")
            {
                Pokemon2 = new gengarUC();
                ContenedorPokemon2.Content = new gengarUC();
                CBotones2 = new cuadroBotonesGengar(Pokemon2 as gengarUC);
                ContenedorBotones2.Content = CBotones2;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

                if (e.Parameter is String[] parametros)
            {
                nombrePokemon1 = parametros[0];
                nombrePokemon2 = parametros[1];
                cargarControlUsuario1(nombrePokemon1);
                cargarControlUsuario2(nombrePokemon2);
            }
        }
    }
}
