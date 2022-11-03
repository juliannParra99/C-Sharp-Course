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
    }
}
