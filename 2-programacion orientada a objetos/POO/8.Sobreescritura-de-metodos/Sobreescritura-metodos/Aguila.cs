using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobreescritura_metodos
{
    class Aguila : AnimalSalvaje
    {
        public override string Comunicarse()
        {
            return "ruido de Aguila";
        }
    }
}
