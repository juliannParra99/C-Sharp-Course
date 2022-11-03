using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_y_Objetos__Ejemplo_Ventas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Primer lote con 10 REGISROS de productos, cada producto tiene:
            //      -Codigo de articulo(3 digitos no correlativos)
            //	    -Precio.
            //      - Codigo de Marca(1 a 10)

            //Segundo lote con las ventas de la semana. Cada venta tiene:
            //      -Codigo de articulo
            //      -Cantidad.
            //      -Codigo de cliente(1 a 100)
            //	Este lote corta con codigo de cliente 0.

            //creo un Vector(array) de articulos, para poder guardarlos mas facil
            //con mi clase articulo creo un vector de 10 elemenotos , con sus respectivos atributos.

            Articulo[] articulos = new Articulo[10]; //creo mi vector con su cantidad de indices.
            for (int  x= 0; x< 10; x++)
            {
                articulos[x] = new Articulo(); //al principio del ciclo tengo que poner esto; por que sino no indico en el espacio de memoria donde se van a guardar
                //Porque el vector está vacío. Es decir, yo reservo espacio de memoria para guardar 10 artículos,
                //pero en cada espacio de memoria no hay nada, entonces antes de poder guardar un dato a un artículo X, tengo que crear ese artículo invocando al constructor con NEW.
                //Esto se debe a que los objetos son tipos referenciales

                Console.WriteLine("Ingrese los datos del producto...");
                Console.WriteLine("Codigo de articulo:");
                articulos[x].CodigoArticulo = int.Parse(Console.ReadLine());
                Console.WriteLine("Precio:");
                articulos[x].Precio = float.Parse(Console.ReadLine());
                Console.WriteLine("Marca (1 a 10) :");
                articulos[x].CodigoMarca = int.Parse(Console.ReadLine());
            }
            //cargado el vector completo con el REGISTRO de los 10 articulos

            Venta venta = new Venta();

            Console.WriteLine("Ingrese la venta");
            Console.WriteLine("Codigo de Cliente");
            venta.CodigoCliente = int.Parse(Console.ReadLine()); // primero el codigo de cliente para poder acceder al ciclo

            while (venta.CodigoCliente !=0)
            {

                Console.WriteLine("Codigo de articulo:");
                venta.CodigoArticulo = int.Parse(Console.ReadLine());
                Console.WriteLine("Cantidad:");
                venta.Cantidad = int.Parse(Console.ReadLine());

                //se realiza el proceso
                //pido cliente nuevamente para indicar si se entra de nuevo al while no
                Console.WriteLine("Ingrese la venta");
                Console.WriteLine("Codigo de Cliente");
                venta.CodigoCliente = int.Parse(Console.ReadLine());

            };


            
          
            Console.ReadKey();
        }
    }
}
