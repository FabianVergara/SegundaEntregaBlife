using Biblioteca.DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
    public class Contratos
    {
        public String Numero { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaTermino { get; set; }
        public String Titular { get; set; }
        public String Poliza{ get; set; }
        public String PlanAsociado { get; set; }
        
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public Boolean Vigente { get; set; }
        public Boolean DeclaracionSalud { get; set; }//boolean estado checkbox
        public Double PrimaAnual { get; set; }
        public Double PrimaMensual { get; set; }
        public String Observaciones { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;

        public Contratos()
        {
            Entidades = new BeLifeEntities();

        }
        //METODOS CRUD
        public bool GrabarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;
                Con = new DALC.Contrato();
                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();
                Biblioteca.Entidades.Tarificador Tar;
                Tar = new Tarificador();

                
                Con.Numero = this.Numero;
                Con.FechaCreacion = this.FechaCreacion;
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                //creo que debo recorrer los planes para saber que la poliza pertenece a cierto plan
                Plan.PolizaActual = this.Poliza;//Poliza
                Con.FechaInicioVigencia = this.FechaInicioVigencia;
                Con.FechaFinVigencia = FechaInicioVigencia.AddDays(365);
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.DeclaracionSalud;
                //Con.PrimaAnual=Tar.calculoPrimasanual(Plan.PolizaActual,Con.RutCliente);
                Con.PrimaAnual = this.PrimaAnual;
                //Con.PrimaAnual=Tar.calculoPrimasmensual(Plan.PolizaActual,Con.RutCliente);
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;
               
                Entidades.Contrato.Add(Con);
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool EliminarContrato()
        {
            try
            {

                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(Numero));
                Con.Vigente = this.Vigente;//Modificar el estado a no vigente
                Con.FechaTermino = this.FechaTermino;
                //fecha fin al contrato *
                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }
        }

        public bool ActualizarContrato()
        {
            try
            {
                Biblioteca.DALC.Contrato Con;

                Con = Entidades.Contrato.First(a => a.Numero.Equals(Numero));

                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();

                Con.Numero = this.Numero;
                Con.FechaCreacion = this.FechaCreacion;
                //Con.FechaFechaTermino = this.FechaTermino;//no puede ser modificada
                Con.RutCliente = this.Titular;
                Con.CodigoPlan = this.PlanAsociado;
                //Plan.BuscarPlan(Con.CodigoPlan);
                //Plan.PolizaActual = this.Poliza;
                Con.FechaInicioVigencia = this.FechaInicioVigencia;
                Con.FechaFinVigencia = this.FechaFinVigencia;
                Con.Vigente = this.Vigente;
                Con.DeclaracionSalud = this.DeclaracionSalud;
                Con.PrimaAnual = this.PrimaAnual;
                Con.PrimaMensual = this.PrimaMensual;
                Con.Observaciones = this.Observaciones;


                Entidades.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }

        }

        public bool BuscarContrato()
        {
            try
            {
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(Numero));
                this.Numero = Con.Numero;
                this.FechaCreacion = Con.FechaCreacion;
                this.FechaTermino = Con.FechaTermino == null ? DateTime.Now.AddYears(10): (DateTime)Con.FechaTermino;
                this.Titular = Con.RutCliente;
                this.PlanAsociado = Con.CodigoPlan;
                Plan.BuscarPlan(Con.CodigoPlan);//esto esta bien
                this.Poliza = Plan.PolizaActual;
                this.FechaInicioVigencia = Con.FechaInicioVigencia;
                this.FechaFinVigencia = Con.FechaFinVigencia;
                this.Vigente = Con.Vigente;
                this.DeclaracionSalud = Con.DeclaracionSalud;
                this.PrimaAnual = Con.PrimaAnual;
                this.PrimaMensual = Con.PrimaMensual;
                this.Observaciones = Con.Observaciones;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }


        }

        public List<Contratos> ListarTodo()
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = Entidades.Contrato.ToList();

                Biblioteca.Entidades.Planes Plan;
                Plan = new Planes();

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.Numero = item.Numero;
                    Con.FechaCreacion = item.FechaCreacion;
                    Con.FechaTermino =item.FechaTermino == null ? DateTime.Now.AddYears(10): (DateTime)item.FechaTermino; 
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Plan.BuscarPlan(item.CodigoPlan); 
                    Con.Poliza = Plan.PolizaActual;
                    Con.FechaInicioVigencia = item.FechaInicioVigencia;
                    Con.FechaFinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.DeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }
        }
        public List<Contratos> ListarporNroContrato(string Numero)
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from c in Entidades.Contrato
                                     where c.Numero == Numero
                                     select c;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.Numero = item.Numero;
                    Con.FechaCreacion = item.FechaCreacion;
                    Con.FechaTermino = item.FechaTermino == null ? DateTime.Now.AddYears(10): (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.FechaInicioVigencia = item.FechaInicioVigencia;
                    Con.FechaFinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.DeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        public List<Contratos> ListarporRut(String Rut)
        {
            try
            {
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from r in Entidades.Contrato
                                     where r.RutCliente == Rut
                                     select r;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.Numero = item.Numero;
                    Con.FechaCreacion = item.FechaCreacion;
                    Con.FechaTermino = item.FechaTermino == null ? DateTime.Now.AddYears(10) : (DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.FechaInicioVigencia = item.FechaInicioVigencia;
                    Con.FechaFinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.DeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }
        //FILTRAR POR NUMERO DE POLIZA ???
        public List<Contratos> ListarporNroPoliza(String CodigoPlan)
        {
            try
            {
                //hay que corregir lo de poliza para que esto funcione
                List<Contratos> ListadoContrato = new List<Contratos>();
                var ContratoModelo = from con in Entidades.Contrato
                                     where con.CodigoPlan == CodigoPlan
                                     select con;

                foreach (var item in ContratoModelo)
                {
                    Contratos Con = new Contratos();

                    Con.Numero = item.Numero;
                    Con.FechaCreacion = item.FechaCreacion;
                    Con.FechaTermino = item.FechaTermino == null ? DateTime.Now.AddYears(10):(DateTime)item.FechaTermino;
                    Con.Titular = item.RutCliente;
                    Con.PlanAsociado = item.CodigoPlan;
                    Con.Poliza = item.Plan.PolizaActual;
                    Con.FechaInicioVigencia = item.FechaInicioVigencia;
                    Con.FechaFinVigencia = item.FechaFinVigencia;
                    Con.Vigente = item.Vigente;
                    Con.DeclaracionSalud = item.DeclaracionSalud;
                    Con.PrimaAnual = item.PrimaAnual;
                    Con.PrimaMensual = item.PrimaMensual;
                    Con.Observaciones = item.Observaciones;
                    ListadoContrato.Add(Con);
                }

                return ListadoContrato;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }

        }

        public bool BuscarContrato(String Codigo)
        {
            try
            {
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.DALC.Contrato Con;
                Con = Entidades.Contrato.First(a => a.Numero.Equals(Codigo));
                this.Numero = Con.Numero;
                this.FechaCreacion = Con.FechaCreacion;
                this.FechaTermino = (DateTime)Con.FechaTermino;
                this.Titular = Con.RutCliente;
                this.PlanAsociado = Con.CodigoPlan;
                Plan.BuscarPlan(Con.CodigoPlan);//esto esta bien
                this.Poliza = Plan.PolizaActual;
                this.FechaInicioVigencia = Con.FechaInicioVigencia;
                this.FechaFinVigencia = Con.FechaFinVigencia;
                this.Vigente = Con.Vigente;
                this.DeclaracionSalud = Con.DeclaracionSalud;
                this.PrimaAnual = Con.PrimaAnual;
                this.PrimaMensual = Con.PrimaMensual;
                this.Observaciones = Con.Observaciones;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return false;
            }


        }


    }




}

