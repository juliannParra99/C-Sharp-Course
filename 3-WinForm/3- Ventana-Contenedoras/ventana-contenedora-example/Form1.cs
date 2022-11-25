using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventana_contenedora_example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //arquitectura ventanas pares e hijas: que una ventana englobe entro otra ventana
            //esta ventana va a ser la pantalla principal y la ventana padre(la que contiene otra ventana)
            //para eso usamos la propiedad IsMdiContainer en true; es una alternativa de diseño
            InitializeComponent();
        }

       

        private void abrirfrmVentanaInteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //para que no se abran muchas ventanas con el metodo show(), cualquier objeto que herede de Form
            //y que esten Abiertos en ese momento esta dentro de la collection OpenForm().voy a recorrer esa coleccion con for each, y si hay
            //abierto un objeto ventana  
            //
            foreach (var item in Application.OpenForms)//voy a recorrer los elementos de esa coleccion uno por uno
            {
                //el getType(), devuelve el tipo de objeto; y el typeOf especfica el tipo del dato; en este caso comparo dos tipos
                //lo que hago aca es: si dentro de la collecion que itero hay un formulario que es igual al tipo de objeto que yo estoy buscando y que
                //yo estoy queriendo abrir de nuevo, es decir si ya HAY UNO ABIERTO, corto esa ejecucion  con return y no lo abro.
                // el return corta la ejecucion; detecta que ya hay una ventana abierta de ese tipo y concluye la ejecucion del clic, antes de que se ejecute el codigo posterior
                if (item.GetType() == typeof(frmVentanaInterior))
                {
                    MessageBox.Show("ya hay abierta una ventana identica a la que quiere ejecutar.Utilice esa o cierrela y vuelvala a abrir");
                    return ;
                }
            }
    

            frmVentanaInterior ventana = new frmVentanaInterior();
            //una ves instanaciado el objeto, le digo que va a tener un parent
            ventana.MdiParent = this;//la ventana que va a ser padre, en este caso la ventana en la que estoy parado (this)
            //no se puede usar showdialog para msotrar la ventana hija, por que este metodo indica que la ventana hija tiene el control
            //y hay que  cerrarla primero para poder hacer otras cosas, pero al estar dentro de una ventana padre no es logicamente
            //coherente. Uso Show(), pero eso hace que pueda abrir multiples ventanas, lo que hay que solucionar:Eso lo hago con
            //aplication.OpenForms(), esta ultima propiedad es una collecion de objetos ventana, que indica cuales y que forms estan abiertos.
            ventana.Show();

            //para que la pantalla aparezca maximizada uso windpwsState() 
        }
    }
}
