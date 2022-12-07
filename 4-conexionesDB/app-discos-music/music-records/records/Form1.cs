using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//este proyecto va a tener una arquitectura basada en calses
//para este ejemplo el modelado de relacion entre clases  en relacion a la base de datos de discos que tenemos va a ser la siguiente:
//la clase disco va a ser la clase que va a modelar a mi objeto principal, osea, la clase principal(objeto):  va a tener como propiedades nombre 'Titulo', 'Fecha de lanzamiento', 'cantidad de canciones';
// a su vez el dico va a  TENER (Asociacion): tipo de estilo y tipo de edicion

//dato a tener en cuenta: no por que yo tenga las tablas: discos, estilos y edicion necesariamente tenga que tener esas clases que constituiran los obbjetos despues, puede pasar o no.
 
namespace records
{
    public partial class Form1 : Form
    {
            private List<Discos> ListaDiscos; //atributo privado ; aca van a guardarse los datos que obtengo los datos de la BD; los guardo en un atributo privado
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //invoco la lectura de base de datos cuando cargue el formulario
        {
            //para poder mostrar la imagen en el picture box tengo que guardar la lista que obtengo y que le paso directamente a dgvDiscos.dataSource
            //voy a guardarlo en una lista para, variable para poder manipularlo : lo guardo en ListaDiscos

            //para acceder a mis datos
            DiscosNegocio negocio = new DiscosNegocio(); //para poder utilizar mi metodo listar
            ListaDiscos  = negocio.listar();
            dgvDiscos.DataSource = ListaDiscos; //en el control dgv voy a mostrar lo que tiene mi metodo listar, que v a ala base de datos y devuelve una lsita de datos
            //data source lo recibe y lo modela en la tabla, lee la estrucutra de la clase disco , mediante una tecnica llamada reflection en sistemas,  y con esas propiedades
            //genera  automaticamente cada propiedad en cada columna

            cargarImagen(ListaDiscos[0].UrlImagen); //Aca quiero que cuadno cargue el formulario, me devuelva la imagen de la url del primer pokemon de la lista

        }

        //arriba mostre como cuando carga el form devuelve el primer objeto.
        //abajo como cuando yo cambie de valor en la lista, me va a devolver la imagen correspondiente a su url
        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {//ocurre cuando cambia la seleccion de la grilla. Esto apra que pueda cambiar cada ves que quiero
            //primero: tomo el elemento que esta seleccionado en la grilla
            Discos seleccionado= (Discos)dgvDiscos.CurrentRow.DataBoundItem;// de la fila actual quiero obtener el objeto que tiene cada fila; devuelve un objeto generico, pero como
            //yo se que contiene como objeto un disco, por lo que le hago un caasteo explicito que va a indicar que ese objeto es de tipo pokemon y lo guardo
            //en una variable de tipo pokemon: esto se lee: pokemon seleccionado, de la grilla de la fila actual el objeto acvtual transformado en pokemon(casteo)lo guardo en la variable

            //entonces
            cargarImagen(seleccionado.UrlImagen); 



        }
            //voy a crear un metodo para que modularizar, encapsular, 'pvDiscos.load(Selelcionado.Urlimagen)', y para controlar las excepciones en caso de que por ejemplo,
            //una imagen no cargue y lance una excepcion

            private void cargarImagen(string imagen)
            {
                try
                {
                    pbDiscos.Load(imagen); //si esta todo bien ejecuta esto
                }
                catch (Exception ex)
                {
                    //si esta todo mal muestra esto; si no carga la imagen o hay algun error, si la url es invalida etc:muestra img vacia
                    pbDiscos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                }
            }
    }
}
