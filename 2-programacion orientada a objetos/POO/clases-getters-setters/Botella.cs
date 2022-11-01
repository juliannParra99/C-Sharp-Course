using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo1
{
    class Botella
    {// Botella: Capacidad,Color,Material.
        private int capacidad;
        private string color;
        private string material;

        //PROPIEDAD: es una manera mas breve de configurar los getters y setters propuesta por C#;
        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value;}
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }
    }
}
