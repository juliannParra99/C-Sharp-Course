using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace records
{
    class Edicion
    {//Asoaciacion: mi disco tiene una edicion. es este caso seria composicion o agregacion depende del punto de vista de si nace con una edicion.
        public string Edicion_disco { get; set; }

        //sobreescribo el metodo toString por que en  Discos negocio, cuando instancio la clase de la prop edicion de Discos, el compilador
        //no comprende que hacer por que el tipo de la prop es un objeto por lo que llama al metodo toString de la clase objetc y devuelve la definicion de la
        //clase,no los datos  que pedi, por lo que lo sobreescribo para que me pase los datos que yo le pido, en este caso Edicion_disco
        public override string ToString()
        {
            return Edicion_disco; //returna la property que quiero que muestre
        }
    }
}
