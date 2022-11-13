using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace colleciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //las colecciones son una especie de evolucion de los vectores. Guardan elementos dentro de si, pero no hace falta definir, como en los vectores cuantos indices tiene
            // para poder albergar datos; podemos poner cuantos queramos.Es mejor y mas util.
            //una collecion es dinamica: no le tengo que definir tamaño; si le agrego elementos crece y si le saco se achica.
            //es un objeto que alberga objetos
            //hay varios tipos de collecciones, los mas importantes son: sets, maps, y listas. 
            //El ams utilizado es el tipo LIST, y es el que vamos a utilizar.

            Vehiculo vehiculo = new Vehiculo();
            Camioneta camioneta1 = new Camioneta();
            Camioneta camioneta2 = new Camioneta();
            Camioneta camioneta3 = new Camioneta();

            camioneta1.Color = "amarillo";
            camioneta2.Color = "rojo";
            camioneta3.Color = "verde";


            //Para crear una coleccion uso indico el tipo de  collecion, en este caso LIST, y pongo dentro de los piquitos el tipo de dato  'List<tipo de dato>'
            //defino una varibale listaCamioneta que va alberga una Lista de objetos  CAMIONETA: a la que adentro le asigno
            //un objeto lsita de camionetas a la que se va a poder acceder y guardar valores; ahora a la lista le puedo agregar camionetas
            List<Camioneta> listaCamionetas = new List<Camioneta>();

            //para agregar camionestas a la lista:
            //no hace falta indicar el indice como en vectores
            listaCamionetas.Add(camioneta1);
            listaCamionetas.Add(camioneta2);
            listaCamionetas.Add(camioneta3);

            //para ver los objetos de dentro

            Console.WriteLine("La cantidad de objetos es: " + listaCamionetas.Count);
            //se puede cambiar el valor de la propiedad tanto con el indice que ocupa en la lista como con la variable que referencia al objeto: por que estos 2 referencian al mismo objeto
            listaCamionetas[1].Color = "negro";
            Console.WriteLine("el color cambiado por indice de la lista es: " + listaCamionetas[1].Color);
            
            camioneta2.Color = "violeta";
            Console.WriteLine("el color cambiado por variable que referencia el objeto es: " + camioneta2.Color);


            //mostrar elementos en la lista: igual que con vectores
            Console.WriteLine("el color es " +  listaCamionetas[1].Color);

            //si quiero recorrer todos los elementos de la collecion podria usar un blucle FOR o un WHILE, a partir de que se la cantidad de objetos que contiene por el metodo COUNT.
            //Pero puedo usar un FOREACH:  permite recorrer una coleccion
            //lo que hago aca es recorrer la lsita hasta que termine. y en cada vuelta agarra el elemento y lo guarda en la variable item

            foreach (Camioneta item in listaCamionetas)
            {
                Console.WriteLine("los colores a partir del ciclo son :"  + item.Color);
            }

            //remover un elemento de la lista con: remove() y removeAlt()
            listaCamionetas.Remove(camioneta3);
            Console.WriteLine("La cantidad de objetos es: " + listaCamionetas.Count);


            Console.ReadKey();




        }
    }
}
