using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejo_de_Fechas_con_DateTime
{
    public partial class Form1 : Form
    {
        //dateTime() es un tipo de dato; es un struct y tiene muchas ampliar utilidades en la documentacion. el Struct DateTime tiene constructores con muchas sobrecargas
        //para ver las tipos de propiedades y las sobrecargas de constructor que se pueden utilizar de dateTime(), inicializar el componente y acceder a la definicion

        //En este caso vamos a capturar la fecha seleccionada en el calendario y la vamos a mostrar por pantalla.
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrueba1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("La fecha seleccionada es: " + dtpFecha.Value.ToString("dd/MM/yyyy")); //value devuelve un tipo de dato struct de Date time
            //Igualemente, el DateTimePicker se utilizar para capturar la fecha y guardarla, como en el siguiente ejemplo.
            DateTime fecha1;
            fecha1 = dtpFecha.Value; //cuando queremos capturar un valor no utilizamos to string ni otros metodos,sino que lo guardamos en formato PURO.los formatos los utilizamosd despues
            //caputuramos la fecha, la guardamos en una variable y trabajamos con esa variable.
            //el mismo ejemplo comentado arriba pero con los datos capturados
            MessageBox.Show("La fecha seleccionada es: " + fecha1.ToString("dd/MM/yyyy"));
        }

        private void btnPrueba2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La fecha seleccionada es: " + calFecha.SelectionStart.ToString("dd/MM/yyyy"));//este tiene mas funcionalidades y metodos que el dateTimePicker
        }
    }
}


//DATO: cuando manipulamos fechas y bases de datos, tenemos problemas de formato al usar los datos de las fechas en formato string,
//por lo que es recomendable es capturar y guardar el dato puro de la fecha en una variable, PURO. MANDAMOS EL VALOR PURO A UNA BASE DE 
//DATOS; osea, guardamos el dato en una variable y lo mandamos a la base de datos. Desoues cuando los tengamos que utilizar, si podemos
//jugar con el formato que le vamos a dar.