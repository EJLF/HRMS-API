using HRMS_Stored_Procedure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        HRMSDbContext _context;

        public PositionController(HRMSDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string PositionName)
        {
            try
            {
                var parameters = new[] {
                new SqlParameter("@posName", PositionName)
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddPosition @posName", parameters);
                if (result > 0)
                    return Ok("Position Save Successful!");
                return BadRequest();
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
                var result = await _context.Positions.FromSqlRaw("EXEC getallpositions").ToListAsync();
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
                var position = _context.Positions.FromSqlRaw("EXEC GetPositionById {0}", id).AsEnumerable().FirstOrDefault();

                if (position == null)
                    return NotFound();
                return Ok(position);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!");
            }   
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string PositionName)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdatePositionById {0}, {1}", id, PositionName);
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
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeletePositionById {0}", id);
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
