using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociacion_examples
{
    static class Camioneta
    {
        //-static: una clase estatica no puede heredar. Lo mas relevante: si tengo una clase estatica, no se puede crear una instancia de una clase estatica
        //,se puede usar la clase junto con sus metodos sin necesidad de instanciar.
        //Tambien si su metodo es estatico pero el resto de la clase no, se puede utilizar el  metodo de la clase pero
        //si quiero utilizar el resto de valores de la clase, tengo que istanciarla.
        //Lo mas comun es : tener una clase comun completa, o una clase estica completa
        //La clase estatic completa puede utilizarse como helper, osea una clase con metodos utiles
        //que permite que los acceda sin instanciarlo.Las clases estaticas son clases que estan
        //Disponibles TODO EL TIEMPO.
        //La clase estatica se auto isntancia y carga en memoria durante toda ejecucion de memoria.Ojo.
        //SI LA CLASE ES ESTATICA EL METODO TIENE QUE SER ESTATICO.
        public static int AtributoEstatico { get; set; }
        public static string TodoTerreno()
        {

            return "la camioneta es una 4x4";
        }
    }
}
