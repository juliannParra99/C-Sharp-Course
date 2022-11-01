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
            //tipos de datos:  int floot  bool char, float,entre otros.
            //ciclos: for, while, do while.
            // en este ejemplo de for y while  declaro una variable a en 10 dentro del ciclo for, para entrar
            // en el ciclo for tiene que ser distinto de cero, po lo que por cada vuelta al ciclo el valor de se restablece
            for(int x = 0; x < 10; x++)
            {
            int a = 10;
                while(a != 0)
                {
                    Console.WriteLine("Hola: " + x);
                    a--;
                }
            }
            // el do while se ejecuta al menos una vez 
            do
            {
                //ejemplo
            } while (a != 0);
            Console.ReadKey();
        }
    }
}
