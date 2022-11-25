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
    public partial class frmVentanaInterior : Form
    {
        public frmVentanaInterior()
        {
            InitializeComponent();
        }

        private void btnNombre_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            lvlNombreDevuelto.Text = nombre;
        }

       
    }
}
