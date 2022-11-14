using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobreescritura_metodos
{
    class AnimalDomestico : Animal
    {
        public string Nombre { get; set; }

        //voy a redefinir el metodo toString heredado de la clase object (que no cumple ninguna funcionalidad si no lo redefino), para que pueda utilizarlo segun la  utilidad que le doy
        //modifico ese metodo por defecto, lo reutilizo a conveniencia
        //la sobreescritura es sobre un metodo que se hereda de una clase base
        //para sobreescribir se usa: override

        public override string ToString()
        {
            return "Animal Domestico: "  + Nombre;     
        }
    }
}
