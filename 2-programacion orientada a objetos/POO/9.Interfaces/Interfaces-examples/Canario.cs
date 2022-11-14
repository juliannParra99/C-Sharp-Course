using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_examples
{

    //tanto para para la herencia como para la interfaz, se usa el dos puntos.Si ya hay herencia, se puede usar una coma para marcar la interfaz
    //la interfaz obliga a que yo implemente el metodo volar, por que la interfaz hace referencia a los animales voladores.
    //y tambien segmento los animales en animales que sepan volar
    class Canario : AnimalDomestico, Flyable
    {
        public string volar()
        {
            return "vuela como un canario";
        }
    }
}
