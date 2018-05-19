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
    /// Lógica de interacción para ListarNroContrato.xaml
    /// </summary>
    public partial class ListarNroContrato : Window
    {
        public ListarNroContrato()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            { Contratos con = new Contratos();
               con.NumeroContrato= txtNroContrato.Text;
               
                dtNroContrato.ItemsSource = con.ListarporNroContrato(con.NumeroContrato);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Buscar");
                throw;
            }
        }

        private void btnlimpiar_Click(object sender, RoutedEventArgs e)
        {
            dtNroContrato.ItemsSource = null;
        }
    }
}
