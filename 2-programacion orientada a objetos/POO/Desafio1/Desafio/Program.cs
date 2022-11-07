using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Program
    {
        //1.Crear un proyecto de consola .Net Framework.
        //2.Crear la clase Telefono(recordemos que una clase va en un archivo nuevo; click derecho en el proyecto, agregar, class).
        //3.Agregale los siguientes atributos:
        //Modelo string.
        //Marca string.
        //NumeroTelefonico string.
        //CodigoOperador int (1, 2 o 3).
        //4.Agregale las propiedades correspondientes.Podés hacer el formato largo o el corto.
        //Modelo: solo lectura. Es decir, solo get.
        //Marca: solo lectura.
        //NumeroTelefonico: lectura y escritura.
        //5.CodigoOperador: lectura y escritura.Validar escritura que solo admita 1, 2 o 3, caso contrario escribir un cero.
        //6.Agregar Constructor que reciba Modelo y Marca.
        //7.Crear algunos objetos en el main de Program y probar escribirle datos y mostrar en pantalla el estado del Telefono.
        //8.Agregar método Llamar() sin parámetros que devuelva un string con la leyenda "Realizando llamada...".
        //9.Sobrecargar el método Llamar(string contacto) para que reciba un contacto y devuelva un string con la leyenda "Llamando a " + contacto
        //10.Probar métodos en el main mostrando en pantalla el comportamiento de los objetos.

        //Te propongo pensar alguna clase más, construirla y agregarle atributos, propiedades y métodos y hacer algunas pruebas;
        //siempre teniendo en mente que la idea es representar la realidad en lo digital.
        static void Main(string[] args)
        {
            Telefono telefono1 = new Telefono("X", "Iphone");
            telefono1.NumeroTelefonico = "20205050";
            telefono1.CodigoOperador = 3 ; //si no es un numero entre 1 y 3 da 0.

            Console.WriteLine("El telefono es modelo " + telefono1.Modelo + " y su marca es " + telefono1.Marca + ". El numero telefonico es " + telefono1.NumeroTelefonico + 
                " y su codigo de operador es " + telefono1.CodigoOperador + "."
                );

            Console.WriteLine(telefono1.Llamar());
            Console.WriteLine(telefono1.Llamar("Pepe"));
            Console.WriteLine("Nuevo telefono:");

            //otro objeto
            Telefono telefono2 = new Telefono("A10", "samsung");

            telefono2.NumeroTelefonico = "80803030";
            telefono2.CodigoOperador = 1; //si no es un numero entre 1 y 3 da 0.

            Console.WriteLine("El telefono es modelo " + telefono2.Modelo + " y su marca es " + telefono2.Marca + ". El numero telefonico es " + telefono2.NumeroTelefonico +
                " y su codigo de operador es " + telefono2.CodigoOperador + "."
                );

            Console.WriteLine(telefono2.Llamar());
            Console.WriteLine(telefono2.Llamar("Frodo"));
            Console.WriteLine("Nuevo telefono:");

            //otro objeto
            Telefono telefono3 = new Telefono("P40", "Huawei");

            telefono3.NumeroTelefonico = "90901010";
            telefono3.CodigoOperador = 20; //si no es un numero entre 1 y 3 da 0.

            Console.WriteLine("El telefono es modelo " + telefono3.Modelo + " y su marca es " + telefono3.Marca + ". El numero telefonico es " + telefono3.NumeroTelefonico +
                " y su codigo de operador es " + telefono3.CodigoOperador + "."
                );

            Console.WriteLine(telefono3.Llamar());
            Console.WriteLine(telefono3.Llamar("Marcos"));
            Console.WriteLine("Nuevo telefono:");



            Console.ReadKey();
        }
    }
}
