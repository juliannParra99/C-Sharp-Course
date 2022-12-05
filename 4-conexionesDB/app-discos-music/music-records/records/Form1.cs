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
        public Form1()
        {
            InitializeComponent();
        }
    }
}
