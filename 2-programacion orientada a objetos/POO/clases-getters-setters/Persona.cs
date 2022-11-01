using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo1
{//las clases son igual que en java
    class Persona 
    {// Persona: edad, sueldo, nombre.; las clases tienen atributos, osea variables dentro de la clase
        // private(un modificador de visibilidad) por que los atributos solo van a poder ser accedidos por getters y setters
        private int edad;
        private float sueldo;
        private string nombre;

        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public int getEdad()
        {
            return edad;
        }
    }
}   
  
