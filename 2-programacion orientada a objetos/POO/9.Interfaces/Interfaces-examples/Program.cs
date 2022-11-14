using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //herenci multiple que: que una clase pueda heredar de muchas clases; en c# y otros no es frecuente; se suele decir que una interfaz es lo mas cercano a esto, pero
            //esto no es asi.
            //C# no permite que una clase herede de varias clases al mismo tiempo
            //una clase permite heredar de otra clase, pero permite inplementar de multiples Interfaces, esa es la diferencia.
            //Una interfaz: es una especie de contrato que vamos a implementar en una clase, y esa clase tiene que cumplir lo que ese contrato define; lo que puede definir la interfaz
            // es el comportamiento; puede definir el que, pero no el como, el como s eimplementa depende de como se implementa en la clase.
            //la interfaz define como implementar un metodo pero no define el como se implementa; lo unico que exige la interfaz es que tenga un metodo con determinada firma (tipo, nombre, parametros)
            //la clase tiene  que tener el metodo de INTERFAZ.
            //se puede implementar: por diseño, para indicar que si o si hay que implementar la interfaz; y para segmentar objetos, por que puedo clasificar objetos bajo diferentes patrones.
            //en una clase de animales, no todas las clases van a implementar una interfaz  que implemente el metodo volar, por que no todos los animales vuelan. Se segmenta a 
            //a las clases de la familias de animales que si implementan el metodo volar, solo se implementa en esas clases, que si tienen la capacidad de volar.
            //

            //PUEDO SEGMENTAR LOS ANIMALES EN UNA LISTA QUE CONTENGA SOLO LOS ANIMALES QUE PUEDAN VOLAR, usando la interfz en el tipo de la lista
            //dato : no se puede crear una instancia de una interfaz, no es una clase.Si se puede instanciar una Lista de objetos que contengan esa interfaz, no los que no.
            List<Flyable> listaVoladores = new List<Flyable>();
            listaVoladores.Add(new Canario());
            listaVoladores.Add(new Aguila());

            foreach (Flyable item in listaVoladores)
            {
                Console.WriteLine("El volador " + item.volar());
            }

            Console.ReadKey();

        }
    }
}
