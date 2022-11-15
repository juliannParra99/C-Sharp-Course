using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociacion_examples
{
    class Chasis
    {
        //asociacion por composicion, el auto nace con chasis; como nace con eso, no es comun que se lo cambie, por lo que la propiedad set deberia quitarse, luego de haber
        //definido el valor por defecto con un constructor por ejemplo.
        public string Resistencia { get; set; }
    }
}
