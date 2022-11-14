using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobreescritura_metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            //sobreeescritura de metodo: agarro un  metodo que ya existe y lo redefino, lo sobreeescribo; lo sobreescribo por que ese metodo no esta en la clase actual
            //es importante la herencia
            //es un metodo heredado de otra clase en la jerarquia,de una clase padre. 
            //ejemplo cuando cramos una clase hereda algunas propiedades de la clase object; esos metodos por si solo no hacen mucho, pero si los sobreescribimos, podemos darle
            //una funcionalidad acorde a lo que queremos hacer. Los metodos heredados de la clase object son: 
            //-:toString(): transforma contenido de objeto a string
            //-getType(): devuelve el tipo de dato
            //-equals: compara objeto actual con otro, hay que sobreescribirlo mpara que realice la comparacion que queremos.
            //-getHashCode(): devuelve el numero de documento del objeto
            //Para sobreescribir se usa: override

            Gato gato = new Gato();
            gato.Nombre = "michi";

            Console.WriteLine(gato.Comunicarse());
            Console.WriteLine(gato.ToString());

            Perro perro = new Perro();
            perro.Nombre = "perrix";
            Console.WriteLine(perro.Comunicarse());


            //CASTEO EXPLICITO
            Console.WriteLine("Casteo explicito");


            Animal a1 = gato; //guardo la referencia del gato en una variable de tipo animal, por que un gato es un animal.
                              //a1 no tiene el atributo de gato "nombre", porque la herencia, la jerarquia, es de arriba hacia abajo no de abajo hacia arriba.Solo ve lo que se define a nivel animal(comunicarse()).

            //Si quiero acceder al atributo nombre de gato Hago Casteo explicito con '()'.
            //no se puede guardar un animal en gato por que no se si ese animal es un gato pero como se que es un gato por que guarde gato en a1 puedo hacer casteo explicito, por que estoy
            //seguro de eso.

            Gato gato8 = (Gato)a1;//le digo que ahi en a1 hay un gato.
            gato8.Nombre = "blanquito";

            //gato y gato8 hacen referencia al mismo objeto
            Console.WriteLine("Nuevo nombre de michi: " + gato8.Nombre);
            Console.WriteLine("Nuevo nombre de michi: " + gato.Nombre);


            //creo una LISTA DE ANIMALES para agregar cualquier tipo de animal
            Console.WriteLine("Recorro lista de animales");
            List<Animal> ListaAnimales = new List<Animal>();
            ListaAnimales.Add(gato);
            ListaAnimales.Add(perro);
            //aca lo que estoy haciendo es guardando objetos en la lista, solo que en vez instanciar el objeto y referenciarlo(guardarlo) en una variable como con perro y gato,
            //lo instancio directamente en la lista de animales, creo la REFERENCIA al objeto directamente en la lista, a una ubicacion dentro de ella.Perro y gato esta referenciado
            // tanto en la variable del objeto como en la lista, pero hacen referencia al mismo objeto.
            //estos elementos estn referenciados directamente en la lista.No van a poder ser referenciados desde otro lado que no sea desde la lista, a menos que despues los pase a variable
            ListaAnimales.Add(new Aguila());
            ListaAnimales.Add(new Canario());
            ListaAnimales.Add(new Tigre());
            ListaAnimales.Add(new Pez());


            //en cada vuelta un animal de distinto tipo en la lista ListaAnimales: cada objeto se va a comunicar como sabe comunicarse; no puede acceder al "nombre" por que
            //item esta guardado en un variable de tipo Animal,como se explico en Casteo Explicito
            //pero el metodo comunicarse de cada animal usa el que se especifico al sobreescribirlo = POLIMORFISMO

            //POLIMORFISMO: Caracteristica que tienen los objetos de frente a un mismo estimulo responder de manera distinta.En este caso todos se pueden comunicar, pero responden distinto.
            //Por que cada obejto tiene su definicion de Comunicarse
            foreach (Animal item in ListaAnimales)
            {
                Console.WriteLine("El animal se comunica con: " + item.Comunicarse());
            }
          
            Console.ReadKey();
        }

    
    }
}
