using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        //cuando toco el boton cerrar se cierra ese formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //cuando hago click en agregar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //aca lo que hago es que todas los valores que la persona vaya cargando en el formulario, los voy  a guardar en las propiedades del 
            //objeto pokemon cuando haga click en el boton aceptar
            Pokemon poke = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;

                negocio.agregar(poke);
                MessageBox.Show("Agregado exitosamente");
                Close(); //para que vuelva  a la pestaña principal

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
