using System;
using System.Collections.Generic;
using System.ComponentModel; //para poder usar el displayName pide este nameSpace
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //ANNOTATIONS:sirve para valdiaciones, formato de fecha, para darle nombre  a la columna; aplicable tambien a conexion DB en entity framework
    // otros nameSpace para el uso de annotation, annotationModel, para display format etc. googlearlo
    //esto tiene varios usos por que esto esta a nivel de diseño de clase
    public class Pokemon
    {
        //para aplicar nombre: va arriba del atributo que quiero modificar en el nombre
        [DisplayName("Número")]
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }

    }
}
