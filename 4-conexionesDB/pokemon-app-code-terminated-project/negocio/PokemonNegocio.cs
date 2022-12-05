using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Using System.Data.SqlClient la libreria que necesito para establecer la conexion y leer los datos
using dominio;

namespace negocio
{
    //esta es la clase que me va a permitir crear metodos de acceso a datos para los pokemons; si tuviera otra entidad(nombre de las tablas) en base de datos con sus propiedades (columnas)
    // como en este caso la entidad (Tabla) ELEMENTOS, que en este caso se representan en el codigo en forma de sus clases (objetos),
    // y necesito hacer un par de metodos de acceso a datos, cada clase  va a tener que tener su clase NEGOCIO con sus metodos de  acceso a datos

    // ene ste caso arranco con mi clase POKEMON NEGOCIO para alvergar mis metodos de acceso a datos
    public class PokemonNegocio
    {
        //para mis metodos de acceso a datos creo un metodo,  PUBLIC,  para  que pueda acceder desde el exterior
        //va a ser un metodo que va a devolver varios registros, por lo que los agrupo en una lista de pokemon
        public List<Pokemon> listar() //va a devolver una lista de pokemons
        {
            //establecemos la conexion y leemos los datos, para eso DECLARAMOS una serie de OBJETOS y los configuramos
            //para eso INCLUIMOS LA LIBRERIA ARRIBA DE TODO: Using System.Data.SqlClient

            //objetos creados despues de traer la libreria Sistem.data.sqlClient
            List<Pokemon> lista = new List<Pokemon>();//la lista que va  a devoler
            SqlConnection conexion = new SqlConnection();// objeto para conectarme a algun lado
            SqlCommand comando = new SqlCommand();//objeto para una vez conectado(objeto anterior), realizar acciones. 
            SqlDataReader lector;//es una variable //alverga los datos de la lectura de datos, lo guardo en un lector, no se le genera una isntancia

            //manejo de excepciones primero.
            try
            {//todo el codigo que pueda fallar
                //configuro todas las variables y objetos creados arriba
                //si tuviera usuario y contraseña, iria integrated security                
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true"; //direccion de motor de base datos; cadena de conexion, adonde me voy a conectar: paso los datos de servidor, en este caso sql; en seguridad depende, hay que ponen usuario y contraseña segun el caso
                comando.CommandType = System.Data.CommandType.Text; //para realizar una accion; realizar una lectura; para que le pueda mandar  la sentencia sql en la proxima linea
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1"; //la consulta sql
                comando.Connection = conexion; // el comando de las ultimas 2 lineas las ejecuto en  la conexion de hace 3 lineas

                conexion.Open(); //abro la conexion
                lector = comando.ExecuteReader(); //realizo la lectura y la guarda los datos en la variable lector

                while (lector.Read()) //si hay un registro a cvontinuacion va a devolver true; leo el lector para obtener los datos que tiene adentro
                {
                    Pokemon aux = new Pokemon();
                    //empiezo a cargar el objeto pokemon con los datos del lector de ese registro, es decir con las propiedades (columnas) de esa tabla que corresponden a la fila correspondiente: asi siempre que encuentre un elemento dentro de la tabla; un nuevo pokemon en este caso
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0); //el cero es el indice; va guardando los datos
                    aux.Nombre = (string)lector["Nombre"]; //entre corchetes el nombre de la columna con la que se hizo la consulta ; es la forma en que vamos a utilizar mas; el string adelante para indicar que lo que vamos a guardar es un string; por que no lo podemos asignar implicitamente
                    aux.Descripcion = (string)lector["Descripcion"];

                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];
                    if(!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux); //agrego el pokemon a la lista; asi por cada pokemon voy a ir agregando los datos
                    //por cada nueva vuelta del ciclo, se va reutilizando la variable aux, y esa misma variable va ir referenciando distintos objetoss; por los pokemones no son iguales
                }

                conexion.Close(); //cierra la conexion cuando termino de leer; esto podria ir en un finally para que se cierre la conexion por mas que haya un error antes que no permita cerrar la conexion
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
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @urlImagen)");
                datos.setearParametro("@idTipo", nuevo.Tipo.Id);
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);
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

        public void modificar(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.Id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearParametro("@id", poke.Id);

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

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1 And ";
                if(campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from pokemons where id = @id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update POKEMONS set Activo = 0 Where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
