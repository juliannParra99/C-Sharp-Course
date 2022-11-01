using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectores_array_
{
    class Program
    {
        static void Main(string[] args)
        {
            //un array es un  vectores; acepta una lista de un tipo de dato: string, int , bool, etc
            //asi se declara
            int[] numeros = new int[10];//esta es la cantidad de posiciones del arreglo y que yo puedo rellenar con datos
            //para cada posicion del  arreglo  le asigno un valor.
            numeros[0] = 5;
            numeros[1] = 10;
            numeros[2] = 15;

            int num1 = numeros[0];
            int num2 = numeros[1];
            int num3 = numeros[2];

            Console.WriteLine("el valor de las variables que contienen los valores del array son: " + " " + num1 + " " + num2 + " " + num3);
            Console.ReadKey();

            
        }
    }
}
