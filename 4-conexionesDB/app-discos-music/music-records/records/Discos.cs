using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace records
{
    //formato del objeto que voy a manipular en mi app.
    //dato: el dataGridView recorre las propiedades del objeto Discos y segun estos pone el nombre de las columnas; por lo que el nombre de las props
    //sera el nombre que aparecera en las columnas; tener en cuenta a la hora de la estetica.
    class Discos 
    {
        //las propiedades que voy a querer traer de la base de datos; primero empiezo con el titulo y la cantidad de canciones.
        public string Titulo { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagen { get; set; }
        //agrego nuevas propiedades: estilo y edicion; son valores ASOCIADOS (asociacion), a mi objeto
        public Estilo Estilo { get; set; } //el tipo de la propiedad es un objeto de TIPO ESTILO, esto posteriormente hay que instanciarlo.
        public Edicion Edicion { get; set; }

    }
}
//para conectarme la base de datos lo hago en otra clase; por principios de diseño