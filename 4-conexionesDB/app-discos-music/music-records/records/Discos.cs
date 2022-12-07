using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace records
{
    //formato del objeto que voy a manipular en mi app.
    class Discos 
    {
        //las propiedades que voy a querer traer de la base de datos; primero empiezo con el titulo y la cantidad de canciones.
        public string Titulo { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagen { get; set; }

    }
}
//para conectarme la base de datos lo hago en otra clase; por principios de diseño