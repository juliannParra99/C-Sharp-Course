using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        //LO IMPORTANTE DE EN ESTA SECCION CREAR EL ATRIBUTO 'ID' EN  LA CLASE POKEMONS ES QUE COMO ES UNA CONSULTA DE INSERCION esta seccion
        //NECESITO USAR EL WHERE PARA QUE NO SE MODIFIQUE TODO, Y EL ID ES LO QUE VOY A USAR COMO CONDICION DEL WHERE.

        //SE AGREGA ID: Ahora lo tenemos que traer en la consulta SQL en pokemon negocio
        public int Id { get; set; }
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
