using EmployeeManagement.Models;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.Mapper
{
    public class EmployeeMapper
    {
        public static EmployeeDto ToDto(Employee employee)
        {
            var EmpDto = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Department = employee.Department,
            };
            return(EmpDto);
        }

        public static Employee ToModel(EmployeeDto employeeDto)
        {
            var EmpModel = new Employee
            { 
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Department = employeeDto.Department,
            };
            return(EmpModel);
        }

        public static Employee ToAddEmp(EmployeeRequest empReq)
        {
            var NewEmp = new Employee
            {
                Name = empReq.Name,
                Age = empReq.Age,
                Department = empReq.Department
            };
            return(NewEmp);
        }
    }


}
