using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    class Persona
    {
        //esta es mi clase base; la clase generica para crear otras clases que permitan que otras clases adquieran esos valores sin que tenga que escribir los valores en cada una
        //van a heredar esos valores
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public float Salario { get; set; }
    }
}
