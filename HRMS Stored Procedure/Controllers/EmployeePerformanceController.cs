using HRMS_Stored_Procedure.Data;
using HRMS_Stored_Procedure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePerformanceController : ControllerBase
    {
        HRMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeePerformanceController(HRMSDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string UserID, string ReviewBy, string About, string PerformanceReview, string DateReview, bool Status, bool DeleteStatus)
        {
            try
            {
                var parameters = new[] 
                {
                    new SqlParameter("@UserID", UserID),
                    new SqlParameter("@ReviewBy", ReviewBy),
                    new SqlParameter("@About", About),
                    new SqlParameter("@PerformanceReview", PerformanceReview),
                    new SqlParameter("@DateReview", DateReview),
                    new SqlParameter("@Status", Status),
                    new SqlParameter("@DeleteStatus", DeleteStatus)
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddEmployeePerformance @UserID, @ReviewBy, @About, @PerformanceReview, @DateReview, @Status, @DeleteStatus", parameters);
                if (result > 0)
                    return Ok("Employee Performance Save Successful!");
                return BadRequest("Can't Create Employee Performance");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }
        [HttpGet("{No}")]
        public async Task<IActionResult> GetByIdAsync(int No)
        {
            try
            {
                var employeePerformance = _context.EmployeePerformances.FromSqlRaw("EXEC GetEmployeePerformanceById {0}", No).AsEnumerable().FirstOrDefault();
                if (employeePerformance == null)
                    return BadRequest("No Employee Performance Found");

                var employees = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == employeePerformance.UserID);
                var reviewer = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == employeePerformance.ReviewBy);

                var result = employeePerformance != null
                     ? new
                     {
                         employeePerformance.No,
                         UserID = employeePerformance.UserID,
                         EmployeeName = employees.FullName,
                         About = employeePerformance.About,
                         PerformanceReview = employeePerformance.PerformanceReview,
                         ReviewBy = employeePerformance.ReviewBy,
                         ReviewerName = reviewer.FullName,
                         DateReview = employeePerformance.DateReview,
                         Status = employeePerformance.Status,
                         DeleteStatus = employeePerformance.DeleteStatus
                     }
                     : null;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var employeePerformances = await _context.EmployeePerformances.FromSqlRaw("EXEC GetAllEmployeePerformance").ToListAsync();

                var employeeIds = employeePerformances.Select(ep => ep.UserID).Distinct();
                var employees = await _userManager.Users.Where(e => employeeIds.Contains(e.Id)).ToListAsync();

                var reviewerIds = employeePerformances.Select(ep => ep.ReviewBy).Distinct();
                var reviewers = await _userManager.Users.Where(e => reviewerIds.Contains(e.Id)).ToListAsync();

                var result = employeePerformances
                    .Join(employees, ep => ep.UserID, e => e.Id, (ep, e) => new
                    {
                        ep.No,
                        UserID = ep.UserID,
                        EmployeeName = e.FullName,
                        About = ep.About,
                        PerformanceReview = ep.PerformanceReview,
                        ReviewBy = ep.ReviewBy,
                        DateReview = ep.DateReview,
                        Status = ep.Status, 
                        DeleteStatus = ep.DeleteStatus
                
                    })
                    .Join(reviewers, ep => ep.ReviewBy, r => r.Id, (ep, r) => new
                    {
                        ep.No,
                        UserID = ep.UserID,
                        EmployeeName = ep.EmployeeName,
                        About = ep.About,
                        PerformanceReview = ep.PerformanceReview,
                        ReviewBy = r.FullName,
                        DateReview = ep.DateReview,
                        Status = ep.Status,
                        DeleteStatus = ep.DeleteStatus
                    })
                    .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int No, string UserID, string ReviewBy, string About, string PerformanceReview,string DateReview, bool Status, bool DeleteStatus)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@No", No),
                    new SqlParameter("@newUserID", UserID),
                    new SqlParameter("@ReviewBy", ReviewBy),
                    new SqlParameter("@About", About),
                    new SqlParameter("@PerformanceReview", PerformanceReview),
                    new SqlParameter("@DateReview", DateReview),
                    new SqlParameter("@Status", Status),
                    new SqlParameter("@DeleteStatus", DeleteStatus)
                };
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC UpdateEmployeePerformance @No, @newUserID, @ReviewBy, @About, @PerformanceReview, @DateReview, @Status, @DeleteStatus", parameters);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int No)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmployeePerformanceById {0}", No);
                if (result > 0)
                    return Ok();
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }
    }
}
