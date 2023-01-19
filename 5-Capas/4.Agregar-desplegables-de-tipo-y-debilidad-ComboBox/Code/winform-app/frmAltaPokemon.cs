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


//en este ejemplo solo se modifico el altaPokemon

//en esta seccion vamos a agregar la posibilidad de agregar desplegables para que el usuario pueda elegir insertar el tipo y la debilidad;  para que ese desplegable cargue los datos
//vamos a hacer uso del mismo metodo que se encuentra en pokemon negocio que utilizamos para poder mostrar los pokemons que trajimos de la base de datos y que se mostraron el grid view.
//el metodo agregar() de pokemon negocio, para poder cargar los desplegables en la pantalla de alta


//pasos que segui en esta seccion: 
//1ro: agregar funcionalidad al form en el front.
//2do: traer los datos del combo box desde la base de  datos con el elemento listar. 
//3ro:cuando doy click en el boton agregar, capturar el valor del desplegable para que se guarde en la base de datos 

//en la proxima seccion vamos a modificar el metodo agregar para que me cargue correctamente esos valores . IMP IMP IMP
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
                //se agrega al pokemoin que se va a cargar  ala DB el valor que esta contenido en el desplegable.
                //hago casteo explicito del dato que necesito por que cuando selecciono un item de la grilla es de tipo object, y no lo puede convertir por si solo a un valor de tipo Elemento.
                //leo el item seleccionado y lo transformo a elemento
                poke.Tipo = (Elemento)cboTipo.SelectedItem;
                poke.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                negocio.agregar(poke);
                MessageBox.Show("Agregado exitosamente");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //en el evento load del formulario, voy a cargar el contenido de mis desplegables desde la base de datos
        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                // el datasource es para traer los datos  que va a contener el combo box; hay que agregarle una lista distinta a cada combo box por mas que el tipo sea el mismo
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
