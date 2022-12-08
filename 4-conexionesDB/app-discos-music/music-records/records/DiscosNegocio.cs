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
            SqlDataReader lector;


            //manejo de excepcion para configurar mi conexion a base de datos. PERO ANTES TRAIGO LA LIBRERIA
            try//intenta ejecutar si salta un inconveniente no salta al catch
            {//configuro los objetos traidos de la libreria. empiezo por la cadena de conexion
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true"; //direccion de motor de base datos; cadena de conexion, adonde me voy a conectar: paso los datos de servidor, en este caso sql; en seguridad depende, hay que ponen usuario y contraseña segun el caso
                comando.CommandType = System.Data.CommandType.Text; //para realizar una accion; realizar una lectura; para que le pueda mandar  la sentencia sql en la proxima linea
                comando.CommandText = "SELECT D.Titulo,D.CantidadCanciones,D.UrlImagenTapa, E.Descripcion Estilo,TE.Descripcion Edicion FROM DISCOS D, TIPOSEDICION TE, ESTILOS E where D.IdEstilo = E.Id  AND D.IdTipoEdicion = TE.Id"; //la consulta sql
                comando.Connection = conexion; // el comando de las ultimas 2 lineas las ejecuto en  la conexion de hace 3 lineas

                conexion.Open();
                lector = comando.ExecuteReader(); //realizo la lectura; y lo guardo en el lector y que devuelve en objeto sqlDataReader; ahora tengo los
                //datos en mi variable lector; esto genera una tabla viartual que lee los datos de la fila si es que hay datos
                //para leer esos datos utilizo un while.

                while (lector.Read()) // si hay filas devuelve true; 
                {//entra al while y el lector apunta a la primera fila; me voy a crear un objeto discos para ir guardando ahi los datos
                    Discos aux = new Discos(); //y  lo cargo con los datos del lector de ese registro; los que pedi cuando hice la conexion
                    aux.Titulo = lector.GetString(0); //le cargo de lector el tipo de dato y el indice dentro de la consulta que arme
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"]; //le paso el nombre de la columna ;lo convierto explicitamente indicando el tipo de dato que contiene: CASTEO EXPLICITO
                    aux.UrlImagen = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo(); //establezco la referencia al objeto por que la prop Estilo de Discos es un objeto de tipo Estilo.
                    aux.Estilo.Estilo_disco = (string)lector["Estilo"];
                    aux.Edicion = new Edicion();
                    aux.Edicion.Edicion_disco = (string)lector["Edicion"];
        

                    lista.Add(aux); //por cada vuelta del ciclo guardo un objeto en la lista con las filas de las columnas que traigo; reutiliza la variable aux y crea una nueva isntancia
                    //haciendo que con una misma variable se haga referencia a un nuevo objeto; aux se va a instanciar con cada vuelta; la lsita b a tener referencia a distintos objetos
                }
                conexion.Close(); //cuando termino de leer cierro la conexion y devuelvo la lsita
                return lista; //return lsita si todo sale bien; esto queda mejor si se pone en un finally
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
