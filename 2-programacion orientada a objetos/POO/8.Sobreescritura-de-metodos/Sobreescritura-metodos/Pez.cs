using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobreescritura_metodos
{
    class Pez : AnimalDomestico
    {
        public override string Comunicarse()
        {
            return "Ruido de pez";
        }
    }
}
