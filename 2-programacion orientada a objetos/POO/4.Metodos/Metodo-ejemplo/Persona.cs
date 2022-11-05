using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_ejemplo
{
    class Persona
    {
        private int edad;
        private float sueldo;
        private string nombre;

        public Persona(string nombre)
        {
            this.nombre = nombre;
        }

        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public int getEdad()
        {
            return edad;
        }
        //un metodo es un Comportamiento de un objeto, es decir, de la instanciacion de la clase; ej, una persona tiene el comportamiento saludar 

        public string saludar()
        {
            return "Hola soy " + nombre;
        }

        // SOBRECARGA DE METODO: es utilizar un mismo metodo, es decir con su nombre, pero implementando otras funcionalidades, ej. utilizando distintos parametros o ejecutando
        //el codigo de otra manera. Asi, cuando se llama al metodo se lo hace con el mismo nombre; mismo metodo distintas funcionalidades

        public string saludar(string nombre)
        {
            return "Hola " + nombre + ", un gusto mi nombre es " +  this.nombre;
        }
    }
}
