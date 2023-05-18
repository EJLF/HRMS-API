using HRMS_Stored_Procedure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        HRMSDbContext _context;

        public DepartmentController(HRMSDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string newDepartmentName)
        {
            try
            {
                var parameters = new[] {
                new SqlParameter("@DeptName", newDepartmentName)
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddDepartment @DeptName", parameters);
                if (result > 0)
                    return Ok("Department Save Successful!");
                return BadRequest("Can't Create Department");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _context.Departments.FromSqlRaw("EXEC getalldepartment").ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var department = _context.Departments.FromSqlRaw("EXEC GetDepartmentById {0}", id).AsEnumerable().FirstOrDefault();

                if (department == null)
                    return NotFound();
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string newDeptName)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdateDepartmentById {0}, {1}", id, newDeptName);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteDepartmentById {0}", id);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }  
        }
    }
}
