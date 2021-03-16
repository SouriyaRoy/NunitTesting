using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDependency
{
    public class EmployeeRepo
    {
        private List<string> _names;
        public List<string> Names
        {
            get
            {
                return _names;
            }

            set
            {
                _names.Add("C#");
                _names.Add("Java");
            }
        }

        public void SendEmail()
        {

        }

       

        public List<Employee> SearchEmployees()
        {
            try
            {
                List<Employee> Employees = new List<Employee>();
                SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BootCamp;Integrated Security=True");
                SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from EmployeeInfo", Conn);
                DataSet Ds = new DataSet();
                AdEmp.Fill(Ds, "EmployeeInfo");

                foreach (DataRow Dr in Ds.Tables["EmployeeInfo"].Rows)
                {
                    Employees.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(Dr["Emp_No"]),
                        EmpName = Dr["Emp_Name"].ToString(),
                        Salary = Convert.ToInt32(Dr["Salary"]),
                        DeptName = Dr["Dept"].ToString(),
                        Designation = Dr["Designation"].ToString(),
                    });
                }


                return Employees;

                // emps = Employees;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

       /* public int InsertEmployee(Employee emp)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BootCamp;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeInfo(Emp_Name,Salary,Dept,Designation) VALUES(" + "'" + emp.EmpName + "'," + emp.Salary + ",'" + emp.DeptName + "','" + emp.Designation + "'); SELECT SCOPE_IDENTITY()", conn);
                conn.Open();
                int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                return insertedID;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }*/
        public int InsertEmployee(Employee emp)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Training;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee(Emp_Name,Salary,Dept,Designation) VALUES(" + "'" + emp.EmpName + "'," + emp.Salary + ",'" + emp.DeptName + "','" + emp.Designation + "'); SELECT SCOPE_IDENTITY()", conn);
                conn.Open();
                int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                return insertedID;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public void SendSMS()
        {
            throw new NotImplementedException();
        }
    }
}
