using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*https://www.codeproject.com/Articles/1070207/Dependency-Injection-How-exactly-Inversion-of-Cont
 * Here we are passing(inject) object from outside. No class or module can't take those responsibilities. 
 * When we call EmployeeSolution class from main method we will inject(DatabaseStorageAgent) object.
 * Consern:- If we inject from main method in future if we need to change DBstorageAgent to something else
 * we need to modify. Even that also we need to bulid the class and coupled here.
 * Here we need to introduce one concept like IOC[unity,autofac,ninject,windoser.. etc..]. It does dependies creation, detroying and passing.
 * It is third party , if any thing change occure we can bulid this class. This does not effect the modules..
 * */
namespace DependencyInversion.Lab
{
    public class EmployeeSolution
    {
        private string empName;
        private int salary;
        IStorageAgent persistanceStorageDependency;

        public EmployeeSolution(IStorageAgent persistanceStorageAgent)
        {
            //Assigning the injected dependency to local reference.
            persistanceStorageDependency = persistanceStorageAgent;
        }

        public string EmployeeName
        {
            get { return empName; }
            set { empName = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public void SaveEmployeeDetails()
        {
            
                //create query text
                string queryText = string.Format
                ("insert into Employee (Name,Salary) values ('{0}',{1})", empName, salary);

                //create persistence storage connection
                var connection = persistanceStorageDependency.GetPersistantStorageConnection();

                //save employee details into the persistence storage
                persistanceStorageDependency.SaveDataToStorage(connection, queryText);
           
        }
        
    }
    /*
     *Here Interface defination should be defined by higer lever not lower class level. If we define like that we need to change or create new one. 
     * 
     */
    public interface IStorageAgent
    {
        IDbConnection GetPersistantStorageConnection();
        void SaveDataToStorage(IDbConnection Connection, string queryText);

    }
    public class DatabaseStorageAgentSolution : IStorageAgent
    {
        public IDbConnection GetPersistantStorageConnection()
        {
            return new SqlConnection("Data Source=(local);Initial Catalog = EmployeeDB; Integrated Security = SSPI; ");
        }

        public void SaveDataToStorage(IDbConnection dbConnection, string queryText)
        {
            Console.WriteLine("Values stored sucessfully");
        }
    }
}
