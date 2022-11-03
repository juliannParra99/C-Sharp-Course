using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_example
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //por defecto nuestro codigo tiene la clase Struct, de la cual se heredan algunas propiedades;
            //con la palabra reservada "New" se invoca al constructor,cuando se isntancia el objeto.
            //se declara una variable del tipo botella que con =new Botella(), se le asigna un objeto en memoria
            Botella botella = new Botella("rojo", "plastico");

            string color = botella.Color;
            color = "verde"; 
            botella.Capacidad = 100005;

            Console.WriteLine("La botella es de color " + color + " tiene una capacidad de " +  botella.Capacidad + " mililitros, y es de " + botella.Material + ".");
            Console.ReadKey();
        }
    }
}
