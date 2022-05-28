using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Services
{
    public class EmployeeService : IEmployeeService<Employee>
    {
        private readonly EmDbContext context;

        public EmployeeService(EmDbContext context)
        {
            this.context = context;
        }
        public Employee Get(int id)
        {
            var employees =
                context.Employees.
                Where(c => c.EmployeeId == id).
                Include(c => c.Department).
                FirstOrDefault();
            return employees;
        }

            public int GetCount(int id)
            {
                var countlist = context.Employees.
                    Where(c => c.DepartmentId == id).ToList();
                int c = countlist.Count();
                return c;
            }
        public void Create(CreateEmployeeDto request)
        {
            var department = context.Departments.Find(request.DepartmentId);
            var newEmployee = new Employee
            {
                Name = request.Name,
                Adress = request.Adress,
                Department = department
            };
            context.Employees.Add(newEmployee);
            context.SaveChanges();
        }
       
    }
    }

