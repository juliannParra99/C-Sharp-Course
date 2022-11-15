using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociacion_examples
{
    class Auto
    {
        public Auto(string resistenciaChasis)
        {
            Chasis = new Chasis();
            Chasis.Resistencia = resistenciaChasis;
        }
        public string Año { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        //COMPOSICION:Es una relacion bien cercana, define que el objeto debiese nacer con ese objeto que lo compone; nace con esa propiedad, es indispensable para el objeto por asi decir.
        //hay algo con lo que el motor tiene que arrancar si o si: el chasis por ejemplo.
        public Chasis Chasis { get; }

        //AGREGACION:Relacion Lejana es un elemento que no es indispensable para que el objeto sea el objeto, no es inmanente, sino que se le puede agregar posteriormente como agregado del mismo.
        //El auto tiene un OBJETO de TIPO motor como propiedad del vehiculo. Al instanciar el objeto auto,  va a poder acceder a la propiedad Motor de auto, con las props del Objeto Motor.
        //el auto no nace con un motor se le agrega despues.Puedo construir un auto y despues agregarle el motor
        public Motor Motor { get; set; }
    }
}
