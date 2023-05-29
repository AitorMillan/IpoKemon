using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpoKemon_viewbox
{
    public class AtaqueEventArgs: EventArgs
    {
        public int CantidadDanio { get; set; }

        public AtaqueEventArgs(int cantidadDanio)
        {
            CantidadDanio = cantidadDanio;
        }
    }
}
