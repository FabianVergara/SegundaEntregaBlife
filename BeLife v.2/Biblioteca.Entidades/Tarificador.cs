using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
using Biblioteca.Entidades;
namespace Biblioteca.Entidades
{
    public class Tarificador
    {
        //metodo tiene validaciones
        //metodo lleva parametros debe recibir la primaBase
        //validar x edad
        //validar por sexo
        //validar por Estado Civil

        //Este valor se devolvera al contrato
        Biblioteca.DALC.BeLifeEntities Entidades;
        public Tarificador()
        {
            Entidades = new BeLifeEntities();
        }

        public double calculoPrimasanual(string codigo,string rut)
        {
            try
            {

                double Calculo = 0;
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.Entidades.Contratos Cont;
                Cont = new Entidades.Contratos();
                double primab;
                    Biblioteca.Entidades.Clientes cli;
                    cli = new Clientes();
                    cli.Buscar();
                    Plan.BuscarPlan(codigo);
                //le paso el valor de la prima base
                //1 UF = $ 26.633,18 Pesos Chilenos
                Double uf = 26633.18;
                primab = Plan.PrimaBase*uf;

                    int edad = (DateTime.Now.Year - cli.FechaNacimiento.Year);
                    Double recargoEdad = 0;
                    Double recargoSexo = 0;
                    Double recargoEstCiv = 0;
                    ////////////////////////////////////////////////////////////////////////////////////////
                    
                    //recargo por edad
                    if (edad >= 18 && edad <= 25)
                    {
                        recargoEdad = 0.036 * uf;
                    }
                    else
                    {
                        if (edad >= 26 && edad <= 45)
                        {
                            recargoEdad = 0.024 * uf;
                        }
                        else
                        {
                            if (edad > 45)
                            {
                                recargoEdad = 0.06 * uf;
                            }
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////
                    //recargo x sexo
                    if (cli.IdSexo == 1)//hombre
                    {
                        recargoSexo = 0.024 * uf;
                    }
                    else
                    {
                        if (cli.IdSexo == 2)//mujer
                        {
                            recargoSexo = 0.012 * uf;
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////
                    //recargo por estado civil                
                    switch (cli.IdEstadoCivil)
                    {
                        case 1://soltero
                            recargoEstCiv = 0.048 * uf;

                            break;
                        case 2://casado

                            recargoEstCiv = 0.024 * uf;
                            break;
                        //case 3://divorciado
                        //  break;
                        //case 4://viudo
                        //break;
                        default://otro
                            recargoEstCiv = 0.036 * uf;
                            break;


                    }



                    ////////////////////////////////////////////////////////////////////////////////////////  

                    Calculo = primab +recargoEdad+recargoEstCiv+recargoSexo;


              
                    //retorna la PrimaAnual
                    


                
                return Calculo;
            } 
            catch (Exception)
            {

                return 0;
            }
            
        }
        public double calculoPrimasmensual(String codigo,String rut)
        {
            try
            {

                double Calculo = 0;
                Biblioteca.Entidades.Planes Plan;
                Plan = new Entidades.Planes();
                Biblioteca.Entidades.Contratos Cont;
                Cont = new Entidades.Contratos();
                double primab;
               
                  Biblioteca.Entidades.Clientes cli;
                    cli = new Clientes();
                    cli.Buscar();
                    Plan.BuscarPlan(codigo);
                //le paso el valor de la prima base
                //le paso el valor de la prima base
                //1 UF = $ 26.633,18 Pesos Chilenos
                Double uf = 26633.18;
                primab = Plan.PrimaBase * uf;

                int edad = (DateTime.Now.Year - cli.FechaNacimiento.Year);
                    Double recargoEdad = 0;
                    Double recargoSexo = 0;
                    Double recargoEstCiv = 0;
                    ////////////////////////////////////////////////////////////////////////////////////////
                    
                    //recargo por edad
                    if (edad >= 18 && edad <= 25)
                    {
                        recargoEdad = 0.036 * uf;
                    }
                    else
                    {
                        if (edad >= 26 && edad <= 45)
                        {
                            recargoEdad = 0.024 * uf;
                        }
                        else
                        {
                            if (edad > 45)
                            {
                                recargoEdad = 0.06 * uf;
                            }
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////
                    //recargo x sexo
                    if (cli.IdSexo == 1)//hombre
                    {
                        recargoSexo = 0.024 * uf;
                    }
                    else
                    {
                        if (cli.IdSexo == 2)//mujer
                        {
                            recargoSexo = 0.012 * uf;
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////
                    //recargo por estado civil                
                    switch (cli.IdEstadoCivil)
                    {
                        case 1://soltero
                            recargoEstCiv = 0.048 * uf;

                            break;
                        case 2://casado

                            recargoEstCiv = 0.024 * uf;
                            break;
                        //case 3://divorciado
                        //  break;
                        //case 4://viudo
                        //break;
                        default://otro
                            recargoEstCiv = 0.036 * uf;
                            break;


                    }



                    ////////////////////////////////////////////////////////////////////////////////////////  

                    Calculo = (primab + recargoEdad + recargoEstCiv + recargoSexo)/12;



                    //retorna la PrimaAnual



                
                return Calculo;
            }
            catch (Exception)
            {

                return 0;
            }

        }
    }
}
