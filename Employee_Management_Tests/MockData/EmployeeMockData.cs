using Employee_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Tests.MockData
{
    public class EmployeeMockData
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    EmployeeId=1,
                    Name = "Ganesh",
                    Adress = "Andhra",
                    DepartmentId = 1

                },
                 new Employee
                {
                    EmployeeId=2,
                    Name = "sachin",
                    Adress = "mumbai",
                    DepartmentId = 1

                },
                  new Employee
                {
                    EmployeeId=1,
                    Name = "virat",
                    Adress = "Delhi",
                    DepartmentId = 2

                },
            };
        }
        /*public static List<Employee> GetEmptyEmployeees()
        {
            return new List<Employee>();
        }*/

    }
}
