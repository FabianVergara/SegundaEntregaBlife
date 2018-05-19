using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Entidades
{
    public class Planes
    {
        public String Id { get; set; }
        public String Nombre { get; set; }
        public Double PrimaBase { get; set; }
        public String PolizaActual { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;//inicaliza
        public Planes()
        {
            Entidades = new Biblioteca.DALC.BeLifeEntities();
        }

        public List<Planes> ListarPlan()
        {
            try
            {
                //coleccion del tipo clase 
                List<Planes> ListadoPlan = new List<Planes>();

                var PlanModelo = Entidades.Plan.ToList();

                foreach (DALC.Plan item in PlanModelo)
                {
                    Planes plan = new Planes();


                    plan.Id= item.IdPlan;
                    plan.Nombre = item.Nombre;
                    plan.PrimaBase = item.PrimaBase;
                    plan.PolizaActual = item.PolizaActual;
                   
                    //listado clientes
                    ListadoPlan.Add(plan);
                }
                return ListadoPlan;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }


        }
        public bool BuscarPlan(string codigo)
        {
            try
            {

                DALC.Plan PlanModelo = Entidades.Plan.First(p => p.IdPlan.Equals(codigo));

                this.Nombre = PlanModelo.Nombre;
                this.PrimaBase = PlanModelo.PrimaBase;
                this.PolizaActual = PlanModelo.PolizaActual;               
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
