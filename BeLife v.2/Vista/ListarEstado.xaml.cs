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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ListarEstado.xaml
    /// </summary>
    public partial class ListarEstado : Window
    {
        public ListarEstado()
        {
            InitializeComponent();
            List<EstadosCiviles> Listado2 = new EstadosCiviles().ListarEstadoCivil();
            foreach (EstadosCiviles item in Listado2)
            {
                cboestado.Items.Add(item.Descripcion);
            }
        }

        private void btn_filtrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clientes cli = new Clientes();
                if (cboestado.SelectedIndex == -1)
                { 
                    MessageBox.Show("Seleccione un filtro");
                }
                if (cboestado.SelectedIndex == 0)
                {
                    dtestado.ItemsSource = cli.ListarPorEstciv(1);
                }
                if (cboestado.SelectedIndex == 1)
                {
                    dtestado.ItemsSource = cli.ListarPorEstciv(2);
                }
                if (cboestado.SelectedIndex == 2)
                {
                    dtestado.ItemsSource = cli.ListarPorEstciv(3);
                }
                if (cboestado.SelectedIndex == 3)
                {
                    dtestado.ItemsSource = cli.ListarPorEstciv(4);
                }
            }
            catch (Exception ex)
            {

                Biblioteca.Logger.Mensaje(ex.Message);
                
            }
            
           
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            dtestado.ItemsSource = null;
        }
    }
}
