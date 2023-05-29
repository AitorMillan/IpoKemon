using Charmander_UWP_ControlUsuario;
using PokemonPruebas;
using System;
using System.Collections.Generic;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PaginaPrueba : Page
    {
        // Constructor sin parámetros requerido para la navegación
        private int tokenTurno;
        private UserControl Pokemon1;
        private UserControl Pokemon2;
        private string nombrePokemon1;
        private string nombrePokemon2;
        private UserControl CBotones1;
        private UserControl CBotones2;
        public PaginaPrueba()
        {
            InitializeComponent();
            tokenTurno = 1;
        }

        private void pokemon1AtaqueRealizado(object sender, AtaqueEventArgs e)
        {
            // Obtener la cantidad de daño del ataque
            int cantidadDanio = e.CantidadDanio;
            
            switch (nombrePokemon2)
            {
                case "Charmander":
                    ((ucCharmander_namespace)Pokemon2).recibirDaño(cantidadDanio);
                    break;
                case "Aron":
                    ((AronCU_NoViewBox)Pokemon2).recibirDaño(cantidadDanio);
                    break;
                case "Gengar":
                  //  ((gengarUC_namespace)Pokemon2).recibirDaño(cantidadDanio);
                    break;
            }
            cambiarTurno();
        }

        private void pokemon2AtaqueRealizado(object sender, AtaqueEventArgs e)
        {
            // Obtener la cantidad de daño del ataque
            int cantidadDanio = e.CantidadDanio;
            switch (nombrePokemon1)
            {
                case "Charmander":
                    ((ucCharmander_namespace)Pokemon1).recibirDaño(cantidadDanio);
                    break;
                case "Aron":
                    ((AronCU_NoViewBox)Pokemon1).recibirDaño(cantidadDanio);
                    break;
                case "Gengar":
                    //  ((gengarUC_namespace)Pokemon1).recibirDaño(cantidadDanio);
                    break;
            }
            cambiarTurno();
        }


        private void accionRealizada(object sender, EventArgs e)
        {
            cambiarTurno();
        }

        private void cambiarTurno()
        {            
            // Si tokenTurno = 0 -> Turno del jugador 1
            // Si tokenTurno = 1 -> Turno del jugador 2
            if (tokenTurno == 0)
            {
                ContenedorBotones1.Visibility = Visibility.Visible;
                ContenedorBotones1.IsEnabled = true;
                ContenedorBotones2.IsEnabled = false;
                ContenedorBotones2.Visibility = Visibility.Collapsed;
                txtbEsperaJ1.Visibility = Visibility.Visible;
                txtbEsperaJ2.Visibility = Visibility.Collapsed;
                tokenTurno = 1;
            }
            else
            {
                ContenedorBotones2.Visibility = Visibility.Visible;
                ContenedorBotones1.Visibility = Visibility.Collapsed;
                ContenedorBotones2.IsEnabled = true;
                ContenedorBotones1.IsEnabled = false;
                txtbEsperaJ2.Visibility = Visibility.Visible;
                txtbEsperaJ1.Visibility = Visibility.Collapsed;
                tokenTurno = 0;
            }

        }
        private void cargarControlUsuario1(String pokemon1)
        {
            if (pokemon1 == "Charmander")
            {
                Pokemon1 = new ucCharmander_namespace();
                CBotones1 = new cuadroBotonesCharmander(Pokemon1 as ucCharmander_namespace);
                ContenedorPokemon1.Content = Pokemon1;
                ContenedorBotones1.Content = CBotones1;
                ((ucCharmander_namespace)Pokemon1).invertirPokemon();
                ((ucCharmander_namespace)Pokemon1).ocultarDatosCombate();
                ((ucCharmander_namespace)Pokemon1).AtaqueRealizado += pokemon1AtaqueRealizado;
                ((ucCharmander_namespace)Pokemon1).AccionRealizada += accionRealizada;
            }
            else if (pokemon1 == "Aron")
            {
                Pokemon1 = new AronCU_NoViewBox();
                CBotones1 = new cuadroBotonesAron(Pokemon1 as AronCU_NoViewBox);
                ContenedorPokemon1.Content = Pokemon1;
                ContenedorBotones1.Content = CBotones1;
                ((AronCU_NoViewBox)Pokemon1).invertirPokemon();
                ((AronCU_NoViewBox)Pokemon1).ocultarDatosCombate();
                ((AronCU_NoViewBox)Pokemon1).AtaqueRealizado += pokemon1AtaqueRealizado;
                ((AronCU_NoViewBox)Pokemon1).AccionRealizada += accionRealizada;
            }
            else if (pokemon1 == "Gengar")
            {
                Pokemon1 = new gengarUC_namespace();
                CBotones1 = new cuadroBotonesGengar(Pokemon1 as gengarUC_namespace);
                ContenedorPokemon1.Content = Pokemon1;
                ContenedorBotones1.Content = CBotones1;
               // ((gengarUC_namespace)Pokemon1).invertirPokemon();
                //((gengarUC_namespace)Pokemon1).ocultarDatosCombate();
                ((gengarUC_namespace)Pokemon1).AtaqueRealizado += pokemon1AtaqueRealizado;
                ((gengarUC_namespace)Pokemon1).AccionRealizada += accionRealizada;
            }
        }

        private void cargarControlUsuario2(String pokemon2)
        {
            if (pokemon2 == "Charmander")
            {
                Pokemon2 = new ucCharmander_namespace();
                CBotones2 = new cuadroBotonesCharmander(Pokemon2 as ucCharmander_namespace);
                ContenedorPokemon2.Content = Pokemon2;
                ContenedorBotones2.Content = CBotones2;
                ((ucCharmander_namespace)Pokemon2).ocultarDatosCombate();
                ((ucCharmander_namespace)Pokemon2).AtaqueRealizado += pokemon2AtaqueRealizado;
                ((ucCharmander_namespace)Pokemon2).AccionRealizada += accionRealizada;
            }
            else if (pokemon2 == "Aron")
            {
                Pokemon2 = new AronCU_NoViewBox();
                ContenedorPokemon2.Content = Pokemon2;
                CBotones2 = new cuadroBotonesAron(Pokemon2 as AronCU_NoViewBox);
                ContenedorBotones2.Content = CBotones2;
                ((AronCU_NoViewBox)Pokemon2).ocultarDatosCombate();
                ((AronCU_NoViewBox)Pokemon2).AtaqueRealizado += pokemon2AtaqueRealizado;
                ((AronCU_NoViewBox)Pokemon2).AccionRealizada += accionRealizada;
            }
            else if (pokemon2 == "Gengar")
            {
                Pokemon2 = new gengarUC_namespace();
                ContenedorPokemon2.Content = new gengarUC_namespace();
                CBotones2 = new cuadroBotonesGengar(Pokemon2 as gengarUC_namespace);
                ContenedorBotones2.Content = CBotones2;
                ((gengarUC_namespace)Pokemon2).AtaqueRealizado += pokemon2AtaqueRealizado;
                ((gengarUC_namespace)Pokemon2).AccionRealizada += accionRealizada;
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
