using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalDependency
{
    public interface IPerson
    {
        List<Person> GetAll();
    }
    public class PersonModel
    {

        IPerson _person;

        public PersonModel(IPerson person)
        {
            _person = person;
        }

        public List<Person> Query(Func<Person, bool> predicate)
        {
           // PersonRepo model = new PersonRepo();
            var result = _person.GetAll();//External Dependency
            return result.Where(predicate).ToList();
        }
    }


    public class PersonRepo :IPerson
    {
        public List<Person> GetAll()
        {
            List<Person> Persons;
            SqlConnection Conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BootCamp;Integrated Security=True");
            SqlDataAdapter AdEmp = new SqlDataAdapter("Select * from Person", Conn);
            Conn.Open();
            DataSet Ds = new DataSet();
            AdEmp.Fill(Ds, "Person");
            Persons = new List<Person>();

            foreach (DataRow Dr in Ds.Tables["Person"].Rows)
            {
               
                Persons.Add(new Person()
                {
                    FirstName = Dr["FirstName"].ToString(),
                    LastName = Dr["FirstName"].ToString()
                
                });
            }

            return Persons;
        }
    }
}
