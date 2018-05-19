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
using Biblioteca.Entidades;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class ActualizarCli : Window
    {
        public ActualizarCli()
        {
            InitializeComponent();

            List<Biblioteca.Entidades.Sexos> Listado = new Biblioteca.Entidades.Sexos().ListarSexo();
            foreach (Biblioteca.Entidades.Sexos item in Listado)
            {
                cboSexo.Items.Add(item.Descripcion);
            }

            List<EstadosCiviles> Listado2 = new EstadosCiviles().ListarEstadoCivil();
            foreach (EstadosCiviles item in Listado2)
            {
                cboEstado.Items.Add(item.Descripcion);
            }
        }

        public void cargaActuaizar(Clientes cli) {

            label.Visibility=Visibility.Hidden;
            txtRut.Visibility = Visibility.Hidden;
            btn_cargardatos.Visibility = Visibility.Hidden;

            lbl1.Visibility = Visibility.Visible;
            lblrut1.Visibility = Visibility.Visible;

            lblrut1.Content = cli.RutCliente;
            txtnNombre.Text = cli.Nombres;
            txtApellido.Text = cli.Apellidos;
            dpkFechaNaci.SelectedDate = cli.FechaNaci;
            cboSexo.SelectedItem = cli.IdSexo;




        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {

            Clientes cli = new Clientes();
            cli.RutCliente = txtRut.Text;
            cli.Nombres = txtnNombre.Text;
            cli.Apellidos = txtApellido.Text;

            DateTime fechahoy = DateTime.Now;//para contrato
                                             // string formatoDeOro = fechahoy.ToString("YYYYMMDDHHmmSS");//

            cli.FechaNaci = (DateTime)dpkFechaNaci.SelectedDate;
            int edad = (DateTime.Now.Year - cli.FechaNaci.Year);
            if (edad < 18)
            {
                lbl_edad.Content = ("Debe ser mayor de 18 años");
                lbl_edad.Foreground = Brushes.Red;
                dpkFechaNaci.Focus();
                return;
            }
            cli.IdSexo = cboSexo.SelectedIndex + 1;
            cli.IdEstadoCivil = cboEstado.SelectedIndex + 1;
            bool resp = cli.Modificar();
            if (resp == true)
            {
                MessageBox.Show("Actualiza Cliente con exito");
            }
            else
            {
                MessageBox.Show("NO Actualizó Cliente");
            }

        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Text = "";
            txtnNombre.Text = "";
            txtApellido.Text = "";
            dpkFechaNaci.SelectedDate = DateTime.Now;
            cboSexo.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }

        private void btn_cargardatos_Click(object sender, RoutedEventArgs e)
        {
            Clientes cli = new Clientes();
            EstadosCiviles esciv = new EstadosCiviles();
            Sexos se = new Sexos();
            cli.RutCliente = txtRut.Text;
            
            if (cli.Buscar() == true)
            {
                txtnNombre.Text = Convert.ToString(cli.Nombres);
                txtApellido.Text = Convert.ToString(cli.Apellidos);
                dpkFechaNaci.SelectedDate = cli.FechaNaci;
                se.BuscarSexo(""+cli.IdSexo);
                
                cboSexo.SelectedIndex=cli.IdSexo-1;
                 
                esciv.BuscarEstadosCiviles(""+cli.IdEstadoCivil);
             
                cboEstado.SelectedIndex=cli.IdEstadoCivil-1;
               



            }
            else
            {
                MessageBox.Show("Cliente no ha sido encontrado");
            }
        }
    }
}
