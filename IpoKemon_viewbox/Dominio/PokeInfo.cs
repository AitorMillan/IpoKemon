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
        public string tipo2 { get; set; }
        public Double altura { get; set; }
        public Double peso { get; set; }
        public string descripcion { get; set; }

        public PokeInfo(string nombre, string tipo, string tipo2, Double altura, Double peso, string descripcion)
        {
            Nombre = nombre;
            this.tipo = tipo;
            this.tipo2 = tipo2;
            this.altura = altura;
            this.peso = peso;
            this.descripcion = descripcion;
        }
    }
}
