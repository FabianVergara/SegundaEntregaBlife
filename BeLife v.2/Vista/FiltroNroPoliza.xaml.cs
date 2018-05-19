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
    /// Lógica de interacción para FiltroNroPoliza.xaml
    /// </summary>
    public partial class FiltroNroPoliza : Window
    {
        public FiltroNroPoliza()
        {
            InitializeComponent();
            List<Planes> Listado = new Planes().ListarPlan();
            foreach (Planes item in Listado)
            {
                cbopoliza.Items.Add(item.Nombre);
            }

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Contratos con = new Contratos();
                Planes pla = new Planes();
                if (cbopoliza.SelectedItem.Equals("Seleccione"))
                {
                    MessageBox.Show("Seleccione un Plan");
                }

                if (cbopoliza.SelectedItem.Equals("Vida Inicial"))
                {
                    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("VID01");
                }
                if (cbopoliza.SelectedItem.Equals("Vida Total"))
                {
                    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("VID02");
                }
                if (cbopoliza.SelectedItem.Equals("Vida Conductor"))
                {
                    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("VID03");
                }
                if (cbopoliza.SelectedItem.Equals("Vida Senior"))
                {
                    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("VID04");
                }
                if (cbopoliza.SelectedItem.Equals("Vida Ahorro"))
                {
                    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("VID05");
                }


                //if (cbopoliza.SelectedItem.Equals("POL120113229"))
                //{

                //    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("POL120113229");
                //}
                //if (cbopoliza.SelectedItem.Equals("POL120648575"))
                //{

                //    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("POL120648575");
                //}
                //if (cbopoliza.SelectedItem.Equals("POL125235079"))
                //{
                //    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("POL125235079");
                //}
                //if (cbopoliza.SelectedItem.Equals("POL120100054"))
                //{
                //    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("POL120100054");
                //}
                //if (cbopoliza.SelectedItem.Equals("POL120500489"))
                //{
                //    dtFiltroNP.ItemsSource = con.ListarporNroPoliza("POL120500489");
                //}

            }
            catch (Exception ex)
            {

                Biblioteca.Logger.Mensaje(ex.Message);
                MessageBox.Show("No encuentra contratos");
            }

        }

    

    private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {

            dtFiltroNP.ItemsSource = null;
            
            

        }
    }
}
