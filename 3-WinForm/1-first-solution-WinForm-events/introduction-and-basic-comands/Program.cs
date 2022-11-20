using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace introduction_and_basic_comands
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()//funcion que se encarga de disparar la aplicacion
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); //la ventana que ponga aca va a ser la ventana principal; se pasa en forma de objeto
            //por que instancia la clase form,crea el objeto form y el constructor inicializa todas las propiedades de la interfaz
        }
    }
}
