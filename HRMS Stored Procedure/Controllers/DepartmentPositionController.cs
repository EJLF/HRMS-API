using HRMS_Stored_Procedure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentPositionController : ControllerBase
    {
        HRMSDbContext _context;

        public DepartmentPositionController(HRMSDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string DepartmentId, string PositionId)
        {
            try
            {
                var parameters = new[] {
                new SqlParameter("@posId", PositionId),
                new SqlParameter("@deptId", DepartmentId)
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddDepartmentPosition @deptId, @posId", parameters);
                if (result > 0)
                    return Ok("Designation Save Successful!");
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Check Department Id and Position Id if Existed");
            }      
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var departmentPositions = _context.DepartmentPositions.FromSqlRaw("EXEC GetDepartmentPositionById {0}", id).AsEnumerable().FirstOrDefault();
                if (departmentPositions == null)
                    return BadRequest("No Department and Position Found");

                var department = _context.Departments.FromSqlRaw("EXEC GetDepartmentById {0}", departmentPositions.DepartmentId).AsEnumerable().FirstOrDefault();
                var position = _context.Positions.FromSqlRaw("EXEC GetPositionById {0}", departmentPositions.PositionId).AsEnumerable().FirstOrDefault();

                var result = departmentPositions != null
                     ? new
                     {
                         departmentPositions.No,
                         DepartmentId = departmentPositions.DepartmentId,
                         DepartmentName = department.DeptName,
                         PositionId = departmentPositions.PositionId,
                         PositionName = position.PositionName
                     }
                     : null;
         
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var departmentPositions = await _context.DepartmentPositions.FromSqlRaw("EXEC GetAllDepartmentPosition").ToListAsync();

                var departmentIds = departmentPositions.Select(dp => dp.DepartmentId).Distinct();
                var departments = await _context.Departments.Where(d => departmentIds.Contains(d.DeptId)).ToListAsync();

                var positionIds = departmentPositions.Select(dp => dp.PositionId).Distinct();
                var positions = await _context.Positions.Where(p => positionIds.Contains(p.PosId)).ToListAsync();

                var result = departmentPositions
                    .Join(departments, dp => dp.DepartmentId, d => d.DeptId, (dp, d) => new
                    {
                        dp.No,
                        DepartmentId = dp.DepartmentId,
                        DepartmentName = d.DeptName,
                        PositionId = dp.PositionId
                    })
                    .Join(positions, dp => dp.PositionId, p => p.PosId, (dp, p) => new
                    {
                        dp.No,
                        dp.DepartmentId,
                        dp.DepartmentName,
                        PositionId = dp.PositionId,
                        PositionName = p.PositionName
                    })
                    .ToList();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, int NewDeptId, int NewPosId)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdateDepartmentPosition {0}, {1}, {2}", id, NewDeptId, NewPosId);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            } 
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteDepartmentPosition {0}", id);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }  
        }
    }
}
