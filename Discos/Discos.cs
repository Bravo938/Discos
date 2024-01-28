using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discos
{
    internal class Discos
    {
        public string Titulo {  get; set; }
        public DateTime Fecha { get; set; }
        public int CantidadDeCanciones { get; set; }
        public string UrlImagenTapa {  get; set; }

        public Estilo Edicion {  get; set; }
        public Estilo EstiloMusical { get; set; }

    }
}
