using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using EmployeeManagement.Models;
using EmployeeManagement.DTOs;
using EmployeeManagement.Mapper;
using EmployeeManagement.DatabaseConn;
using EmployeeManagement.Services.Interface;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly DatabaseConnection _dbConn;

        public EmployeeService(IConfiguration configuration, ILogger<EmployeeService> logger, DatabaseConnection DbConn)
        {
            _logger = logger;
            _dbConn = DbConn;
        }


        public async Task<IEnumerable<EmployeeDto>> GetAsync(int? id = null)
        {
            try
            {
                using var dbConn = _dbConn.CreateConnection();

                string query = id.HasValue
                    ? "SELECT * FROM Employees WHERE Id = @Id"
                    : "SELECT * FROM Employees";

                var allEmployees = await dbConn.QueryAsync<Employee>(query, new {Id = id});

                var employeeDtos = allEmployees.Select(EmployeeMapper.ToDto);

                return employeeDtos;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all employees.");
                return Enumerable.Empty<EmployeeDto>();
            }
        }

        public async Task<Employee> AddEmpAsync(EmployeeRequest EmpDto)
        {
            try
            {
                using var dbConn = _dbConn.CreateConnection();
                var sql = "INSERT INTO Employees (Name, Age, Department) VALUES (@Name, @Age, @Department)";
                var emp = EmployeeMapper.ToAddEmp(EmpDto);
                await dbConn.ExecuteAsync(sql, emp);
                return(emp);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new employee.");
                throw;
            }
        }

        public async Task<Employee> UpdateEmpAsync(EmployeeDto EmpDto)
        {
            try
            {
                using var dbConn = _dbConn.CreateConnection();
                var sql = "UPDATE Employees SET Name = @Name, Age = @Age, Department = @Department  WHERE Id = @Id";
                var response = EmployeeMapper.ToModel(EmpDto); 
                 await dbConn.ExecuteAsync(sql, response);
                return (response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating employee.");
                throw;
            }
        }
        public async Task DeleteAsync(int id)
        {
            using var dbConn = _dbConn.CreateConnection();
            await dbConn.ExecuteAsync("DELETE FROM Employees WHERE Id = @Id", new { Id = id });
        }
    }
}
