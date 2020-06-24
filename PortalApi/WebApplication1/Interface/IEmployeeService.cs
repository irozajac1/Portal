using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IEmployeeService
    {
        List<Employee> getAllEmployees();
        Employee GetEmployeeById(Guid id);
        void PostEmployee(EmployeeRequest employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Guid id, Employee employee);
    }
}
