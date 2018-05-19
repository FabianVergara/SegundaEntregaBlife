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
using System.Data;
//using Biblioteca.DALC;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para BuscarCliente.xaml
    /// </summary>
    public partial class BuscarCliente : Window
    {
        //Clientes cl = new Clientes();
        public BuscarCliente()
        {
            InitializeComponent();
            
        }

      

    

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Entidades.Clientes Cli = new Biblioteca.Entidades.Clientes();
            Cli.Buscar();
            this.dtListado.ItemsSource = Cli.ListarTodo();
            btnActualizar.Visibility = Visibility.Visible;

        }

        private void btn_buscarcli_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Entidades.Clientes Cli = new Biblioteca.Entidades.Clientes();
            Cli.RutCliente = (txt_rutcli.Text);
            Cli.Buscar();
            this.dtListado.ItemsSource = new List<Clientes>() {Cli  };

            btnActualizar.Visibility = Visibility.Visible;


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            Biblioteca.Entidades.Clientes cli = new Biblioteca.Entidades.Clientes();
            Boolean Eliminar;

            DataRowView filaseleccionada = dtListado.SelectedItem as DataRowView;
            Clientes filaC = (Clientes)dtListado.SelectedItem;
            
            if (filaC == null)
            {

                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButton.OK);
                return;

            }
            MessageBoxResult respuesta;

            respuesta = MessageBox.Show("¿Desea continuar?", "Seleccione una Opcion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)

            {
                string columnaNumero = filaC.RutCliente;
                cli.RutCliente = columnaNumero;

                Eliminar = cli.Eliminar();

                if (Eliminar == true)

                {

                    MessageBox.Show("Cliente eliminado");
                    
                }

                else MessageBox.Show("Cliente no se ha podido eliminar");

            }
            
        }

        private void btnrefrescar_Click(object sender, RoutedEventArgs e)
        {
            dtListado.ItemsSource = null;
        }

        private void dtListado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            
            Biblioteca.Entidades.Clientes cli = new Biblioteca.Entidades.Clientes();
            DataRowView filaseleccionada = dtListado.SelectedItem as DataRowView;
            Clientes filaC = (Clientes)dtListado.SelectedItem;
            if (filaC == null)
            {

                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButton.OK);
                return;

            }



            ActualizarCli ac = new ActualizarCli();
            ac.cargaActuaizar(filaC);
            ac.ShowDialog();
        }
    }
}
