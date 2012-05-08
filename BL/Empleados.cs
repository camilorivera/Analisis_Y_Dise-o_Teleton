using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; 
using System.Data;
using System.Data.Objects;


namespace BL
{
   public class Empleados
    {
        #region Variables
        DataAccess.teletonEntities entities;
        #endregion

        #region Constructor
           public Empleados() {
             entities = new teletonEntities();
        }
        #endregion

           #region Listas
           
           public List<String> RetrievePositionName() 
        {
               try{
            var query = from p in entities.cargos select p;
                List<string> Cargos = new List<string>();
                    foreach (cargo name in query)
                          Cargos.Add(name.cargo1);
                     return Cargos;
                   }catch(Exception err){
                       throw new Exception(err.ToString() + "--Empleados.cs / RetrievePositionName()");
               }
        }


           public List<String> RetrieveEmployeesName() 
           {
               try
               {
                   var query = from e in entities.empleados select e;
                   List<string> nomemp = new List<string>();
                   foreach (empleado emp in query)
                       nomemp.Add(emp.nombres);

                   return nomemp;
               }
               catch (Exception err)
               {
                   throw new Exception(err.ToString() + "--Empleados.cs / RetrieveEmployeesName()");
               }
           }
           #endregion

           #region Gets  
           public int GetPositionId(string nombrecargo) {
               try
               {
                   var query = from pos in entities.cargos
                               where nombrecargo == pos.cargo1
                               select pos.id;
                   int posId = Convert.ToInt32(query.First());

                   return posId;
               }catch(Exception err){
                   throw new Exception(err.ToString() + "--Empleados.cs / GetPositionId(string)");
               }
           }


           public int GetEmpId(string nombre) {
               try
               {
                   var idemp_query = from p in entities.empleados
                                     where p.nombres == nombre
                                     select p.id;
                   int emp_id = Convert.ToInt32(idemp_query.First());

                   return emp_id;

               }catch(Exception err){
                   throw new Exception(err.ToString() + "--Empleados.cs / GetEmpId(string)");
               }
           
           }

           #endregion

        #region Funciones
           public void GuardarEmpleado(int id, string nombre, string primernombre, string segundonombre, string nombrecargo)
           {
               try
               {

                   int posId = GetPositionId(nombrecargo);


                   DataAccess.empleado emp = new DataAccess.empleado();
                   emp.id = id;
                   emp.nombres = nombre;
                   emp.primer_apellido = primernombre;
                   emp.segundo_apellido = segundonombre;
                   emp.puesto = posId;

                   entities.empleados.AddObject(emp);//Se guarda en la memoria
                   
                   entities.SaveChanges();//Se guarda en la base de datos
               }
              catch(Exception err){

                       throw new Exception(err.ToString() + "--Empleados.cs / GuardarEmpleados()");
               }

           }

           public void EditarEmpleado(string usuario,string nombre, string primerapellido, string segundoapellido, string nombrecargo)
           {
               try
               {
               
                   int emp_id = GetEmpId(usuario); //Con el nombre se selecciona el id del empleado
                   int idcargo = GetPositionId(nombrecargo);//Se saca el id del cargo

                   var query = (from e in entities.empleados
                                where e.id==emp_id
                                select e).First();

                   DataAccess.empleado TEMPEMP = query;
                   //TEMPEMP.id = emp_id;
                   TEMPEMP.nombres = nombre;
                   TEMPEMP.primer_apellido = primerapellido;
                   TEMPEMP.segundo_apellido = segundoapellido;
                   TEMPEMP.puesto = idcargo;

                   entities.SaveChanges();

               }
               catch (Exception er)
               {

                   throw new Exception(er.ToString() + "--Empleados.cs / EditarEmpleados()");
               }
           }

           public void EliminarEmpleado(string nombre)
           {
               try
               {
                   int id = GetEmpId(nombre);

                   var query = (from e in entities.empleados
                                where e.id == id
                                select e).First();

                   DataAccess.empleado EMPDELETE = query;
                   entities.DeleteObject(EMPDELETE);
                   entities.SaveChanges();
               }
               catch (Exception er)
               {
                   throw new Exception(er.ToString() + "--Empleados.cs / EliminarEmpleados()");

               }

           }


           public string getNombre(int p_IdEmpleado)
           {
               try
               {
                   var t_query = from c in entities.empleados
                                 where c.id == p_IdEmpleado
                                 select new { c.nombres, c.primer_apellido, c.segundo_apellido };
                   return (t_query.FirstOrDefault().nombres + " " + t_query.FirstOrDefault().primer_apellido
                       + " " + t_query.FirstOrDefault().segundo_apellido);
               }
               catch
               {
                   return null;
               }
           }
           public string obtenerNombresDoctores(long empId)
           {
               string nombresDoctores;
               //El codigo de doctor en la tabla de cargos
               try
               {
                   var query = from emp in entities.empleados
                               where emp.id  == empId 
                               select emp.nombres;

                   nombresDoctores = query.First();
                   return nombresDoctores;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.ToString() + "--Empleados.cs /obtenerNombresDoctores");
               }
           }

           public string obtenerApellidoDoctores(long empId)
           {
               try
               {
                   string apellidoDoc = String.Empty;
                   var query = from emp in entities.empleados
                               where emp.id == empId
                               select emp.primer_apellido;

                   apellidoDoc = query.First();
                   return apellidoDoc;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.ToString() + "--Empleados.cs / obtenerApellidoDoctores()");
               }
           }

           public string obtenerSegundoApellidoDoctores(long empId)
           {
               try
               {
                   string segundoApellido = String.Empty;
                   var query = from emp in entities.empleados
                               where emp.id == empId
                               select emp.segundo_apellido;

                   segundoApellido = query.First();
                   return segundoApellido;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.ToString() + "--Empleados.cs / obtenerApellidoDoctores()");
               }
           }

           public List<String> obtenerNombresTerapeutas()
           {
               List<String> nombresTerapeutas;
               //El codigo de doctor en la tabla de cargos
               long longCodigoTerapeutas = 17;
               try
               {
                   nombresTerapeutas = (from emp in entities.empleados
                                      where emp.puesto == longCodigoTerapeutas
                                      select (emp.nombres)).ToList<String>();
                   return nombresTerapeutas;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.ToString() + "--Empleados.cs /obtenerNombresTerapeutas");
               }
           }

           public string obtenerNombre(int idEmp)
           {
               try
               {
                   List<string> nombres;
                   nombres = (from emp in entities.empleados
                             where emp.id == idEmp
                             select (emp.nombres)).ToList<string>();

                   List<string> apellido;
                   apellido = (from emp in entities.empleados
                               where emp.id == idEmp
                               select (emp.primer_apellido)).ToList<string>();

                   string nombreYapellido = nombres[0] + " " + apellido[0];
                   return nombreYapellido;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.ToString() + "--Empleados.cs / obtenerNombre()");
               }
               
           }
         #endregion


    }
}
