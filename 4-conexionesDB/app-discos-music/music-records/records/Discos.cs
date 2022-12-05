using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace records
{
    class Discos //formato del objeto que voy a manipular en mi app.
    {
        //las propiedades que voy a querer traer de la base de datos; primero empiezo con el titulo y la cantidad de canciones.
        public string Titulo { get; set; }
        public int CantidadCanciones { get; set; }
    }
}
