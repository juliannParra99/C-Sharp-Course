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

//se crea un nuevo constructor.
//se crea nuevo atributo: private Pokemon pokemon = null, que cuando  utilize el boton "agregar " en frmPokemons va a estar nulo por el constructor, y cuando use modifcar
//el constructor va  a estar sobrecargado y va a estar cargado con un pokemon que viene de otra ventana y que se le pasa por parametro al constructor

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }
        //este se utiliza en modificar, lo que hace que ela atributo pokemon tenga como valor el pokemon pasado por parametro
        //lo que queremos es que se precargen los datos existentes en los controles; por lo que voy al evento load del form
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            //para que se modifique el nombre del form si se toca en 'modificar'
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //como estoy utilizando el frmAltaPokemon para que inserte nuevos pokemos y modifique pokemons existentes,
        //tengo que darle la inteligencia a mi aplicacion para que cuando toco en agregar "inserte el nuevo pokemon", y cuando
        //toque 'modificar'  modifique.

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //se borro variable Pokemon poke = new Pokemon(); por que yo ya tengo una variable que se llama pokemon, y que es el atributo privado
            // que esta arriba de todo y que esta en null, por lo que voy a usar esa variable pokemon sea que inserte o modifique
            //cuando toque 'aceptar', esto para no tener que escribir codigo dos veces, para insertar y modificar

            PokemonNegocio negocio = new PokemonNegocio();

                //se realiza validacion por que si no se hace se rompe por que estoy queriendo cargar la propiedad de un objeto que esta en nulo
                //se realiza la validacion con el if
            try
            {
                //antes de asignar  las propiedades: si vos tocaste aceptar y el pókemon esta en nullo vos queres AGREGAR un pokemon nuevo , entonces
                // entonces creo un pokemon nuevo.
                if (pokemon == null)
                    pokemon = new Pokemon(); //convierto ese pokemon nulo en un objeto pokemon que puedoa gregar; por que si esta en null el valor
                //quiere decir que vos tocaste en AGREGAR, entonces te genero el nuevo pokemon y te cargo lo datos.Si no esta nulo quiere decir
                //que hay un pokemon por lo que voy a sobreescribir los datos viejos con los nuevos
                //

                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;

                //ya puediendo manejar los datos del objeto.Voy a ejetucar el negocio.modificar() o el negocio.agregar()

                //para saber cual de los dos se ejecutara digo: si queres modificar un pokemon ese pokemon ya tiene un ID existente
                //y sie stas por agregar un pokemon ese pokemon en la BD NO existe por lo que no tiene id
                if(pokemon.Id != 0) //por que si no es 0 es otro numero por lo que el pokemon YA EXISTIA, por lo que es modificar
                    //tenemos que agregar la property ID por que antes no le dabamos uso pero ahora la necesitamos
                {//agrego el modificar
                    negocio.modificar(pokemon); //le doy vida al metodo modificar en negocio
                    MessageBox.Show("Modificado exitosamente");
                }
                else 
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //para que se precarguen los datos existentes de  ese pokemon: voy a hacer una validacion
        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                //le cargo al desplegable una lsita de elementos
                cboTipo.DataSource = elementoNegocio.listar();
                //aca voy a indicar el valor que quiero que este seleccionado por defecto en el comboBox, y que coincida con los datos del pokemon ya existente
                //"id" y "descripcion" son los nombres de las propiedades de la clase elemento.
                //en este caso lo que se hace establecer del objeto(clse) del que queremos mostrar una propiedad, establecemos una clave,
                // que  va a ser el que va a ser quien me permita acceder al valor que quiero. Y un valor, que es el valor que se muestra
                //cauando llamamos a la vlave. En este caso la clave la contiene valueMember y DisplayMember contiene el valor al que accedemos
                //con esto todavia no cambia nada: pero si el pokemon fue distinto de nulo, le voy a preseleccionar un valor. Ver
                //en el if debajo del metodo CargarImagen
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                //aqui la validacion: SI el pokemon es distinto de nulo es un modificar; es distinto de nulo entonce4s hay pokemon para modificar, entonce slo tengo que PRECARGAR con los datos existentes
                if(pokemon != null)
                {
                    //aca voy a tener que traer el IdTipo y IdDebilidad, por que sino no se va a mostrar. por lo que tengo que 
                    //modicar la consulta en pokemonNegocio para que me traiga los datos d el db. Por que si no esta el id aca, no voy a poder acceder
                    //desde aca al valor asociado a esa clave
                    txtNumero.Text = pokemon.Numero.ToString(); //toString() por que es un numero
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    //hasta aca precargo los datos.
                    //
                    //el metodo cargar imagen para que cuando abrimos el modificar la imagen se muestre desde el comienzo y no despues de que tocamos el txtUrlImagen y tocamos tab
                    cargarImagen(pokemon.UrlImagen);
                    //el valor seleccionado de cboTipo, que en este caso corresponde a un Id, va a ser igual al pokemon.Tipo.Id (la clave que va  llamar al valor)
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
    }
}
