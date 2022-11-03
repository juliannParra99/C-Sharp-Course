using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_ejemplo
{
    class Botella
    {   
        //capacidad Maxima = 100 
        // cantidadActual = inicia en 0
        //metodo de recarga =  recarga al 100 y devuelve el costo de regargar. 50 cada 100.; este va a serr el metodo de la batotella;
        //el comportamiento.

        private int capacidadMax;
        private string color;
        private string material;
        private int cantidadActual; 

        public Botella(string color , string material)
        {
            this.material = material;
            this.color = color;
            capacidadMax = 100;
            cantidadActual = 0;
        }

        public int CapacidadMax //le podri sacr el setter por que el tamaño de la botella no va a variar en este caso
        {
            get { return capacidadMax; }
            set { capacidadMax = value; }
        }

        //con esto configuro  la cantidad a gusto
        public int CantidadActual
        {
            get {return  cantidadActual; }
            set { cantidadActual = value; }
        }


        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        //Metodos


      
        public float Recargar()
        { //hago que dependiendo del valor de cantidadActual al momento de utilizar el metodo, saque el coste de ese valor.Teniendo en cuenta que 50$ es el valor de llenar capacidadMax.
            if (cantidadActual >= 1 && cantidadActual <=99 && cantidadActual != 100)
            {

                float costo;
                costo = cantidadActual * 50 / 100;
                return costo;
                //100 50 
                //dif x = ...
            }
            else{
                cantidadActual = 100;
                float costo =  50;
                return   costo;
            }
        }
    }
}
