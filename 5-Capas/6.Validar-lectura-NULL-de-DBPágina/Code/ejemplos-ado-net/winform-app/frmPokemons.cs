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

//IMP. Las validaciones solo se hacen cuando existe la posibilidad de que una columna tenga valor nulo, para que no se rompa; en NOT NULL no hace falta
// primero debugueo el evento que usa el metodo, despues el metodo
namespace winform_app
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemons()
        {
            InitializeComponent();
        }

        //este evento es el que utiliza el metodo listar() por lo que le agrego el try catch para que no se rompa; esto hace que por mas que haya una excepcion
        //me muestre la excepcion, pero pero que por lo menos se muestre la interfaz.Para arreglar esto, lo tengo que hacer en mi metodo Negocio.listar(), que lee
        //desde la base de datos

        // entonces el agrego el try catch al evento que invoca el metodo listar() para que no se rompa por la excepcion. ES UTIL VALIDAR TANTO EL METODO EN SI
        //COMO EL EVENTO QUE LO INVOCA
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);

        }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
        }
    }
}
