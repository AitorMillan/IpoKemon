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
            PokeList.Add(new PokeInfo("Aron", "Aron", "Aron", "Aron", null, "Aron"));
        }

        public void obtenerDatosPoke(int n_boton)
        {
            String pokeNombre = null;
            Debug.WriteLine(n_boton);
            switch (n_boton)
            {
                case 1:
                    pokeNombre = "Aron";
                    break;
                case 2:
                    pokeNombre = "Dragonite";
                    break;
                case 3:
                    pokeNombre = "Jigglypuff";
                    break;
                case 4:
                    pokeNombre = "Zapdos";
                    break;
                case 5:
                    pokeNombre = "Charizard";
                    break;
                case 6:
                    pokeNombre = "Onix";
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

            t_nombre.Text = pokemonElegido.Nombre;
            t_desc.Text = pokemonElegido.descripcion;
            t_altura.Text = pokemonElegido.altura;
            t_peso.Text = pokemonElegido.peso;
            t_tipo.Text = pokemonElegido.tipo;

        }

        private void Volver_img_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame aux = (Frame)this.Parent;
            aux.Navigate(typeof(PokeDex));
        }
    }
}
