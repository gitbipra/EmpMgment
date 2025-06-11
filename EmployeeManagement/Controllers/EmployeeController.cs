using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Services;
using EmployeeManagement.DTOs;
using EmployeeManagement.Services.Interface;
using EmployeeManagement.Models.RequestModel;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var AllEmp = await _service.GetAsync();
                return Ok(AllEmp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                var employee = result.FirstOrDefault();

                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route ("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeRequest EmpDto)
        {
            try
            {
                if (EmpDto == null)
                {
                    return BadRequest("Employee data is required.");
                }

                var response = await _service.AddEmpAsync(EmpDto);

                return Ok(response);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route ("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto EmpDto)
        {
            try
            {
                if (EmpDto == null)
                {
                    return BadRequest("Employee data is required.");
                }

                var response = await _service.UpdateEmpAsync(EmpDto);

                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest();

                throw;
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }
}
