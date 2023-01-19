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


//en esta secccion vamos a agregar la funcionalidad de insertar en la base de datos  los valores de los desplegables de  tipo y debilidad ; en la seccion anterior solamente 
// agregamos los desplegables con los datos leidos desde la base de datos; ahora vamos a tomar la info de este forem e inyectarlo, darlo de lata en la base de datos para que una vez 
//inyectados nos  muestre el pokemon en el grid view; para poder verlo tenemos que manejar los valores que estan en null, en esta caso urlImagen; en esta seccion aun  no lo validamos pero podemos darle un string como valor a urlImagen para que se emuestre
//En la base de datos vamos a poder agregar el IDtipo y el IDdebilidad, en formato numero

//en esta seccion s emodifico: 
//1: pokemonNegiocio en metodo agregar
//2: acceso a datos en metodo setearParametro

//en otra seccion vamos a validar lo de valores null que impiden que se muestre pokemon en db, sin la necesidad de asignarle un valor mediante DB

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon poke = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.Tipo = (Elemento)cboTipo.SelectedItem;
                poke.Debilidad = (Elemento)cboDebilidad.SelectedItem;
                //vamos a modificar el metodo agregar
                negocio.agregar(poke);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                cboTipo.DataSource = elementoNegocio.listar();
                cboDebilidad.DataSource = elementoNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
