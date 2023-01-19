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

//en este ejemplo solo vamos a hacer una insercion simple de los atributos de numero, nombre y descripcion; tipo y debilidad se agregaran despues
//OJO: si cargamos en la base de datos algun registro que esta en null, nos dara un error, eso lo vamos a manejar posteriormente

//en esta app se realiza una consulta relacionada por lo que, en este caso, como id tipo y id debilidad no tienen valores y no coinciden, no trae url imagen, por lo que no se rompe; pero si la url imagen se trae y esta en nulo
//se rompe la app, por que no estoy validando el null

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

                //TEBGO MI BASE DATOS, LO MANDO A LA BASE DE DATOS CON MI OBJETO: POKEMON NEGOCIO
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
