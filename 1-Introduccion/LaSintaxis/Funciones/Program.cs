using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    class Program
    {
        static void Main(string[] args)
        {
            //las funciones es ideal que se creen por fuera del bloque de la funcion main
            Console.WriteLine(suma(5, 5));
            Console.WriteLine(saludar("juli"));
            Console.ReadKey();
        }
        // asi se crean las funciones : siempre con la palabra reservada static; si en el parametro queremos utilizar
        //un valor invocndolo por referencia(osea que no se crea una copia en memoria, si no que se accede al espacio
        //en memoria de esa variable y se  la modifica), se utiliza la palabra reservad "ref en el paramentro, antes del tipo"
        static int suma(int a, int b)
        {
            return a + b;
        }
        static string saludar(string nombre)
        {
            return "hola " + nombre;
        }
    }
}
