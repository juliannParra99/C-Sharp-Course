using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    //aca voy a implementar mi acceso a datos; lo importante es pensar como ejecutar lo mismo que ejecute en pokemon, pero con mi accesoDros
    public class ElementoNegocio
    {
        public List<Elemento> listar() //la lista si la tengo que crear por que voy a leer elementos
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos = new AccesoDatos();//con esto solo el constructor ya creo los valores de las props, y genero el objeto conexion a la base de datos

            try
            {
                datos.setearConsulta("Select Id, Descripcion From ELEMENTOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())//esta parte queda practimanete igual.
                {
                    Elemento aux = new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // aca usamos el finally para que se ejecute si o si
            }
        }
    }
}
