using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            //vehiculo >  auto >  auto deportivo > auto urbano > camioneta > moto
            //todos son vehiculos, pero auto deportivo y urbano, son un tipod de auto, por lo que van a heredar de auto y vehiculo

            Vehiculo v2 = new Camioneta(); // guardo un objeto de tipo camioneta en una variable de tipo vehiculo, por que camioneta es un vehiculo

            // se declara la variable deportivo1 de ipoa autodeportivo, y se le asigna la referencia del objeto
            AutoDeportivo deportivo1 = new AutoDeportivo();
            deportivo1.Marca = "BMW";
            deportivo1.Modelo = 2022;
            deportivo1.VelocidadMax = 300;
            deportivo1.CaballosDeFuerza = 800;

            Console.WriteLine("Auto deportivo: ");
            Console.WriteLine("Marca: " + deportivo1.Marca);
            Console.WriteLine("Modelo: " + deportivo1.Modelo);
            Console.WriteLine("Velocidad maxima: " + deportivo1.VelocidadMax);
            Console.WriteLine("Caballos de Fuerza: " + deportivo1.CaballosDeFuerza);

            Camioneta camioneta1 = new Camioneta();
            camioneta1.Marca = "Dogde Journey";
            camioneta1.Motor = "2.4 L 4-cylinder";
            camioneta1.CargaSoportada = 730;

            Console.WriteLine("Camioneta:");
            Console.WriteLine("Marca: " + camioneta1.Marca);
            Console.WriteLine("Motor: " + camioneta1.Motor);
            Console.WriteLine("Carga soportada: " + camioneta1.CargaSoportada + " Kg.");
            


            //Esto no se puede hacer//
            //Camioneta c2 = new Vehiculo(); //agrego en la variable camioneta un objeto vehiculo; esto no se puede por que vehiculo no hereda de camioneta,
                                           //la herencia es de arriba para abajo.  un vehiculo no puede ser una camioneta por que puede ser cualquier otra cosa
            //

            Console.ReadKey();
        }
    }
}
