using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //voy a capturar lo que tengo en la variable txtElemento
            string elem = txtNombre.Text;
            //todo lo que trabaja con una coleccion, trabaja con sus items
            //listView, es un objeto, es un lsitado que funciona como una coleccion, se le agrega valores con add()
            lvElementos.Items.Add(elem);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cuando nace la ventana voy a agregarle un par de elementos al comboBox;el comboBox re quiere ser configurado.
            cboColorFavorito.Items.Add("rojo");
            cboColorFavorito.Items.Add("negro");
            cboColorFavorito.Items.Add("verde");
            cboColorFavorito.Items.Add("violeta");
            cboColorFavorito.Items.Add("amarillo");
            cboColorFavorito.Items.Add("otro");


        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            //para guardar una fecha se utiliza un tipo de varible especial : DateTime
            DateTime fecha = dtpFechaNacimiento.Value;

            //operador ternario, forma corta del if: condicion ? verdadero : falso
            string comida = ckbComida.Checked == true ? "le gusta la comida" : "no le gusta la comida";

            string tipo; //captura el resultado del if
            if (rbtMuggle.Checked)
            {
                tipo = "Muggle";

            }
            else if (rbtWizard.Checked)
            {
                tipo = "Wizard";
            }
            else tipo = "Squibs";

            string colorForito = cboColorFavorito.SelectedItem.ToString(); //selectedItem devuelve un OBJECT, por que se le puede cargar cualquier
            //tipo de objeto, como yo se que  adentro tiene un string uso toString(), si fuera un objeto de tipo botella tendria que hacer la conversion correspondiente
            string numeroFavorito = numNumeroFavorito.Value.ToString();

            string mensaje = "Nombre " + nombre + ", la fecha de nacimiento es " + fecha + ", " + comida + ", su tipo es " + tipo + " y su color favorito es " + colorForito + ".";
            MessageBox.Show(mensaje);


        }
    }
}
