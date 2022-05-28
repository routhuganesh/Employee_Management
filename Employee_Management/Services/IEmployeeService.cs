using Employee_Management.Models;

namespace Employee_Management.Services
{
    public interface IEmployeeService<Employee>
    {
        Employee Get(int id);
        void Create(CreateEmployeeDto request);
        int GetCount(int id);
    }
}
