using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //como el tipo de dato string es una clase  tenemos metodos para utilizar.ejemplos de metodos de la clase string
            string nombre;
            Console.WriteLine("Escriba el valor de la variable nombre");
            nombre = Console.ReadLine();
            Console.WriteLine("el valor de la variable nombre es " + nombre);
            nombre = "jhon doe";

            int cantCaracteres =nombre.Length;
            Console.WriteLine(cantCaracteres);
            Console.WriteLine(nombre.ToUpper());
            nombre = nombre.ToUpper();
            Console.WriteLine(nombre);
            Console.WriteLine(nombre.ToLower());

            string saludar = "hola como estas hoy?";
            Console.WriteLine(saludar);
            Console.WriteLine(saludar.Replace('o', 'u'));
            Console.WriteLine(saludar.Replace("hola","chau"));
            
            Console.ReadKey();


        }
    }
}
