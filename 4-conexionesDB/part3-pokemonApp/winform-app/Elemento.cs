using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_app
{
    class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()//se sobreescribe el metodo ToString por que cuando la grilla tiene que mostrar la descripcion, devuelve
            //el objeto devuelve el namesSpace; esto por que Elemento es un objeto, y la interfaz grafica no sabe que hacer con el entonces, trae el
            //metodo de object ToString, pero como pertenece a la clase object solo trae el nameSpace, por lo que lo sobreeescribimos con averride
        {
            return Descripcion;
        }
    }
}
