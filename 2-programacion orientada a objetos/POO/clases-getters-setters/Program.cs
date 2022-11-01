using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            persona.setEdad(23);
            Console.WriteLine("La edad de la persona es " + persona.getEdad());

            Botella botella = new Botella();
            botella.Capacidad = 100;
            int botCapacidad = botella.Capacidad;
            botella.Color = "roja";
            string botColor = botella.Color;
            botella.Material = "aluminio";
            string botMaterial = botella.Material;
            Console.WriteLine(" La capacidad de la botella es de: " + botCapacidad + " mililitros, " +
                "es de color " + botColor + " y es de " + botMaterial
                );

            Perro perro = new Perro();
            perro.setNombre("pancho");
            perro.setColor("negro");
            perro.Origen = "aleman";

            Console.WriteLine("Mi perro se llama " + perro.getNombre() + " es de color " + perro.getColor() + " y tiene origen " + perro.Origen);
            

            Console.ReadKey();
        }

    }
}




