using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

//aca vamos a ver como validar cuando tenemos una columna nula en la base de datos y estamos leyendo resgistros. cuando queremos realizar una lectura
//y hay una columna nula; tira una excepcion.
//cuando una columna que queremos leer esta en nula, ahorra un error, por que la queremos leer pero no contiene ningun valor; por eso hay que validarlas.Pero
//solo hay que validar aquellas columnas que usamos que permiten null, las columnas 'not null' no permiten el null, por lo que no hace falta validarlas.

namespace negocio
{
    public class PokemonNegocio
    {
        //aca esta el problema  que hace que la aplicacion se rompa; por que la clase que utiliza el metodo listar no lo valida; entonces lo tengo que validar en esa clase
        //ES IMPORTANTE VALIDAR TANTO LOS METODOS COMO LAS CLASES QUE LOS UTILIZAN

        //la validacion se realiza viendo que datos pueden que esten nulos, y si existe la posibilidad que devengan nulos para que no se rompa la lectura; si  la columna es not null no hace falta
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
                    //EN ESTE CASO EL ERROR SE DA POR QUE LA URL IMAGEN ESTA EN NULL POR LO QUE HAY QUE VALIDARLA; HAY DOS FORMAS:
                    //Primera forma: pregunto si lo que esta dentro del lector en esta columna esta en nulo, si lo que esta ahi dentro de la base de datos es nulo
                    //no lo voy a leer; si no esta nulo lo voy a tratar de leer y lo voy a guardar en la propiedad; SOLO VOY A INTENTAR LEER SI NO ESTA NULO, para que no explote

                    //pregunto si lo que esta dentro del lector es nulo (isdbnull), a esto lo hago indicando dentro de isDBNull el valor que quiero saber si es nulo,
                    // a ese valor lo saco del LECTOR, y le indico la columna con getOrdinal("urlImagen"); Esto anterior va a leer los datos SI EL VALOR DENTRO DE LA
                    //COLUMNA ES NULO, y no es lo que quiero por lo que lo niego "!()", entonces queda si lo que esta dentro de esa columna NO ES NULO; si no es nulo
                    //lo leo, sino no

                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];

                    //Segunda forma: la mas practica
                    //si lo que esta en lector urlimagen no es dbnull lo leo; si no es dbnull trata de leerlo
                    if(!(lector["UrlImagen"] is DBNull))
                        //como no leemos el nulo de urlimagen, podemos leer sin que se rompa, por que asignamos en urlimagen al moemnto de leerlo como un string,
                        //ppero en la base de datos sigue siendo nulo; para que no se rompa le asignamos un string vacio a aux.urlimagen.
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

        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad)");
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon modificar) { }

    }
}
