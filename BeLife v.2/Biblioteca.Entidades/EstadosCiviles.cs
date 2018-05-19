using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Entidades
{
    public class EstadosCiviles
    {
        public int Id { get; set; }
        public String Descripcion { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;
        public EstadosCiviles()
        {
            Entidades = new BeLifeEntities();
        }
        public List<EstadosCiviles> ListarEstadoCivil()
        {
            try
            {
                //coleccion del tipo clase 
                List<EstadosCiviles> ListadoEstCiv = new List<EstadosCiviles>();

                var EstCivModelo = Entidades.EstadoCivil.ToList();

                foreach (DALC.EstadoCivil item in EstCivModelo)
                {
                    EstadosCiviles EstCiv = new EstadosCiviles();


                    EstCiv.Id = item.IdEstadoCivil;
                    EstCiv.Descripcion = item.Descripcion;

                    //listado clientes
                    ListadoEstCiv.Add(EstCiv);
                }
                return ListadoEstCiv;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }


        }

        public bool BuscarEstadosCiviles(string codigo)
        {
            try
            {
               // var EstCivModelo = Entidades.EstadoCivil();

                DALC.EstadoCivil EstCivModelo = Entidades.EstadoCivil.First(ev => ev.IdEstadoCivil.Equals(codigo));

                this.Descripcion = EstCivModelo.Descripcion;
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

       
    

