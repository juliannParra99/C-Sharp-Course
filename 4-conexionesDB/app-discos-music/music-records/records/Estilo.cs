using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace records
{
    class Estilo//a esta clase va a estar asociada mis Discos, por que un disco TIENE un estilo: ASOCIACION; le agregp esa nueva prop que tiene mi disco 
        //y lo asocio con Estilo: COmo lo hago: creando una variable de TIPO Estilo en mis discos
    {
        public string Estilo_disco { get; set; }

        //sobreescribo el metodo toString de la clase object para que no devuelva la definiciond de la clase a la hora de querer leer los datos,
        // por que la clase object al ser esa prop de un tipo de dato que es un objeto, no sabe que hacer y ejecuta el metodo toString de la clase objet por defecto.
        public override string ToString()
        {
            return Estilo_disco;
        }

    }
}
