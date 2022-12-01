using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//2 tipos de errores : 
//error de compilacion: error de sintaxisd, se escribio mal algo; el compilador no puede compilar, es sensillo de resolver por que el compilador
//dice donde estan las lineas.
// Error de excepcion: error no esperado en algun momento de la ejecucion; sucede en un momento excepcional.
// el programa compila pero en un punto el programa se detiene, falla abruptamente en algun momento etc.error ent tiempo de ejecucion
//las excepciones permiten que preparemos nuestras app para que en escenarios no pensados la aplicacion no crashee.
//el manejo de excepciones nos permiten capturar el error en el  momento, y en vez de que la app responda de manera defectuosa, nuestra
//app este preparada para esa circunstancia, y hace algo en consecuencia: validar el dato, mandar un mail etc. 
//para eso usamos un try catch
namespace exceptionExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //para manejar las excepciones: si coloco una letra en lugar de un numero, me devuelve una excepcion por que no es el formato
            //esperado, por lo que lo capturamos.
            //try va a intentar ejecutar el codigo de dentro
            //las intrucciones operatorias con logicas van dentro

            //el catch lo que  hace es ir recorriendo linea por linea y verifica si se ejecuto y pasa a la siguiente, si hay un error,
            //el bloque catch lo captura como excepcion y trabaja y trata que se va a realizar cuando ocurre la excepcion
            //puedo poner tantos catch como yo quiera de acuerdo a las excepciones que quiera manejar:exeption  es la general
            int resultado;
            try
            {
                resultado = Calcular();
                lblResultado.Text = " = " + resultado;
            }
            catch (Exception ex)//exception general.
            {
                MessageBox.Show("Error no reconocido, contacte a su dev: " + ex.ToString()); 
            }
            finally
            {
        //el finally se va a ejecutar si o si, no importa si hay un error en el try y salta al catch con codigo que no termino de
        //ejecturarse; despues del catch se va a ejecutar. ej. se abre base de datos en try, hay error salta al catch, pero no se cierra
        //la DB por lo que en el finally se ejecuta que ahi se cierra la DB

            }
        }   
        
        private int Calcular() // este metodo se pasa al evento click, genera un doble try catch OJO CON ESTO
        {
                int a, b, r;//las inicializaciones pueden estar fuera
            try
            {
                a = int.Parse(txt1.Text);
                b = int.Parse(tx2.Text);//aca hay un error por que no se pueden transformar una letra en entero; lanza exeption y va al catch
                r = a + b;
                return r;
            }
            catch (Exception ex)
            {

                throw ex; //lanza una excepcion si algo sale mal; LOS METODOS QUE PUEDEN DEVOLVER UNA EXCEPCION TAMBIEND DEBEN ESTAR CAPTURADOS EN UN TRY CATCH
            }
        }

    }
}

