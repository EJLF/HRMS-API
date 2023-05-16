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
            var parameters = new[] {
                new SqlParameter("@posName", PositionName)
                };
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddPosition @posName", parameters);
            if (result > 0)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _context.Positions.FromSqlRaw("EXEC getallpositions").ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var position = _context.Positions.FromSqlRaw("EXEC GetPositionById {0}", id).AsEnumerable().FirstOrDefault();

            if (position == null)
                return NotFound();
            return Ok(position);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string PositionName)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdatePositionById {0}, {1}", id, PositionName);
            if (result > 0)
                return Ok();
            return NotFound();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeletePositionById {0}", id);
            if (result > 0)
                return Ok();
            return NotFound();
        }
    }
}
