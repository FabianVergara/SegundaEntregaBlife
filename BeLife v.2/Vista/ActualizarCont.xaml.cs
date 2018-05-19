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
    /// Lógica de interacción para ActualizarCont.xaml
    /// </summary>
    public partial class ActualizarCont : Window
    {
        public ActualizarCont()
        {
            InitializeComponent();
            List<Planes> Listado = new Planes().ListarPlan();
            foreach (Planes item in Listado)
            {
                cbo_plan.Items.Add(item.Nombre);
            }
        }

        private void btn_cargardatos_Click(object sender, RoutedEventArgs e)
        {
            Contratos con = new Contratos();
            con.NumeroContrato = txtcon.Text;
            bool bus = con.BuscarContrato();
            Planes pl = new Planes();
            if (bus == true)
            {
                string rut = con.Titular;
                Clientes cli = new Clientes();
                cli.RutCliente = rut;
                cli.Buscar();
                string nomcom = String.Concat(cli.Nombres, " ", cli.Apellidos);
                lbl_NomApe.DataContext = nomcom;
                lbl_NomApe.FontSize = 16;
                lbl_NomApe.Focus();

                

                pl.BuscarPlan( con.PlanAsociado);


                cbo_plan.SelectedItem = pl.Nombre;
                chk_salud.IsChecked = con.ConDeclaracionSalud;
                txt_obs.Text = con.Observaciones;


            }
            else
            {
                MessageBox.Show("Introduzca un contrato valido");
            }
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //validar si es cliente
                Contratos Con = new Contratos();
                Clientes cli = new Clientes();
               // cli.RutCliente = txtcon.Text;
                Con.NumeroContrato= txtcon.Text;
                Boolean bus = Con.BuscarContrato();
                if (bus == true)
                {

                    Biblioteca.Entidades.Planes Plan;
                    Plan = new Planes();
                    Biblioteca.Entidades.Tarificador Tar;
                    Tar = new Tarificador();


                    if (cbo_plan.SelectedItem.Equals("Vida Inicial"))
                    { Con.PlanAsociado = "VID01"; }
                    else
                    {
                        if (cbo_plan.SelectedItem.Equals("Vida Total"))
                        {
                            Con.PlanAsociado = "VID02";
                        }
                        else
                        {
                            if (cbo_plan.SelectedItem.Equals("Vida Conductor"))
                            {
                                Con.PlanAsociado = "VID03";
                            }
                            else
                            {
                                if (cbo_plan.SelectedItem.Equals("Vida Senior"))
                                {
                                    Con.PlanAsociado = "VID04";
                                }
                                else
                                {
                                    if (cbo_plan.SelectedItem.Equals("Vida Ahorro"))
                                    {
                                        Con.PlanAsociado = "VID05";
                                    }

                                }
                            }
                        }
                    }
                    if (chk_salud.IsChecked == true)
                    { Con.ConDeclaracionSalud = true; }
                    else
                    {
                        Con.ConDeclaracionSalud = false;
                    }
                    Con.Observaciones = txt_obs.Text;
                    bool resp = Con.ActualizarContrato();
                    if (resp == true)
                    {
                        MessageBox.Show("se actualizo el contrato");

                    }
                    else
                    {
                        MessageBox.Show("no se creo");
                    }

                }
                else
                {
                    MessageBox.Show("El Contrato no ha sido actualizado");
                }


            }
            catch (Exception ex)
            {

                Biblioteca.Logger.Mensaje(ex.Message);
            }

        }
    }
    }


