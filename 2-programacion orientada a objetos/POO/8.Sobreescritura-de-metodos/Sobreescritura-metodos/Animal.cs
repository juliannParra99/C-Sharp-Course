using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobreescritura_metodos
{
    class Animal
    {
        //todos los animales hacen algun ruido para comunicarse
        //como cada animal se comunica de distinta manera puedo sobreescribirlo para que se comunique acorde al animal
        //para que yo pueda sobreescribir un metodo tiene que ser "Virtual"
        public virtual string Comunicarse()
        {
            return "ruido... ruido..";
        }
    }
}
