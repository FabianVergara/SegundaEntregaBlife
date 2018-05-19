using Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using Biblioteca.Entidades;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para wpfIngresoCliente.xaml
    /// </summary>
    public partial class wpfIngresoCliente : Window
    {
        public wpfIngresoCliente()
        {
            InitializeComponent();

           List<Biblioteca.Entidades.Sexos> Listado = new Biblioteca.Entidades.Sexos().ListarSexo();
            foreach (Biblioteca.Entidades.Sexos item in Listado)
            {
                cboSexo.Items.Add(item.Descripcion);
            }

            List<EstadosCiviles> Listado2= new EstadosCiviles().ListarEstadoCivil();
            foreach (EstadosCiviles item in Listado2)
            {
                cboEstado.Items.Add(item.Descripcion);
            }
        }

       

        private void ingresar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtRut.Text.Trim().Length==10))
                {
                    lblRut.Content=("ingrese un rut");
                    lblRut.Foreground = Brushes.Red;
                    txtRut.Focus();
                    return;
                }
                Clientes cli = new Clientes();
                cli.RutCliente = txtRut.Text;
                cli.Nombres = txtnNombre.Text;
                cli.Apellidos = txtApellido.Text;

               DateTime fechahoy = DateTime.Now;//para contrato
                                                // string formatoDeOro = fechahoy.ToString("YYYYMMDDHHmmSS");//
                
                cli.FechaNaci = (DateTime)dpkFechaNaci.SelectedDate;
                int edad = (DateTime.Now.Year - cli.FechaNaci.Year);
                if (edad<18)
                {
                    lbl_edad.Content = ("Debe ser mayor de 18 años");
                    lbl_edad.Foreground = Brushes.Red;
                    dpkFechaNaci.Focus();
                    return;
                }
                cli.IdSexo = cboSexo.SelectedIndex+1;
                cli.IdEstadoCivil = cboEstado.SelectedIndex+1;
                bool resp = cli.Grabar();
                if (resp == true)
                {
                    MessageBox.Show("Ingreso Cliente con exito");
                }
                else
                {
                    MessageBox.Show("No se pudo Ingresar al Cliente");
                }
            }
            catch (AggregateException errControlado)
            {
                //mesajes de reglas de negocio
                MessageBox.Show(errControlado.Message);

            }
            catch (Exception ex)
            {
                Biblioteca.Logger.Mensaje(ex.Message);
                MessageBox.Show("No se pudo Ingresar al Cliente");
            }
        }

       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            txtnNombre.Text = "";
            txtApellido.Text="";
            dpkFechaNaci.SelectedDate= DateTime.Now;
            cboSexo.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }
    }
}
