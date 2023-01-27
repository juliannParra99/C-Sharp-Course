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

//en esta seccion vamos a usar la aliminacion logica.

//eliminacion logica es diferente de la fisica: la fisica  lanzamos un delete de la DB y se borra el registro
//(permanentemente.

//la eliminacion logica: permite manejar un estado en el registro, que caudno el registro esta vivo,
//el registro esta activo, y cuando se elimino el estado va a estar activo; esto permite
//que podamos recuperar los datos.

//esto se ve en la columna 'Activo', que es de tipo 'bit', lo que quiere decir
//que es bool (verdadero o falso), cuando el registro en la columna 'activo' tenga un 1 quiere decir que el registro esta activo
//osea que es verdaderro, mientras que si tiene 0 el registro esta inactivo.
//cuando esta en 0 el registro ha sido eliminado.

//usamos una elimiancio u otra depende de la pp
// siempre es recomendable  usar la eliminacion logica, por que elimina el registro totalmente de la DB
//pero tambien se puede usar la eliminacion fisica para app pequeñas medianas.
//eliminar un registro de  Db tiene que ser algo muy puntual.

//siempre se recomienda la eliminacion logica; aunque requiera mas trabajo por que lo que leemos de la base de datos
//tiene que estar preparado para reconocer los registros activos e inactivos, y solo traer los activos.
//por lo que voy a tener que modificar erl metodo de listado y solo traer los activos. tambien hay que tener en cuenta las relaciones
// entre las tablas en la eliminacion logica, por ejemplo si dejo inactivo un tipo de pokemon pero otros pokemons usan ese tipo
//no va a poder acceder a ese tipo.
//asi mismo en la eliminacion logica voy a tener que implementar la funcionalidad de reactivar esos registros, es decir que ya no esten eliminados
// por que si necesito un tipo de pokemon que esta eliminado y lo necesito de nuevo no conviene crear todo de nuevo, sino traerlo de los eliminados
//esto para no crear  un nuevo registro que ya existe pero no esta activado.
//la elimiancion logica es util para no borrar completamente un registro sensible de una app, como por ejemplo la factura de un comercio.

//Se modifica en:
//pokemon negocio
//-frmPokemons

//en otra seccion se validara que cuando se borran todos los registros no haya excepcion

//los registros eliminados estan en la base de datos pero inactiovs por lo que no se muestran
//despues habria que pensar una funcionalidad para recuperar los registros eliminados logicamente para que me los
//los recupere nuevamente
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

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar(); // no es eliminacion logica asique no le paso parametro, lo que es false por defecto
        }

        //se agrega el eliminarFisico
        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true); //es eliminacion logica por lo que le pongo true
        }

        //se crea el metodo eliminar que contiene exactamente lo mismo que tenia el eliminarFisico,
        //pero usamos el if para poder usarlo en el eliminarFisico y logico.
        //esto para no repetir codigo

        //el parametro que se pasa es opcional, si no se pasa un parametro especifico al
        //invocar el metodo toma el parametro falso por defecto
        //no confundir con el 0(false) y 1(true ) de la columna 'activo' de la Db
        //termiando este metodo tengo que ahcer que en PokemonNegocio, se LISTEN(metodo listar) los que estan con 'Activo'
        //en 0 en la base de  datos, y solo traiga los que estan activos
        private void eliminar(bool logico = false) //por desfecto es false, asi sabemos que cuando se invoca la eliminacion 'no es logica'
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                    //vamos a usar un metodo u otro dependiendo del valor del metodo eliminar
                    if (logico) //si es verdadero
                        negocio.eliminarLogico(seleccionado.Id);
                    else //no es logico, por lo que el metodo se pasa sin parametro, con el valor por defecto
                        negocio.eliminar(seleccionado.Id);
                    
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
