using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_y_Objetos__Ejemplo_Ventas
{
    class Articulo
    {
        //      -Codigo de articulo(3 digitos no correlativos)
        //	    -Precio.
        //      - Codigo de Marca(1 a 10)
        //
        //para manipular atributos desde el exterior puedo usar getter y setter, o puedo usar una Propiedad que tenga el get y set dentro
        //otra manera es omitiendo una propiedad y creando una Propiedad por defecto con prop + TAB; es la forma reducida de la propiedad; crea el atributo y propiedad a la vez
        //la version corta de la Propiedad solo puede gettear y settear el atributo, no s epuede escribir logica como en la version larga

        //forma corta
        public int CodigoArticulo { get; set; } //si le saco el setter seria solo lectura
        public float Precio { get; set; }

        //forma larga
        private int codMarca;

        public int CodigoMarca {
            get { return codMarca; }
            set
            {
                if (value > 0 && value< 11)
                {
                    codMarca = value;
                }
                else 
                    codMarca = -1;
            }
        }




    }
}
