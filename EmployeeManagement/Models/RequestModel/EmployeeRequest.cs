using EmployeeManagement.DTOs;

namespace EmployeeManagement.Models.RequestModel
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Department { get; set; } = "";
    }
}
