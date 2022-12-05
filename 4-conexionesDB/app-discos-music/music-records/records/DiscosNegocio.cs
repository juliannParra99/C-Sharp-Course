using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  //libreria
                              //
namespace records
{
    //va a ser la clase que me va a permitir  crear los emtodos de acceso a datos para los discos. si tuviera otras entidades (tablas) en la base de dato, que se 
    //que se refleja en el codigo como un objeto(ej, el objeto discos, persona , etc, el que fuera), y necesito  crear una clase con metodos de acceso a datos
    //cada objeto/clase va a tener que tener su clase 'negocio' con sus metodos de acceso a datos
    class DiscosNegocio
    {//public para que la funcion sea accesible desde el exterior despues de haberlo instanciado; va a ser una funcion que lea registros de la base de datos
        // va a ser un metodo que va a devolver varios registros, por lo que los agrupo en una lista de discos
        public List<Discos> listar()//es de tipo lista asique tiene que devolver una lista
        {
            List<Discos> lista = new List<Discos>();
            //declarado 'using System.Data.SqlClient;', puedo utilizar los siguientes objetos
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;


            //manejo de excepcion para configurar mi conexion a base de datos. PERO ANTES TRAIGO LA LIBRERIA
            try//intenta ejecutar si salta un inconveniente no salta al catch
            {//configuro los objetos traidos de la libreria. empiezo por la cadena de conexion
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true"; //direccion de motor de base datos; cadena de conexion, adonde me voy a conectar: paso los datos de servidor, en este caso sql; en seguridad depende, hay que ponen usuario y contraseña segun el caso
                comando.CommandType = System.Data.CommandType.Text; //para realizar una accion; realizar una lectura; para que le pueda mandar  la sentencia sql en la proxima linea
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1"; //la consulta sql
                comando.Connection = conexion; // el comando de las ultimas 2 lineas las ejecuto en  la conexion de hace 3 lineas


                return lista; //return lsita si todo sale bien
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
