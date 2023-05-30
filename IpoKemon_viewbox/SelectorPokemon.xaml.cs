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
    public sealed partial class SelectorPokemon : Page
    {

        int numJugadores;

        private Border lastSelectedPokemonP1 = null;
        private Border lastSelectedPokemonP2 = null;
        private Brush defaultBorderBrush;
        private Brush defaultBackground;


        public SelectorPokemon()
        {
            this.InitializeComponent();
            defaultBorderBrush = new SolidColorBrush(Colors.Transparent);
            defaultBackground = new SolidColorBrush(Colors.Transparent);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            numJugadores = (int)e.Parameter;

            if (borderAronP1.BorderBrush != null)
            {
                defaultBorderBrush = borderAronP1.BorderBrush;
            }

            if (borderAronP1.Background != null)
            {
                defaultBackground = borderAronP1.Background;
            }

            PersonalizarPagina();
        }

        private void PersonalizarPagina()
        {
            if (numJugadores == 1)
            {
                txtJugador2.Text = "CPU";
                SeleccionarPokemonCPU();
            }
            else
            {
                if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
                    txtJugador2.Text = "Player 2";
                else
                    txtJugador2.Text = "Jugador 2";
            }
        }
        private void SeleccionarPokemonCPU()
        {
            var borders = new List<Border> { borderCharmanderP2, borderAronP2, borderGengarP2 };
            var buttons = new List<Button> { btnCharmanderP2, btnAronP2, btnGengarP2 };

            Random rnd = new Random();
            int selectedIndex = rnd.Next(borders.Count);

            for (int i = 0; i < borders.Count; i++)
            {
                if (i == selectedIndex)
                {
                    borders[i].Background = new SolidColorBrush(Colors.NavajoWhite);
                    buttons[i].IsEnabled = false;
                    lastSelectedPokemonP2 = borders[i];
                }
                else
                {
                    buttons[i].Visibility = Visibility.Collapsed;
                }
            }
        }


        private void SelectPokemonP1(Button clickedButton, Border border)
        {
            if (lastSelectedPokemonP1 != null)
            {
                // Restaurar la apariencia del Pokémon anteriormente seleccionado.
                lastSelectedPokemonP1.Background = defaultBackground;
            }

            // Resaltar el Pokémon seleccionado.
            border.Background = new SolidColorBrush(Colors.Blue);

            // Recordar la última selección.
            lastSelectedPokemonP1 = border;
        }


        private void SelectPokemonP2(Button clickedButton, Border border)
        {
            if (lastSelectedPokemonP2 != null)
            {
                // Restaurar la apariencia del Pokémon anteriormente seleccionado.
                lastSelectedPokemonP2.Background = defaultBackground;
            }

            // Resaltar el Pokémon seleccionado.
            border.Background = new SolidColorBrush(Colors.Red);

            // Recordar la última selección.
            lastSelectedPokemonP2 = border;
        }





        // Botones del jugador 1
        private void btnAronP1_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP1(btnAronP1, borderAronP1);
        }

        private void btnCharmanderP1_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP1(btnCharmanderP1, borderCharmanderP1);
        }

        private void btnGengarP1_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP1(btnGengarP1, borderGengarP1);
        }

        // Botones del jugador 2
        private void btnAronP2_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP2(btnAronP2, borderAronP2);
        }

        private void btnCharmanderP2_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP2(btnCharmanderP2, borderCharmanderP2);
        }

        private void btnGengarP2_Click(object sender, RoutedEventArgs e)
        {
            SelectPokemonP2(btnGengarP2, borderGengarP2);
        }

        private async void btnComenzarBatalla_Click(object sender, RoutedEventArgs e)
        {
            // Comprobar que los dos jugadores han seleccionado un Pokémon
            if (lastSelectedPokemonP1 == null || (numJugadores == 2 && lastSelectedPokemonP2 == null))
            {
                // Mostrar un mensaje de error
                var dialog = new Windows.UI.Popups.MessageDialog("Ambos jugadores deben seleccionar un Pokemon antes de comenzar la batalla.");
                await dialog.ShowAsync();
            }
            else
            {
                // Obtener los nombres de los Pokémon seleccionados
                string pokemonP1 = lastSelectedPokemonP1.Name.Replace("border","").Replace("P1","");

                string pokemonP2 = lastSelectedPokemonP2.Name.Replace("border", "").Replace("P2", "");

                // Cambiamos al siguiente frame pasando los datos como parámetros
                Frame.Navigate(typeof(PaginaPrueba), new Tuple<int, string, string>(numJugadores, pokemonP1, pokemonP2));
            }
        }


        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            // Comprueba si hay alguna página en el historial de navegación para retroceder
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }


    }


}

