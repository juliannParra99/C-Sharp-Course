using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

//REALIZAMOS UNA ESTRATEGIA DE DESARROLLO: ORDENA LA APLICACION. Este es el patron  de diseño en CAPAS.; tiene relacion con el modelo mvc: modelo vista controlador
//ESTO SIERVE PARA APLICAR EN NUEVOS PROYECTOS TAMBIEN
//construimos una capa para el modelo de dominio, otra para las vistas (las pantallas), y negocio (controller)
//en esta parte del proyecto lo que se hace es refactorizar el codigo; vamos a distribuir las reponsabilidades, ordenamos el software que estamos creando;
//: creamos las clases de dominio (que se encargan cual va a ser el formato y estructura del objeto; cumple la estructura de objeto que vamos a utilizar
// y manipular ,ej, el pokemon, el elemento, el entrenador etc.), las clases de negocio (que es la parte de conexion de base de datos y alguna logica
// que afecte al objeto al que se refiere, el pokemon, entrenado etc. ej, un metodo que filtre una lista de las props; todas las acciones que correspondan a ese objeto)
//
//Pasos:
//Discrimino bien separadamente las distintas partes de mi solucion, es decir, que hace cada cosa.
//para eso hago clic en la solucion agrego nuevo proyecto. y agrego el proyecto CLASS LIBRARY(.NET FRAMEWORK): este tipo de proyecto solo se encarga de guardar clases.
//, su rol es darle diseño  y guardar funcionalidad del software que creamos. Le pasamos las clases correspondientes que queremos que almacene
// class library 'DOMINIO': Le paso todas mis clases del modelo de dominio para que ya quede ordenado
//tengo que hacerle a juste a las clases que paso a las clases contenedoras, ejemplo, el nameSpace, etc. El namespace tiene que tener el nombre de la clase contenedora
//una  ves en el contenedor, las clases no se pueden relacionar como antes, por que los proyectos son independientes entre si; por lo que tengo que hacer
//que se conozcan para que tengan funcionalidad. Para eso tengo que darles una referencia, para que un proyecto use al otro; el que necesita otra clase
//se le agrega la referencia que necesita, pero el otro no puede acceder a los valores, la relacion es unilateral
//y  le inyecto la dependencia arriba: EN ESTE CASO  USING: DOMINIO; ASI SI CONOCE A DOMINIO;Pero apra que una clase pueda ser vista de un proyecto a otro,
//la clase tiene que ser public
//el formulario tambien trae a dominio, por que sino no puede acceder a la clase pokemon


//class library NEGOCIO:  agrego todas mis clases de negocio ; la logica que se repite para que se ejecute el codigo es: agregar la referencia en la clase
//que lo necesita, cambiar el namespace, clases publics para que puedan ser accedidas
//puedo crear mis capas de acceso a bases de datos, de excepciones, de helpers, etc, todo para que el codigo pueda se escalable y ordenado; todo depende de como vaya creciendo
//mi app; se aplica a todo tipo de proyectos, mobile, de consoloa, web etc. ES MUY RECOMENDABLE HACER ESTO, NO SOLO POR EL ORDEN, SINO POR QUE HACE MAS SENCILLO MIGRAR A OTRAS 
// TECNOLOGIAS; como hay simplemente logica que esta en otros proyectos, puedo escalar muy adecuadamente, hacer otra app etc.

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
