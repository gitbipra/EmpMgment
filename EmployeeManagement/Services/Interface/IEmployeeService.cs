using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.Services.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAsync(int? id = null);
        Task<Employee> AddEmpAsync(EmployeeRequest EmpDto);
        Task<Employee> UpdateEmpAsync(EmployeeDto EmpDto);
        Task DeleteAsync(int id);

    }
}
