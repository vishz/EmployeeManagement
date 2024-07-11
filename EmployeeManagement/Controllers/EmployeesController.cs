using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Dto;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.Include(e => e.Department)
                                               .Select(e => new 
                                               {
                                                   e.Id,
                                                   e.No,
                                                   e.Name,
                                                   e.Age,
                                                   DepartmentName = e.Department.DepName,
                                                   e.Salary,
                                               }).ToList();

            return Ok(employees);
        }

    // POST: api/employees
      [HttpPost]
      public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
      {
        if (employeeDto == null)
        {
          return BadRequest();
        }
        var employee = new Employee();
        employee.Id = employeeDto.Id;
        employee.Name = employeeDto.Name;
        employee.Age = employeeDto.Age;
        employee.DepartmentId = employeeDto.DepartmentId;
        employee.Salary = employeeDto.Salary;

      //Ensure the Department exists
      var department = _context.Departments.Find(employeeDto.DepartmentId);
        if (department == null)
        {
          return BadRequest("Invalid DepartmentId");
        }

      employee.Department = department;
        var newEmployee = new Employee
        {
          No = employeeDto.No,
          Name = employeeDto.Name,
          Age = employeeDto.Age,
          DepartmentId = employeeDto.DepartmentId,
          Salary = employeeDto.Salary,
          Department = department // Set the navigation property if needed
        };
        _context.Employees.Add(newEmployee);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetEmployees), new { id = employeeDto.Id }, employeeDto);
      }
  }
}

