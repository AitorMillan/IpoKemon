using IpoKemon_viewbox.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IpoKemon_viewbox
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PokeData : Page
    {

        List<PokeInfo> PokeList = new List<PokeInfo>();
        Int32 num = 0;

        public PokeData()
        {
            this.InitializeComponent();
            CrearPokemonInfo();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            num = (Int32)e.Parameter;
            obtenerDatosPoke(num);
        }

        public void CrearPokemonInfo()
        {
            if (Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride.Equals("en-US"))
            {
                PokeList.Add(new PokeInfo("Aron", "Steel", "Rock", 0.4, 60, "It feeds on iron minerals or, occasionally, on railroad tracks to produce the steel shell that protects its body."));
                PokeList.Add(new PokeInfo("Charmander", "Fire", "", 0.6, 8.5, "It prefers hot things. It's said that when it rains steam comes out of the tip of its tail."));
                PokeList.Add(new PokeInfo("Gengar", "Ghost", "Poison", 1.5, 40.5, "To take the life of its prey, it slides into its shadow and waits for its chance in silence."));
                return;
            }
            else 
            { 
                PokeList.Add(new PokeInfo("Aron","Acero","Roca",0.4,60, "Se alimenta de minerales de hierro o, en ocasiones, de vías de tren para producir la coraza de acero que le protege el cuerpo."));
                PokeList.Add(new PokeInfo("Charmander", "Fuego", "",0.6,8.5, "Prefiere las cosas calientes. Dicen que cuando llueve le sale vapor de la punta de la cola."));
                PokeList.Add(new PokeInfo("Gengar","Fantasma","Veneno",1.5,40.5, "Para quitarle la vida a su presa, se desliza en su sombra y espera su oportunidad en silencio."));
            }
        }

        public void obtenerDatosPoke(int n_boton)
        {
            String pokeNombre = null;
       
            switch (n_boton)
            {
                case 1:
                    pokeNombre = "Aron";
                    this.Pokemon_img.Source = new BitmapImage(new Uri("ms-appx:///Assets/aronVictoria.png"));
                    break;
                case 2:
                    pokeNombre = "Charmander";
                    this.Pokemon_img.Source = new BitmapImage(new Uri("ms-appx:///Assets/charmanderVictoria.png"));
                    break;
                case 3:
                    pokeNombre = "Gengar";
                    this.Pokemon_img.Source = new BitmapImage(new Uri("ms-appx:///Assets/gengarVictoria.png"));
                    break;
            }
            PokeInfo pokemonElegido = null;

            foreach (PokeInfo p in PokeList)
            {
                if (p.Nombre == pokeNombre)
                {
                    pokemonElegido = p;
                }
            }

            Nombre_txt.Text = pokemonElegido.Nombre;
            Descripcion_txt.Text = pokemonElegido.descripcion;
            Altura_txt.Text = pokemonElegido.altura + "m";
            Peso_txt.Text = pokemonElegido.peso + "Kg";
            Tipo_txt.Text = pokemonElegido.tipo;
            Tipo2_txt.Text = pokemonElegido.tipo2;

        }

        private void Volver_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame aux = (Frame)this.Parent;
            aux.Navigate(typeof(PokeDex));
        }

        
    }
}
