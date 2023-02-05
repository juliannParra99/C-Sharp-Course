using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;//se agrega
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration; //se agrega

//se modifica solo frmAltaPokemon y app.config

//en este seccion vamos a poner la posibilidad de guardar de elegir una imagen desde un archivo, ya no solo utilizando la url de internet.
//vamos a poder poner una url de la imagen que viene desde internet, o levantar una imagen desde nuestra propia pc.

//no vamos a guardar la imagen fisica en la DB , sino que nuestra app va a permitir elegir una rchivo, un fichero, de nuestra pc local, manipularlo y guardarlo,
// pero haciendo una copia de esa imagen en una carpeta que va a ser propia de nuestra aplicacion, y en la DB vamos a guardar la ruta en donde nosotros guardamos esa imagen
//Los archivos pueden de cualqueir tipo de archivo que asociemos con nuestra base de  datos.  La imagen no la emtemos en la base de datos
//en la base de datos guardamos un registro de tipo string que esta asociado al registro  pero que va a contener la ruta d ela imagenes que queremos.

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;

        //se agrega esta propiedad privada
        private OpenFileDialog archivo = null;

        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                if(pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");
                }
                //SE AGREGA ESTO
                //Guardo imagen si la levantó localmente:
                //esto quiere decir: si archivo es distinto de nulo(por que cuando toco el boton para agregar imagen localmente ya se instancia el objeto) y
                // encima el archivo no contiene http, quiere decir que vos estas levantando una imagen local: el que no sea http tiene que ver con que si 
                //yo toque una vez para agregar en el boton y levantar una imagen local y despues me arrepenti y cargo una imangen de la web, 
                //que no contenga http me garantiza que no se cree una variable de una imagen local cuando ya no la voy a utilizar, por que pase al menos una vez por ese boton

                //osea tengo 2 condiciones: si es distinto de null y no tiene http es una pauta que lo que quiero guardar es una archivo local
                if(archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

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
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                if(pokemon != null)
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            //para poder levantar una imagen de nuestra pc, creamos
            //un objeto llamado OpenFileDialog; lo que nos va a permitir abrir
            //una ventana de dialogo que nos va a permitir elegir un archivo
            archivo = new OpenFileDialog();
            //cuando se abre esa ventana, establesco que tipo de archivos quiero que permita elegir
            //en este caso jpg y png; filtra que tipo de archivo puedo elegir
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            // aca digo, si el resultado de la ventana que se abre de 'archivo'
            //tiene todo OK, osea si se elegio segun el formato por el que filtramos
            //osea una ves selecciono la imagen y toco ok, se ejecuta el if
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                //si entra al if, voy a manejar 'archivo' capturando lo que
                //seleccione a la hora de que se mostro el show dialog arriba

                //aca hago que en la caja de texto se guarde la ruta completa del archivo; devuelve la rut completa y el nombre del archivo
                txtUrlImagen.Text = archivo.FileName;
                //uso el metodo para cargar la imagen el pictureBox
                cargarImagen(archivo.FileName);

                //todavia no se carga la ubicacion de la imagen en la DB; igualmente
                //no es recomendable  guardar la iamgen en la base de datos, es mejor
                //guardar la imagen en un carpeta y en la base de datos hacer referencaia a su ubicacion.

                //guardo la imagen : para poder usar file.copy() tengo que importar
                //el namespace 'using System.IO;'
                //la clase file es una clase esttica, que permite pasar  un origen, una ruta del archivo,
                //y el segundo parametro es una ruta que indica la ubicacion donde se va a alojar

                //sin embargo no lo vamos  hacer aqui, sino que lo vamos a hacer en app.Config
                //, es decir, lo hacemos por archivo de configuracion, por lo que esta dos lineas abajo lo comentamos

                //en el archivo de configuracion (que ya tiene una configuracion default del framework) le agrego la configuracion de mi aplicacion.
                //para poner mi configuracion le agrego las llaves '<appSettings></appSettings>'
                //indico que le quiero agregar <add></add> que av a tener una key=carpetaImaagen y un value=(aca va a ir la ruta de la carpeta)

                //la ruta de la carpeta donde van a estar las copias de las imagenes puede estar dentro del proyecto, pero lo ideal seria qeu cuando despleguemos la app
                //la ruta sea una ruta generica, y no este atada a la ruta del proyecto de la aplicacion. Esto por que si esta atada a la ruta del proyecto va a contener
                //todos los nombres de las carpetas a las que esta enlazada mi proyecto, por eso  en app.config pongo en  value 'value="C:\poke-app\"'
                //por que  en cualquier caso si no existe esa caperta la podemos crear en una instalacion inicial de mi aplicacion y toda computadora va a tener esa carpeta,
                //pero no la ubicacion del documento de mi proyecto
                //Esto se lee en la ruta de value tengo la carpeta de key

                //esto lo hago para que no tenga que escribir la ruta en codigo, sino que la leo diractamente desde el archivo de configuracion; para poder hacerlo tengo que agregar una referencia
                //por lo que voy a referencias dentro de mi proyecto, voy  assembles, y coloco el 'system.configuration', y lo agrego con using arriba.
                //por lo que a partir de ahi voy a pdoer usar el configurationManager.AppSettings, lo que me va a permitir leer lo que tengo en app.config
                //en este caso cuando invoco en appSetting["imges-folder], me va a traer el value, es decir, la ruta correspondiente.
                //y archivo.safeFileName,  que es el nombre del archivo original, aunque en vez de  images-folder, es mejor ponerle, el nombre de la carpeta que 
                //se va a usar, en este caso, pokeapp

                //guardo la imagen: la comento por que no se va a usar aca esa sentencia, sino que se va a utilizr, cuando toque el boton aceptar
                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }

        }
    }
}
