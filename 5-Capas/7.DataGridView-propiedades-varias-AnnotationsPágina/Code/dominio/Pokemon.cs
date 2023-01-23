using System;
using System.Collections.Generic;
using System.ComponentModel; //para poder usar el displayName pide este nameSpace
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //en este caso utilizamaos las annotations para que  si las grillas necesitan un acento por ejemplo o un formato especifico de la propiedad del objeto
    //, en lugar de solo leer y mostrar el nombre de la propiedad del objeto que lee, lo podamos configurar
    //ANNOTATIONS:sirve para valdiaciones, formato de fecha, para darle nombre  a la columna; aplicable tambien a conexion DB en entity framework
    // otros nameSpace para el uso de annotation, annotationModel, para display format etc. googlearlo
    //esto tiene varios usos por que esto esta a nivel de diseño de clase
    public class Pokemon
    {
        //para aplicar nombre  que queremos en la columna usamos este tipo de annotation: va arriba del atributo que quiero modificar el nombre
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
