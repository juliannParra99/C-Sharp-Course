using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void perfilPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //para navegar a otra ventana es como acceder a la ventana principal: declaro la instancia de un objeto para acceder a sus propiedes
            //creo la variable del tipo del objeto que quiero acceder y le isntancio el mismo objeto-

            Form1 ventana = new Form1();
            ventana.ShowDialog();// hace que no se instancian nuevos objetos cada vez que hago clik en perfil persona, solo permite ver uno;
                // a diferencia de ventana.show, que permite ver muchas ventanas por que cada vez instancia nuevos objetos. 
        }

        private void tsbPerfilPersona_Click(object sender, EventArgs e)
        {
            Form1 ventana = new Form1();
            ventana.ShowDialog();
        }
    }
}
