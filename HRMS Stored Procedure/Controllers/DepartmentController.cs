using HRMS_Stored_Procedure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        HRMSDbContext _context;

        public DepartmentController(HRMSDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var alldept = await _context.Departments.FromSqlRaw("EXEC getalldepartment").ToListAsync();
            return Ok(alldept);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _context.Departments.FromSqlRaw("EXEC GetDepartmentById {0}", id).AsEnumerable().FirstOrDefault();

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string newDeptName)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdateDepartmentById {0}, {1}", id ,newDeptName);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteDepartmentById {0}", id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
