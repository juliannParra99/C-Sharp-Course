using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_y_Objetos__Ejemplo_Ventas
{
    class Venta
    {
        // //Segundo lote con las ventas de la semana. Cada venta tiene:
        //      -Codigo de articulo
        //      -Cantidad.
        //      -Codigo de cliente(1 a 100)
        //	Este lote corta con codigo de cliente 0.

        public int CodigoArticulo { get; set; }
        public int Cantidad { get; set; }
        public int CodigoCliente { get; set; }
    }
}
