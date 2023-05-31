using Charmander_UWP_ControlUsuario;
using Microsoft.Toolkit.Uwp.Notifications;
using PokemonPruebas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PaginaPrueba : Page
    {

        const int VIDA_CRITICA = 8;
        private MediaPlayer mediaPlayer;

        private int numJugadores;
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

        private void rendirse1(object sender, EventArgs e)
        {
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("es-ES"))
                mostrarGanador("JUGADOR 2", nombrePokemon2);
            else
                mostrarGanador("PLAYER 2", nombrePokemon2);
        }

        private void rendirse2(object sender, EventArgs e)
        {
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("es-ES"))
                mostrarGanador("JUGADOR 1", nombrePokemon1);
            else
                mostrarGanador("PLAYER 1", nombrePokemon1);
        }

        private async void iniciarMusica()
        {
            // Obtenemos la canción, ajustamos su sonido, la ponemos en bucle y la reproducimos
            mediaPlayer = new MediaPlayer();
            StorageFile file;

            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            if (numJugadores == 2)
            {
                file = await folder.GetFileAsync("cancionCombate.mp3");
            }
            else
            {
                file = await folder.GetFileAsync("combateIA.mp3");
            }
            mediaPlayer.SetFileSource(file);
            mediaPlayer.Volume = 0.2;
            mediaPlayer.IsLoopingEnabled = true;
            mediaPlayer.Play();
        }

        private void MyFrame_NavigatedFrom(object sender, NavigationEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void pokemon1AtaqueRealizado(object sender, AtaqueEventArgs e)
        {
            // Obtener la cantidad de daño del ataque
            int cantidadDanio = e.CantidadDanio;
            double vida = 100;
            
            //Le quitamos vida al pokemon 2
            switch (nombrePokemon2)
            {
                case "Charmander":
                    ((ucCharmander_namespace)Pokemon2).recibirDaño(cantidadDanio);
                    vida = ((ucCharmander_namespace)Pokemon2).Vida;
                    break;
                case "Aron":
                    ((AronCU_NoViewBox)Pokemon2).recibirDaño(cantidadDanio);
                    vida = ((AronCU_NoViewBox)Pokemon2).Vida;
                    break;
                case "Gengar":
                    ((gengarUC_namespace)Pokemon2).recibirDaño(cantidadDanio);
                    vida = ((gengarUC_namespace)Pokemon2).Vida;
                    break;
            }
            // Si la vida es menor o igual a 0, mostramos el ganador
            if (vida <= 0 && Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("es-ES"))
            {
                mostrarGanador("JUGADOR 1", nombrePokemon1);
            }
            else if (vida <= 0 && Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
            {
                mostrarGanador("PLAYER 1", nombrePokemon1);
            }
            cambiarTurno();
        }

        private void mostrarGanador(string jugadorGanador, string nombrePokemon)
        {
            string tituloVictoria = "";
            string textoVictoria = "";
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
            {
                if (jugadorGanador == "PLAYER 2" && numJugadores == 1)
                {
                    tituloVictoria = "SORRY, PLAYER 1";
                    textoVictoria = "You have lost the fight against the CPU";
                }
                else
                {
                    tituloVictoria = "CONGRATULATIONS " + jugadorGanador;
                    textoVictoria = "Your Pokemon " + nombrePokemon + " won the fight";
                }
            }
            else
            {
                if (jugadorGanador == "JUGADOR 2" && numJugadores == 1)
                {
                    tituloVictoria = "LO SENTIMOS, JUGADOR 1";
                    textoVictoria = "Has perdido el combate contra la CPU";
                }
                else
                {
                tituloVictoria = "ENHORABONA " + jugadorGanador;
                textoVictoria = "Tu pokemon " + nombrePokemon + " ha ganado el combate";
                }
            }
            
            mediaPlayer.Pause();
            string nombreFoto = nombrePokemon.ToLower() + "Victoria.png";
            //CÓDIGO PARA FINALIZAR LA PARTIDA
            this.Frame.Navigate(typeof(Combate));
            new ToastContentBuilder()
            .AddArgument("action", "Favoritos")
            .AddArgument("conversationId", 9813)
            .AddText(tituloVictoria)
            .AddText(textoVictoria)
            .AddInlineImage(new Uri("ms-appx:///Assets/"+nombreFoto))
            .Show();
        }

        private void pokemon2AtaqueRealizado(object sender, AtaqueEventArgs e)
        {
            // Obtener la cantidad de daño del ataque
            int cantidadDanio = e.CantidadDanio;
            double vida = 100;

            //Le quitamos vida al pokemon 1
            switch (nombrePokemon1)
            {
                case "Charmander":
                    ((ucCharmander_namespace)Pokemon1).recibirDaño(cantidadDanio);
                    vida = ((ucCharmander_namespace)Pokemon1).Vida;
                    break;
                case "Aron":
                    ((AronCU_NoViewBox)Pokemon1).recibirDaño(cantidadDanio);
                    vida = ((AronCU_NoViewBox)Pokemon1).Vida;
                    break;
                case "Gengar":
                    ((gengarUC_namespace)Pokemon1).recibirDaño(cantidadDanio);
                    vida = ((gengarUC_namespace)Pokemon1).Vida;
                    break;
            }
            if (vida <= 0 && Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("es-ES"))
            {
                mostrarGanador("JUGADOR 2", nombrePokemon2);
            }
            else if (vida <= 0 && Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
            {
                mostrarGanador("PLAYER 2", nombrePokemon2);
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
                if (numJugadores == 2)
                {
                    ContenedorBotones2.Visibility = Visibility.Visible;
                    ContenedorBotones1.Visibility = Visibility.Collapsed;
                    ContenedorBotones2.IsEnabled = true;
                    ContenedorBotones1.IsEnabled = false;
                    txtbEsperaJ2.Visibility = Visibility.Visible;
                    txtbEsperaJ1.Visibility = Visibility.Collapsed;
                    tokenTurno = 0;
                }
                else //IA
                {
                    double vida;
                    
                    switch (nombrePokemon2)
                    {
                        case "Charmander":
                            vida = ((ucCharmander_namespace)Pokemon2).Vida;
                            if (vida <= VIDA_CRITICA)
                                ((cuadroBotonesCharmander)CBotones2).curar();
                            else
                                ((cuadroBotonesCharmander)CBotones2).accionAleatoria();
                            break;
                        case "Aron":
                            vida = ((AronCU_NoViewBox)Pokemon2).Vida;
                            if (vida <= VIDA_CRITICA)
                                ((cuadroBotonesAron)CBotones2).curar();
                            else
                                ((cuadroBotonesAron)CBotones2).accionAleatoria();
                            break;
                        case "Gengar":
                            vida = ((gengarUC_namespace)Pokemon2).Vida;
                            if (vida <= VIDA_CRITICA)
                                ((cuadroBotonesGengar)CBotones2).curar();
                            else
                                ((cuadroBotonesGengar)CBotones2).accionAleatoria();
                            break;
                            
                    }
                    ContenedorBotones1.Visibility = Visibility.Collapsed;
                    ContenedorBotones1.IsEnabled = false;
                    txtbEsperaJ2.Visibility = Visibility.Visible;
                    txtbEsperaJ1.Visibility = Visibility.Collapsed;
                    tokenTurno = 0;
                }

            }

        }
        private void cargarControlUsuario1(String pokemon1)
        {

            // En función del pokemon elegido, cargamos el control de usuario correspondiente
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
                ((gengarUC_namespace)Pokemon1).ocultarDatosCombate();
                ((gengarUC_namespace)Pokemon1).AtaqueRealizado += pokemon1AtaqueRealizado;
                ((gengarUC_namespace)Pokemon1).AccionRealizada += accionRealizada;
                ((gengarUC_namespace)Pokemon1).RendicionRealizada += rendirse1;
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
                ContenedorPokemon2.Content = Pokemon2;
                CBotones2 = new cuadroBotonesGengar(Pokemon2 as gengarUC_namespace);
                ContenedorBotones2.Content = CBotones2;
                ((gengarUC_namespace)Pokemon2).ocultarDatosCombate();
                ((gengarUC_namespace)Pokemon2).AtaqueRealizado += pokemon2AtaqueRealizado;
                ((gengarUC_namespace)Pokemon2).AccionRealizada += accionRealizada;
                ((gengarUC_namespace)Pokemon2).RendicionRealizada += rendirse2;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Tuple<int, string, string> data)
            {
                // Desempaquetar los datos
                numJugadores = data.Item1;
                nombrePokemon1 = data.Item2;
                nombrePokemon2 = data.Item3;
                iniciarMusica();
                cargarControlUsuario1(nombrePokemon1);
                cargarControlUsuario2(nombrePokemon2);

                //Controlamos que cuando se cambie de pagina se pare la musica
                this.Frame.Navigated += MyFrame_NavigatedFrom;
            }

            personalizarTextos(numJugadores);
        }

        private void personalizarTextos(int nJugadores)
        {
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
            {
                if (nJugadores == 1)
                {
                    txtbEsperaJ1.Text = "Player's turn";
                    txtbEsperaJ2.Text = "CPU'S turn";
                }
                else
                {
                    txtbEsperaJ1.Text = "Player 1's turn";
                    txtbEsperaJ2.Text = "Player 2's turn";
                }
            }
            else if (nJugadores == 1 && Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("es-ES"))
            {
                txtbEsperaJ1.Text = "Turno del Jugador 1";
                txtbEsperaJ2.Text = "Turno de la CPU";
            }
        }
    }
}