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
    /// Lógica de interacción para FiltrarRutC.xaml
    /// </summary>
    public partial class FiltrarRutC : Window
    {
        public FiltrarRutC()
        {
            InitializeComponent();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Entidades.Clientes Cli = new Biblioteca.Entidades.Clientes();
            Cli.RutCliente = (txtrut.Text);
            Cli.Buscar();
            Contratos con = new Contratos();
            this.tbl_contrato.ItemsSource = con.ListarporRut(Cli.RutCliente);
        }

        private void btn_limpiarClick(object sender, RoutedEventArgs e)
        {
            tbl_contrato.ItemsSource = null;
        }
    }
}
