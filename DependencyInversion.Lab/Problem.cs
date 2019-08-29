using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Problem:-
 * here if we observe (Employee class is high level and DatabaseStorageAgent is low level) employee class is creating object of lower class.
 * Present we are storing data in sql if any new chage occure like save data in msaccess we have chage emloyee class and lower class.
 *  
 */

namespace DependencyInversion.Lab
{

   
    public class Employee
    {

        private string empName;
        private int salary;

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
            //Instantiate low-level Dependency
            DatabaseStorageAgent persistanceStorageAgent = new DatabaseStorageAgent();

           
                //create query text
                string queryText = string.Format("insert into Employee (Name,Salary) values ('{0}',{1}", empName, salary);

                //create sql connection
                var sqlCon = persistanceStorageAgent.GetSqlConnection();

                //save employee details into the SQL Server database
                persistanceStorageAgent.ExecuteNonQuery(sqlCon, queryText);
     
        }
    }
    public class DatabaseStorageAgent
    {
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection("Data Source=rasik-PC;Initial Catalog=EmployeeDB;Integrated Security=SSPI;");
        }

        public void ExecuteNonQuery(SqlConnection sqlCon, string queryText)
        {
            var sqlCmd = new SqlCommand(queryText, sqlCon);
            sqlCmd.ExecuteNonQuery();
        }
    }

}
