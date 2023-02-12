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

//EN ESTA SECCION SE HARA VALIDACION DE 'REQUERIDOS' Y 'SOLO NUMEROS'

// IMPORTANTE: A LA HORA DE REALZIAR VALIDACIONES ES super importante y necesario utilizar el debuggeador, para ver las secuencia de ejecucion y ver el error



//validaciones: contralar que puede hacer el usuario al utilizar nuestra app; para que no se rompa
//es como contrar la interaccion de la persona con la app, para que no se trabe la app, etc.

//validaciones: controladas(es un posible error conocido y tomamos accion al respecto;las que indicarn el formato de una seccion de un formulario, ejemplo,
//que solo se acepten numeros, fomarto de mail) y las validaciones no esperadas que se realizan con las excepciones(try catch ,etc).

//un ejemplo de validacion es uno que realizamos: donde  decimos, si hay elemento que no esta nulo busca la imagen mostramelo y sino no; es una validacion controlada
//poruqe  es un escenario de un posible error conocido y estoy tomando una accion al repecto.

//el ejemplo de los desplegables apra que no puedan escribir tambien es una validacion, por que si puede escribir se puede romper, en cualqueir caso tendria que usar lo que escribe el user en una logica;

//tipos de validaciones que podemos :  manejables: 'requridos', tipos de datos que se pueden cargar, tipo de mascara del formato que tiene que tener; y las no manejables : expeciones: try catch

//como implementar validaciones: carteles, asterisco, message box , etc

//en esta seccion voy a realizar validaciones de REQUERIDOS, con message box para que carguen los datos correctos en los campos correspondientes

//Se modifica:
//- frmPokemons, seccion de campos de busqueda avanzada.


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
            cboCampo.Items.Add("Número");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");

        }

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

        //se crea metodo, para validar el campo del filtro avanzado
        private bool validarFiltro()
        {
            //si el valor seleccionado del cboCampo es menor a cero, quiere decir que no hay nada seleccionado, esto por que el comboBox funciona como un vector
            //donde lo que contiene se cuenta desde el indice 0, si no hay nada seleccionado es -1 (osea que si quiero que un cboBox no tenga nada seleccioando
            //puedo configurarlo en -1).
            //osea, si cboCampo.SelectedIndex < 0, cboCampo no tiene nada seleccionado
            if (cboCampo.SelectedIndex < 0)
            {
                //si no tiene nada seleccionado muestra esto
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            //Lo mismo para criterio
            if(cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            //si elegiste el campo numero
            if (cboCampo.SelectedItem.ToString() == "Número")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    //valida que la caja no este vacia
                    MessageBox.Show("Debes cargar el filtro para numéricos...");
                    return true;
                }
                //para el txtFiltroAvanzado si pasa las condiciones anteriores
                //si no cargaste  solo numeros en el txtFiltroAvanzado.Text muestro message box;
                //si no son solo numeros muestro message; osea, si soloNumeros retorna FALSE, se validara y mostrara el mensaje.
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo nros para filtrar por un campo numérico...");
                    //y retorno true para que cancele la ejecucion y cargues los datos nuevamente
                    return true;
                }

            }
            //si esta todo bien entonces no realiza la validacion, osea no muestra el messageBox y se ejecuta el filtro
            return false;
        }

        //esto para validar que si el campo es numero y el txtFiltroAvanzado  sola pueda dejar ingresar numeros.
        //este metodo lo podemos abstraerla en otra clase para que la puedan utilizar otros formularios, los mismo para el validar filtro
        //devuleve TRUE si son solo numeros o FALSE si no son solo numeros
        private bool soloNumeros(string cadena)
        {
            //foreach apra validar que sean todos los numeros
            foreach (char caracter in cadena)
            {
                //si el caracter que estamos recorriendo en la cadena NO(!)es numero,
                if (!(char.IsNumber(caracter)))
                    //el return false corta la ejecucion de toda la lectura del switch , aunque queden caracteres por ser leidos
                    return false;
            }
            //si despues de dar vuelta a todo el switch son todos numero, retorna true
            return true;
        }


        //cuando apreto el boton hace el filtro, pero antes de hacerlo va a validar algunos campos; para eso voy  crear un metodo :validarFiltro(),
        //para que valide la variable campo,criterio y filtro, para validar que esos campos esten cargados

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //si validar filtro retorna true ejecuto el return, lo que va a impedir que se ejecute el resto; si hay que validar detiene ejecucion
                if (validarFiltro())
                    //este return, si validarFiltro da 'true 'en alguna de las validaciones, va  a cancelar la ejecucion de todo lo que sigue en el evento
                    //click del boton(no va a devolver nada), es decir, no va a plicar el filtro, si los datos no se colocan correctamente no permite que se
                    //ejecute el resto. CANCELA LA EJECUCION DEL EVENTO
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaPokemon;
            }

            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if(opcion == "Número")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}
