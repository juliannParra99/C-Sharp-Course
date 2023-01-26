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

//La eliminacion fisica borra de la base directamente. Ojo!!  por lo que se agrega un textMessage para reconfirmar la eliminacion, lo validamos

//la eliminacion va estar en la clase de negocio, de pokemonNegocio
//En esta seccion se realizara una eliminacion fisica: elimina completamente del  sistema un registo.
//En una seccion posterior se mostrara la eliminacion logica, que elimina el registro pero no completamente.Dato: no tienen que estar
//las dos eliminaciones en una app, pero esta bien conocerlas

//vamos a ver:
//1. como crear el metodo eliminar
//2.como llamarlo desde la botenera
//3.y como valdiar para qque si tocas el bóton por error confirmes, por que se borrar de la base de datos.

//los cambios son en :
//-frmPokemons
//-PokemonNegocio
namespace winform_app
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);

        }

        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
                dgvPokemons.Columns["Id"].Visible = false;
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        //ser agrega boton eliminar
        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            //creamos el objeto pokemon 'selecionado' por que necesitamos pasarle el id al metodo eliminar
            Pokemon seleccionado;
            try
            {
                //para validar si el usuario quiere realmente eliminar el registro vamos a usar el metodo messageBox.Show() que tiene muchas
                //sobrecargas, y lo que vamos a hacer es usar  MessageBoxButtons.YesNo  para indicar que botones va a mostrar y puedo apretar
                //el show devuelve un dialogResult, por que lo guardo  el resultado de ese metodo en una variable de ese tipo DialogResult
                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //messageBoxIcon da un icono
                //si del MessageBoxButtons.YesNo tocamos si o no, el resultado se guarda en el dialogResult, y lo usamos para validar
                //si en la variable respuesta guardo el resultado de 'si' se borra el objeto
                if (respuesta == DialogResult.Yes)//sino no se ejecuta
                {
                    //el pokemon sellecionado para eliminar sera el que este seleccionado en la grilla
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    //con el metodo cargar se actualiza la grilla sin el valor que se ha eliminado
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
