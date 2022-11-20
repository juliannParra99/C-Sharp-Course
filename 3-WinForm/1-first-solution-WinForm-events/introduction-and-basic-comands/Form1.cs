using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace introduction_and_basic_comands
{
    //el modificador PARTIAL permite escribir una clase por partes, por modulos; en este caso, el contructor de la clase inicializa al 
    //metodo initializeComponent(), que esta definido en otro archivo, en form1.designer. Esto lo permite PARTIAL, tener el codigo dividido.
    //en esta parte va la arquitectura logica del form
    public partial class Form1 : Form
    {
        //la ventada de form es una clase que hereda de la clase FORM, lo que permite la interfaz visual
        public Form1()//constructor
        {
            InitializeComponent();//lo que se genera en form1.designer.cs;//METODO DE CLASE "FORM1" QUE INCIALIZA LOS COMPONENTES
        }

        //EVENTO: es un emtodo asociado a un determinado contexto; cuando ocurre un contexto, un evento, en este caso el contexto el el clic del boton, lo que hace que se ejecute el metodo.
        //a los controles siempre hay que ponerle un nombre en las propiedades para despues poder manipularlos; son objetos.
        //voy a capturar lo que esta en el textBox y lo voy a mostrar en el label cuando aprete el boton
        private void btnSaludar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello world");
            string texto = txtNombre.Text;
            lblSaludo.Text = "Hola " + texto; 


        }


        //se ejecuta cuando se abre el programa
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Gracias por usar la app!");

        }

    
    }
}
