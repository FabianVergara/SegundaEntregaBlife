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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            wpfIngresoCliente ic = new wpfIngresoCliente();
            ic.ShowDialog();//bloquea que se salga hasta q cierre


        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
         MessageBoxResult resul=   MessageBox.Show("¿Desea salir ?", "Salir", MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resul==MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Se arrepintio pillin");
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//argumento e
        {
            MessageBoxResult resul = MessageBox.Show("¿Desea salir ?", "Salir", MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resul == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                
                e.Cancel = true;//cancelo el evento lo cambio
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            BuscarCliente lr = new BuscarCliente();
            lr.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MenuCliente cl = new MenuCliente();
            cl.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MenuContrato co = new MenuContrato();
            co.ShowDialog();
        }
    }
}
