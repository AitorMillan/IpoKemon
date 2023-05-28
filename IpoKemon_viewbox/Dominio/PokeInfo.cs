using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpoKemon_viewbox.Dominio
{
    public class PokeInfo
    {
        public string Nombre { get; set; }
        public string tipo { get; set; }
        public string altura { get; set; }
        public string peso { get; set; }
        public string imagen { get; set; }
        public string descripcion { get; set; }

        public PokeInfo(string nombre, string tipo, string altura, string peso, string imagen, string descripcion)
        {
            Nombre = nombre;
            this.tipo = tipo;
            this.altura = altura;
            this.peso = peso;
            this.imagen = imagen;
            this.descripcion = descripcion;
        }
    }
}
