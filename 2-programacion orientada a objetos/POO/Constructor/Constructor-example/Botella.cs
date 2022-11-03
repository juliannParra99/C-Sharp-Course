using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_example
{
    class Botella
    {
        //constructor : Usa mismo nombre que LA CLASE. permite que cuando cree la instancia del objeto lo pueda hacer con algunos datos iniciales.
        //En este ejemplo se le va a dar un valor a color y material desde el incio, y solo "capacidad" van a poder cambiar de valor, por lo que no van a tener setter.
        public Botella(string color, string material)
        {
            this.color = color;
            this.material = material;
        }

        //Sobrecarga de constructor : se utiliza el mismo nombre del constructor pero con distinto parametro, para usar la logica y los atributos segun convenga;
        //este constructor esta vacio (como el "struct" por defecto); para sobrecargar el constructor solo tiene que cambiar la firma.
        public Botella()
        {
            //aca puede ir vacio o escribir una logica
        }

        //  Destructor
        ~Botella()
        {
            //logica..
        }

       // Botella: Capacidad,Color,Material.

        private int capacidad;
        private string color;
        private string material;


        //PROPIEDAD: es una manera mas breve de configurar los getters y setters propuesta por C#;
        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }
        //solo lectura para color y Material por que ya los instancie cuando cree el objeto.
        public string Color
        {
            get { return color; }
        }

        public string Material
        {
            get { return material; }
        }
    }
}
