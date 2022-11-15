using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociacion_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asociacion= dos tipos, COMPOSICION Y AGREGACION.
            //asociacion es un tipo de relacion entre clases. Es cuando una clase dentro de su definicion (cuerpo) tiene uno de los atributos o propiedades cuyo Tipo de Dato
            //corresponde a otra clase.Osea, una propiedad o atributo tiene como tipo de dato el valor de otra clase.
            //Son similares conceptualmente pero tienen pequeñas diferencias.Es bueno saberlas para armar la estructura del proyecto; para saber cuando se puede agregar algo,
            //o no, por que ya nace con esa propiedad.
            //Como se lee la Asociacion: Herencia se lee "es", ej: un pajaro Es un animal; Pero en asociacion se lee "tiene": un auto TIENE un chasis, tiene un motor.
            //una persona no es una direccion, Tiene una direccion. LA LECTURA PERMITE UNA CORRECTA RELACION ENTRE CLASES.

            Auto auto = new Auto("alta");
            //crea un auto --> al motor del auto le agrego un objeto Motor (importante instanciar el objeto de composicion el respectivo atributo, sino da excepcion)
            //asociacion por agregacion
            auto.Motor = new Motor();
            auto.Motor.Marca = "BMW V8";


            Console.WriteLine("La marca del motor del auto es " + auto.Motor.Marca);
            Console.WriteLine("La resistencia del chasis es: " + auto.Chasis.Resistencia);

            //EJEMPLOD DE ATRIBUTO ESTATICO.

            Camioneta.AtributoEstatico = 30;
            
            Console.WriteLine("Ejemplo de uso de clase estatica.");
            Console.WriteLine(Camioneta.TodoTerreno());
            Console.WriteLine("El valor del atributo estatico es: " + Camioneta.AtributoEstatico);
            Console.ReadKey();
        }
    }
}
