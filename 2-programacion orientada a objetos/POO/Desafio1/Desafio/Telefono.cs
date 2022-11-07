using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    class Telefono
    {
        private string modelo;
        private string marca;
        private string numeroTelefonico;
        private int codigoOperador;

        //cosntructor
        public Telefono(string modelo, string marca)
        {
            this.modelo = modelo;
            this.marca = marca;
        }

        //Metodos.

        public string Llamar()
        {
            return "Realizando llamada...";
        }

        //sobrecarga de metodo
        public string Llamar( string contacto)
        {
            return "Llamando a " + contacto;
        }


        //propiedades
        public string Modelo
        {
            get { return modelo; }//solo lectura
        }
        public string Marca
        {
            get { return marca; }//solo lectura
        }

        public string NumeroTelefonico
        {
            get { return numeroTelefonico; }
            set { numeroTelefonico = value; }
           
        }
    
        public int CodigoOperador
        {//5.CodigoOperador: lectura y escritura.Validar escritura que solo admita 1, 2 o 3, caso contrario escribir un cero.
            get { return codigoOperador; }
            set
            {
                if (value > 0 && value <= 3)
                {
                    codigoOperador = value;
                }
                else
                    codigoOperador = 0;
            }
        }
    }
}
