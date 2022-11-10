using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class Program
    {
        static void Main(string[] args)
        {
            //la herencia consiste en que un clase Padre o Base, le hereda sus atributos, propiedades y metodos a una clase o familia de clases
            //Es improtante la lectura de la herencia a la hora de realizar la herencia. La lectura es "nombre de clase" ES "Nombre de la clase de la que hereda"
            //tienen que tener una relacion jerarquica. la herencia se da de arriba para abajo no de abajo para arriba, osea que la clase que recibe la herencia obtiene
            //las propiedades de la clase padre, pero la clase padre no puede obtener las de las hijas.
            //La herencia se realiza para hacer que un determinado conjunto de clases, de objetos, siguiendo una jerarquia, y teniendo en cuenta que todos SON un objeto
            //que comparten caracteristicas de un objeto mas general, tengan propiedades comunes con respecto a ese objeto padre del que tambien son parte.Sin tener que 
            //repetir el codigo que esta en la clase padre, sino heredandolo. 
            //Permite la escalabilidad, y hacer que nuevasa clases que requiran ser agregadas hereden propiedades comunes.
            //una clase especifica hereda de una clase especifica o padre
            //Hay que crear una familia de  objetos que guardan similitudes, y que hereden ciertas caracteristicas en comun.Son todas clases de una misma familia, representan,
            //en este caso, personas en distintos ambitos.La relacion es que cada uno ES persona. la jerarquia es que tengo la clase base persona, y otras clases que heredan esas cualidades.

            //en este caso la clase padre es la clase Persona; si quiero hacer un programa que tenga datos de los distintos trabajadores de un grupo de sistemas,
            // como Lider, Developer, Tester, etc.,  todas esas clases SON PERSONAS, por lo que les voy a heredar a todos las cualidades que estan dentro de las personas.
            //otro ejemplo seria la clase padre ANIMAL, y sus clases hijas leon, liebre,pato etc. Todas son animales, pertenecen a la clase animal. 
            //siempre es recomendable utilizar esta guia a la hora de generar clases, mantener una jerarquia garantiza la escalabilidad y reutilizcion del codigo.
            //LA IDEA SIEMPRE ES REPRESENTAR OBJETOS DE LA REALIDAD EN LO DIGITAL.

            //cuando creamos una herencia tenemos que preguntarnos: el que hereda ES un "nombre de clase base"?

            //persona > Lider > Developer > Tester

            Persona persona = new Persona();

            Developer developer = new Developer();
            developer.Nombre = "Jhon";
            developer.Salario = 1000;
            Console.WriteLine("Developer: " + developer.Nombre + " salario: " + developer.Salario);

            Tester tester = new Tester();
            tester.erroresDetectados = 44;
            Console.WriteLine("El tester tiene " + tester.erroresDetectados + " errores detectados.");

            AnalistaFuncional analista = new AnalistaFuncional();
            analista.AnalisisTotales = 115;
            Console.WriteLine("El analista realizo: " + analista.AnalisisTotales + " analisis.");

            Lider lider = new Lider();
            lider.personalManejado = 100;

            Console.WriteLine("Personal total del lider: " + lider.personalManejado);


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
