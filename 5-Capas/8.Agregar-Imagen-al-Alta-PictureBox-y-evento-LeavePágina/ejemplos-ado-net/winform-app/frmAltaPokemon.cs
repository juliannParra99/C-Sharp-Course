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


//vamos a agregar la imagen y de ver la imagen mientras la estamos agregando.Primero acomodamos el formulario frmAltaPokemon y le damos nombre a los atributos,etc
//para que podamos referirnos a esos objetos cuando le demos logica despues: se le agrega al pictureBox el nombre de pbxPokemon, y el size mode stretch
//voy a gregar que cuando yo pongo una url pueda ver la imagen en el picture box
//le agrego a la textBox urlImagen el evento "leave", para que cuando yo me mueva del cuadro de texto se cargue la imagen



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
                //LE AGREGO EL VALOR DE URL IMAGEN por que sino no se carga la imagen; hay que mapearla para poder mostrarla, y eso es lo que hacemos
                //de igual modo no se rompo por que anteriormente configure lo de que si esta en nulo no se rompe
                poke.UrlImagen = txtUrlImagen.Text;
                poke.Tipo = (Elemento)cboTipo.SelectedItem;
                poke.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                //al metodo agregar le tengo que agregar la consulta de url imagen, por lo que me redirijo hacia alli
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

        //SE AGREGA EVENTO LEAVE
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            //le paso como parametro el valor que esta en el text box
            cargarImagen(txtUrlImagen.Text);
        }

        //metodo copiado de frmPokemons; lo reutilizo
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxPokemon.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }
    }
}
