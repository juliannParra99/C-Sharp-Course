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
            Console.ReadKey();
            
        }
    }
}
