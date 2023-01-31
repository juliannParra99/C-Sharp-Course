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

//se modifica solo este archivo en esta seccion
//este es un filtro simple: en otras secciones se hara un filtro en el que se pueda elegir la columna por la que se quiere buscar
namespace winform_app
{
    public partial class frmPokemons : Form
    {
        // esta propiedad esta privada por que la vamos a utilizar en distintos metodos; lo vamos a usar para aplciar el filtro.
        private List<Pokemon> listaPokemon;

        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            cargar();
        }

        //ocurrio por que el index de la grilla se cambia cuando utilizo el filtro y despues cargo todo de nuevo por lo que se ejecuta  el evento
        //se agrega un if a este evento, por que cuando uso el filtro y lo borro, se actualzian los objetos, y puede que alguno quede en nulo,
        //por que si la fila actual es distino de nulo ejecuto eso y sino no lo ejecuto; por que si no pongo el if, si no lo valido estoy queriendo transformar
        //la nada(null) en pokemon , y se  rompe; osea si hay una fila actual seleccionada cargame la imagen, sino no lo hagas por que se rompe todo

        //se valida para que si hay una fila actual seleccionada y no es nulo se ejecuta, sino no se ejecuta y noc arga la imagen apra que no se rompa
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPokemons.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }

        }

        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;
                ocultarColumnas();
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        // se creo metodo, a partir de lo que se borro del metodo cargar(); para no repetir codigo cada vez que lo necesite
        private void ocultarColumnas()
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            dgvPokemons.Columns["Id"].Visible = false;
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

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);
                    
                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            //creo lsita sin instancia por que lo que esta dentro del if devuelve una lista
            //no instancio esta nueva lista por que la isntancia la voy a obtener de un filtro que voy a aplicar
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;
            //si filtro es distinto de vacio, voy a a traer la busqueda
            if(filtro != "")
            {
                //El metodo FindAll() devuelve una nueva lista filtrada a partir de la lista que ya tengo, en este caso ListaPokemon
                // el filtro va a utilizar lo que coloque en la caja de texto
            //esta es la nueva lista que yo voy a utilizar para mostrar en mi formulario cuando utilice el filtro, que captura lo que se escribe en la caja de texto
            //findAll requiere una expresion lambda; el findAll hace una suerte de  for each contra la lista original en donde en cada vuelta va a alojar un objeto, y despues el siguiente
            //donde el nombre de ese objeto(x) sea igual al nombre del filtro de la caja de texto o a la condicion que se le de,y lo devuelvo dentro de la lista que yo voy a devolver(la nueva lista);osea recorre la lsita
            //y evalua si el nombre de ese objeto es igual al filtro que yo te di, si es igual a si lo devuelve y lo guarda en la lista

                //otra cosa que hago es pasal el x.nombre a UPPER() para que cuando busque, la busqueda no discrimine entre mayusculas y minusculas, en este caso
                //convierte todo a mayusculas y trae el valor

                //el metodo contains: hace que busque por una coincidencia, que busca por silaba, por una coincidencia; da verdadero si la cadena contenida en contains,
                //esta contenida en la cadena Nombre.toUpper(), osea, si la cadena de contain esta contenido en la cadena que estoy analizando

                //en este caso estoy filtrando por nombre o por tipo/descripcion, por que como contains devulve un bool, puedo utilizar operadores logicos, que me
                //permiten ejecutar logica, en este caso filtrar por descripcion o nombre, ej, si pongo una palabra o silaba que esta contenida en 
                //el tipo/descripcion, va a traer ambas
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else //si esta vacio asigno lista pokemon, la lsita original sin filtro, osea los datos cargados originalmente;
            {
                listaFiltrada = listaPokemon;
            }
            //se limpia el data source; se limpian todos los datos que aparecen en el dataGridView para mostrar la nueva lista
            //como saque las configuraciones de la grilla me aparecen algunas columnas que habia ocultado, ademas si busco es por nombre especifico solamente,
            //ademas no puedo resetear el filtro, no puedo volver atras, esos son los inconvenientes
            dgvPokemons.DataSource = null;
            // se le pasa el filtro y actualiza el data grid view, con la lista filtrada o no segun corresponda
            dgvPokemons.DataSource = listaFiltrada;
            //se crea metoodo ocultar columnas para que no se vean las columnas que no quiero
            ocultarColumnas();
        }
    }
}
