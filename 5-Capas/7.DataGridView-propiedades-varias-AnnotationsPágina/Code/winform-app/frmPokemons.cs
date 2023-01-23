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

//se le agrega a la grilla la propiedad selecctedmode : fullRowSelected (em diseño)

//tambien se modifca las celdas de la grilla para que no se puedan modificar los registros: para eso voy a diseño, editMode: editProgrammatically
//tambien dejo el multiselect: false, para que no me permita seleccionar varias rows; esto me va  aservir a posterior tambien cuando genere una manera de eliminar o modificar registros.

//TAMBIEN, se realiza ajuste para que cuando doy de alta un nuevo pokemon se muestre inmediatamente en la grilla, en lugar de tener que cerrar la aplicacion y volverla a abrir;
//para lo cual modifico el boton agregar. se crea el metodo cargar(), que contiene el mismo contenido que tenia frmPokemons_load, y que sirve
//para mostrar los datos despues de dar de alta un nuevo pokemon

//ADEMAS, se realiza modificacion de los nombres de la grilla: la grilla toma como nombre el nombre del atributo de la clase; si queremos
//modificar el nombre para que las palabras esten separadas o agregarles tildes, etc, usamos una propiedad llamada ANNOTATIONS en la clase,
//en este caso de pokemons; lo hacemos a partir del modelo de clases


//SE CREA EL METODO CARGAR: QUE CONTIENE tal cual LO QUE CONTENIA frmPokemons_load, solo que creamos este metodo cargar por que como vamos a poder dar de alta 
//nuevos pokemons, queremos que cuando se terminen de cargar se ejecute de nuevo para actualizar la grlla de pokemons. el metodo cargar se usa en 
//frmPokemons_Load y en btnAgregar_Click

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
            cargar(); //se usa metodo cargar creado(); como para mostrar los datos despues de agregarlos se utiliza el mismo mecanismo, se encierra
            //lo que estaba en frmPokemons_Load() en el metodo cargar para reutilizarlo
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);

        }

        // metodo nuevo
        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;
                dgvPokemons.Columns["UrlImagen"].Visible = false; //oculta columna
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
            alta.ShowDialog(); //devuelve un cuadro de texto de agregado exitosamente; cuando se cierra se ejecuta el cargar() 
            cargar(); //cuando se cierra se ejecuta esto, para que se muestren los datos cargados automaticamente
        }
    }
}
