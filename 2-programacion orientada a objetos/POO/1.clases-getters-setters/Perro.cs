using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo1
{
    class Perro
    {//Perro: Nombre, color origen;
        private string nombre;
        private string color;
        private string origen;

        //accediendo a las propiedades con getters y setter tradicionales.
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public string getColor()
        {
            return color;
        }
        //accediendiendo con PROPIEDADES, brindadas por C#

        public string Origen
        {
            get{ return origen; }
            set { origen = value; }
        }

    }
}
