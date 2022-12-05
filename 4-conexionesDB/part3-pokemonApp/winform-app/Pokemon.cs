using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app
{
    class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; } //asociacion por composicion; el pokemon nace con un tipo
        public Elemento Debilidad { get; set; } //asociacion por composicion; el pokemon nace con una debilidad; estos objetos hay que instanciarlos luego

    }
}
