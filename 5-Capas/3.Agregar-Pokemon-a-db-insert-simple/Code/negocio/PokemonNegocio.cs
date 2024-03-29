﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

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

        //metodo para poder conectarme a la base de datos; y agregar un pokemon; se agrego en la clase anterior peroa ahora le agregamos funcionalidad
        public void agregar(Pokemon nuevo)
        {
            //no necesita una lista por que no va  a traer datos sino que los va a insertar
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //le agregamos la consulta de insercion para el elemento que queremos agregar
                //ESTO INYECTTA EN LA CONSULTA DE INSERCION LOS VALORES CAPTURADOS QUE YO NECESITO CARGAR EN LA BASE DE DATOS
                //en la consulta ponemos los datos que son strings entre comillas simples pero adentro le ponemos comillas dobles, si es un numero solo ponemos comillas dobles; siempre con signo mas a principio y final
                //las comillas dobles definen una cadena en C# y las comillas simples definen cadenas en sql
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1)");
                //metodo para ejecutar la consulta; no puedo hacer execute no reader, por que no quiero leer, quiero insertar por lo que uso un nonquery
                //yo no programe  que se actualice la lista aun; el cambio solo se va a mostrar en la db
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally //cierra la conexion sin importar si hay un error
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Pokemon modificar) { }

    }
}
