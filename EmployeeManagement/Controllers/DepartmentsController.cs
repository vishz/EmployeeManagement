using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public DepartmentsController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/departments
    [HttpGet]
    public ActionResult<IEnumerable<Department>> GetDepartments()
    {
      return _context.Departments.ToList();
    }
  }
}
