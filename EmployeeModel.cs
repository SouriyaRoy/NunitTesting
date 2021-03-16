using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDependency
{
 
    public class EmploeeModel
    {
       

        
        public EmploeeModel()
        {
            
        }
      
        //public Boolean CheckName()
        //{
        //    List<string> lst = _emp.Names;
        //    //lst.Add("C#");
        //    //_emp.Names = lst;

        //    if(lst != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    //List<string> lst = new List<string>();
        //    //lst.Add("C#");
        //    //_emp.Names = lst;//External dependency
        //    //if (_emp != null)
        //    //    return true;
        //    //else
        //    //    return false;
        //}
     
        public Boolean DoesEmployeeExists(int id)
        {
            EmployeeRepo repo = new EmployeeRepo();
            List<Employee> emps = repo.SearchEmployees();
            Employee emp = (Employee)emps.Find(x => x.EmpNo == id);
            if (emp == null)
                throw new EmployeeNotFoundException();
            else
            {
                repo.SendEmail();
                repo.SendSMS();
            }
            return true;
        }



      
    }
}
