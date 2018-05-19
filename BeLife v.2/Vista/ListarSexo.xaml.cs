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
    /// Lógica de interacción para ListarSexo.xaml
    /// </summary>
    public partial class ListarSexo : Window
    {
        public ListarSexo()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clientes Cli = new Clientes();
                if (cbo_Sexo.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un filtro");
                }

                if (cbo_Sexo.SelectedIndex == 1)
                {
                    dtSexo.ItemsSource = Cli.ListarPorSexo(1);
                }
                if (cbo_Sexo.SelectedIndex == 2)
                {
                    dtSexo.ItemsSource = Cli.ListarPorSexo(2);
                }
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}
