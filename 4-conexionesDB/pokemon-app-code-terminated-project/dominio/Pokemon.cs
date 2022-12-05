using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{//este es un ejemplo de una pp que se conecta con base de datos sql server; aplicacion de escritorio, pero la estructura para acceder y coenctarse datos sirve en otros con contextos tambien
 //en este caso usamos el ejemplo del modelo CONECTADO
 //se va a usar el paradigma orientado a objetos: se va a esquematizar a partir de la pagina https://www.pokemon.com/us/pokedex/ 
 //vamos a crear el objeto pokemon, y los objetos relacionados con el pokemon
 //usualmente para acceder acceder a los datos de la bd con este metodo, se suele creear un objeto llamado igual que el que esta representado en la base de datos
 // es decir, creamos objetos, para poder traer los datos de la base  de datos

    //lo que hago aca es, despues de crear el windows form, creo una clase que representa el objeto con el que voy a trabajar

    //DESPUES de esto: necesito un metodo que se conecte a la db y realize una lectura, eso lo hago en otra clase por que este es el objeto que voy a utilizar
    // se hace asi por arquitectura y diseño correcta: lo hago en la clase POKEMON NEGOCIO
    public class Pokemon
    {
        //propiedades de mi objeto
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
