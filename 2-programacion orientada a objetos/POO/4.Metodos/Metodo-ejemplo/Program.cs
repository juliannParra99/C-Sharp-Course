using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona("JULIAN");

            persona.setEdad(23);
            Console.WriteLine(persona.saludar() + " tengo " + persona.getEdad() + " años");

            Botella botella = new Botella("verde", "vidrio");

            
            Console.WriteLine("La botella es " +  botella.Color + ", es de " + botella.Material + ", tiene una capacidad maxima de " + botella.CapacidadMax +
                "y su capacidad actual es de " + botella.CantidadActual
                );

            Console.WriteLine("La cantidad actual es " + botella.CantidadActual);
            botella.CantidadActual = 75;
            botella.Recargar();
            Console.WriteLine("La cantidad actual despues de recargar es de: " +  botella.CantidadActual + " y tiene un coste de " + botella.Recargar());

            Console.ReadKey();
            

            //PUEDE OPTIMIZARCE AUN MAS
        }
    }
}
