using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //para conectarme a la base de datos

//ESTO HACE EXACTAMENTE LO MISMO QUE ANTES, SOLO QUE MODULARIZA EL CODIGO, LO CENTRALIZA, PERMITE TENER EL CODIGO MAS LIMPIO

//La diferencia marcada de lo que se va a realizar esta en la clase ElementoNegocio(la nueva que implementa metodos y es mas breves) y Pokemon negocio(la que veniamos usando)
//en este ejemplo creamos una clase de acceso a datos ; antes haciamos eso desde la clase pokemon negocio, pero cada vez que quiera hacer una accion
//para con la base de datos tengo que hacer un metodo de acceso a datos, sea para< leer apra modificar, para elminar etc por lo que resutla incomodo;
//y hace mas dificil la escalabilidad .

//si quiero agregar un pokemon necesito un metodo por ejemplo, si necesito modificar igual, y asi;Este proceso es muy similar en todos los casos
//por que vamos a tener que importar la libreria, crear los objetos etc, y e sun proceso repetitivo, por lo que vamos a crear una clase que me 
//Centralize el proceso de crear los objetos de acceso a la base de datos, para posteriormente conectarme, ahorrando lineas de codigo en el proceso.
//a esa clase la podxriamos colocar en una capa nueva pero por ahora la dejamos en la capa de negocio: y Se llama 'AccesoDatos'
namespace negocio
{
    //metodo que nos permite trar los datos de de la base de datos y leerlos; Voy a CENTRALIZAR LOS OBJETOS DE ACCESO A DATOS
    //voy a utilizar este objeto siempre que necesite utilziar un metodo de acceso a datos; deja el codigo mas limpio por que tengo todo encapsulado; ahorro codigo
    public class AccesoDatos
    {
        //modelo de atributos, van a ser los objetos que necesito para establecerr una conexion.; privadas por que no se van a acceder desde otro lado; los declaro vacios por ahora
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector//metodo para poder leer el lector desde el exterior, no escribirlo, solo leerlo
        {
            get { return lector; }
        }

        public AccesoDatos()//constructor: cuando se instancia el objeto se asignan los valroes a los atributos
        {//asi cada vez que yo cree mi objeto accesoDatos, ese objeto se crea con  una conexion
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true"); //base de datos; le paso el server ahi por que estoy llamando a un constructor que asigna a la propiedad ; el constructor esta sobrecargado
            comando = new SqlCommand();
        }

        //encapsulo la accioon de darle un tipo y un query(consulta): 2 de pokemonNegocio
        public void setearConsulta(string consulta) //pasando la consulta como parametro para reutilizar dependiendo de la consulta que se quiera realizar
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        ///abre la conexion  y ejecuta la conexion, y la ejecucion devuelve un lector
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)  //osea si realice una lectura y tengo el lector, cierro
                lector.Close();//cierro lector; el lector, al igual que la conexion hay que cerrarla
            conexion.Close();//cierro conexion
        }

    }
}
