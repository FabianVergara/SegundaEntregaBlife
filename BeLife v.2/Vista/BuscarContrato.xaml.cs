using System;
using System.Collections.Generic;
using System.Data;
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
using Biblioteca.DALC;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para BuscarContrato.xaml
    /// </summary>
    public partial class BuscarContrato : Window
    {

        

        public BuscarContrato()
        {
            InitializeComponent();
            


        }


        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Entidades.Contratos con = new Biblioteca.Entidades.Contratos();
            con.NumeroContrato =( txt_idcontrato.Text);
            con.BuscarContrato();
            this.tbl_contrato.ItemsSource = new List<Contratos>() { con };//asumo que este comando toma los datos de contrato
            

        }

        private void btn_listar_Click(object sender, RoutedEventArgs e)
        {
            Biblioteca.Entidades.Contratos con = new Biblioteca.Entidades.Contratos();
            con.NumeroContrato = txt_idcontrato.Text;
            this.tbl_contrato.ItemsSource = con.ListarTodo();
            
            


        }

       

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

          
            Contratos con = new Contratos();
            con.Termino = DateTime.Now;
            DataRowView filaseleccionada = tbl_contrato.SelectedItem as DataRowView;
            Contratos filacon =(Contratos)tbl_contrato.SelectedItem;
            if (filacon==null)
            {
                MessageBox.Show("Debe seleccionar un contrato");
            }
            MessageBoxResult respuesta;

            respuesta = MessageBox.Show("¿Desea continuar?", "Seleccione una Opcion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)

            {
                string columnaNumero = filacon.NumeroContrato;
                con.NumeroContrato= columnaNumero;

                bool Eliminar = con.EliminarContrato();


                if (Eliminar == true)

                {

                    MessageBox.Show("Contrato eliminado");
                    Biblioteca.Entidades.Contratos cont = new Biblioteca.Entidades.Contratos();
                    cont.NumeroContrato = txt_idcontrato.Text;
                    this.tbl_contrato.ItemsSource = cont.ListarTodo();

                }

                else MessageBox.Show("Contrato no se ha podido eliminar");

            }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void btnrefrescar_Click(object sender, RoutedEventArgs e)
        {
            tbl_contrato.ItemsSource = null;
        }
    }
}
