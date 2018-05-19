using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Data.Objects.DataClasses;*/
using System.Collections;
using System.Threading.Tasks;
using Biblioteca.DALC;//OCUPO LA BIBLIOTECA DE ACCESO A LA bd
using Biblioteca.Entidades;
namespace Biblioteca.Entidades
{
   public class Sexos
    {//
        public int IdSexo { get; set; }
        public String Descripcion { get; set; }
        Biblioteca.DALC.BeLifeEntities Entidades;//inicaliza
        public Sexos()
        {
            Entidades = new Biblioteca.DALC.BeLifeEntities();//crea la conexion
        }
        //metodos
                
        public List<Sexos> ListarSexo()
        {
            try
            {
                //coleccion del tipo clase 
                List<Sexos> ListadoSexo = new List<Sexos>();

                var SexoModelo = Entidades.Sexo.ToList();

                foreach (DALC.Sexo item in SexoModelo)
                {
                    Sexos Sex = new Sexos();


                    Sex.IdSexo = item.IdSexo;
                    Sex.Descripcion = item.Descripcion;

                    //listado clientes
                    ListadoSexo.Add(Sex);
                }
                return ListadoSexo;
            }
            catch (Exception ex)
            {
                Logger.Mensaje(ex.Message);
                return null;
            }


        }

        public bool BuscarSexo(string codigo)
        {
            try
            {
              //  var SexoModelo = Entidades.Sexo();

                DALC.Sexo SexoModelo = Entidades.Sexo.First(se => se.IdSexo.Equals(codigo));

                this.Descripcion = SexoModelo.Descripcion;
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
