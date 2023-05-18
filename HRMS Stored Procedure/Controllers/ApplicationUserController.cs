using HRMS_Stored_Procedure.Data;
using HRMS_Stored_Procedure.DTO;
using HRMS_Stored_Procedure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HRMSDbContext _context;
        private RoleManager<IdentityRole> _roleManager;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, HRMSDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(string FirstName, string MiddleName, string LastName, string Gender, DateTime DateOfBirth, string Phone, string Email,int DepartmenttId,int PosistionId, string EmployeeType, 
                                                string Street, string Barangay, string City, string State, string PostalCode, DateTime DateHired, bool activeStatus, bool deleteStatus, string Password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp = new ApplicationUser()
                    {
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        LastName = LastName,
                        FullName = FirstName + " " + MiddleName + " " + LastName,
                        Gender = Gender,
                        DateOfBirth = DateOfBirth,
                        Phone = Phone,
                        Email = Email,
                        UserName = Email,
                        DepartmentId = DepartmenttId,
                        PositionId = PosistionId,
                        EmployeeType = EmployeeType,
                        Street = Street,
                        Barangay = Barangay,
                        City = City,
                        State = State,
                        PostalCode = PostalCode,
                        DateHired = DateHired,
                        ActiveStatus = activeStatus,
                        DeleteStatus = deleteStatus
                    };

                    var result = await _userManager.CreateAsync(emp, Password);

                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return BadRequest(ModelState);
                    }

                    var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "Employee");

                    if (role != null)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(emp, role.Name);

                        if (!roleResult.Succeeded)
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            return BadRequest(ModelState);
                        }
                    }
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
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
                var applicationUsers = await _userManager.Users.ToListAsync();

                var departmentIds = applicationUsers.Select(dp => dp.DepartmentId).Distinct();
                var departments = await _context.Departments.Where(d => departmentIds.Contains(d.DeptId)).ToListAsync();

                var positionIds = applicationUsers.Select(dp => dp.PositionId).Distinct();
                var positions = await _context.Positions.Where(p => positionIds.Contains(p.PosId)).ToListAsync();

                var result = applicationUsers
                    .Join(departments, dp => dp.DepartmentId, d => d.DeptId, (dp, d) => new
                    {
                        dp.Id,
                        FirstName = dp.FirstName,
                        MiddleName = dp.MiddleName,
                        LastName = dp.LastName,
                        FullName = dp.FirstName + " " + dp.MiddleName + " " + dp.LastName,
                        Gender = dp.Gender,
                        DateOfBirth = dp.DateOfBirth,
                        Phone = dp.Phone,
                        Email = dp.Email,
                        UserName = dp.Email,
                        DepartmentId = dp.DepartmentId,
                        PositionId = dp.PositionId,
                        EmployeeType = dp.EmployeeType,
                        Street = dp.Street,
                        Barangay = dp.Barangay,
                        City = dp.City,
                        State = dp.State,
                        PostalCode = dp.PostalCode,
                        DateHired = dp.DateHired,
                        ActiveStatus = dp.ActiveStatus,
                        DeleteStatus = dp.DeleteStatus,
                        DepartmentName = d.DeptName,
                    })
                    .Join(positions, dp => dp.PositionId, p => p.PosId, (dp, p) => new
                    {
                        dp.Id,
                        dp.FirstName,
                        dp.MiddleName,
                        dp.LastName,
                        dp.FullName,
                        dp.Gender,
                        dp.DateOfBirth,
                        dp.Phone,
                        dp.Email,
                        dp.UserName,
                        dp.DepartmentId,
                        dp.DepartmentName,
                        dp.PositionId,
                        PositionName = p.PositionName,
                        dp.EmployeeType,
                        dp.Street,
                        dp.Barangay,
                        dp.City,
                        dp.State,
                        dp.PostalCode,
                        dp.DateHired,
                        dp.ActiveStatus,
                        dp.DeleteStatus
                    })
                    .ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var applicationUser = await _userManager.FindByIdAsync(id);

                var department = await _context.Departments.FirstOrDefaultAsync(d => d.DeptId == applicationUser.DepartmentId);

                var position = await _context.Positions.FirstOrDefaultAsync(p => p.PosId == applicationUser.PositionId);


                if (applicationUser != null && department != null && position != null)
                {
                    var result = new
                    {
                        applicationUser.Id,
                        applicationUser.FirstName,
                        applicationUser.MiddleName,
                        applicationUser.LastName,
                        FullName = applicationUser.FirstName + " " + applicationUser.MiddleName + " " + applicationUser.LastName,
                        applicationUser.Gender,
                        applicationUser.DateOfBirth,
                        applicationUser.Phone,
                        applicationUser.Email,
                        applicationUser.UserName,
                        applicationUser.DepartmentId,
                        DepartmentName = department.DeptName,
                        applicationUser.PositionId,
                        PositionName = position.PositionName,
                        applicationUser.EmployeeType,
                        applicationUser.Street,
                        applicationUser.Barangay,
                        applicationUser.City,
                        applicationUser.State,
                        applicationUser.PostalCode,
                        applicationUser.DateHired,
                        applicationUser.ActiveStatus,
                        applicationUser.DeleteStatus
                    };
                    return Ok(result);
                }
                    
                return NotFound("No Records Found!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> Update(string accountId, string FirstName, string MiddleName, string LastName, string Gender, DateTime DateOfBirth, string Phone,int DepartmentId, int PositionId, string EmployeeType,
                                                string Street, string Barangay, string City, string State, string PostalCode, DateTime DateHired, bool activeStatus, bool deleteStatus)
        {
            try
            {
                var modeltoupdate = await _userManager.FindByIdAsync(accountId);
                if (modeltoupdate != null)
                {
                    if (ModelState.IsValid)
                    {
                        modeltoupdate.Id = accountId;
                        modeltoupdate.FirstName = FirstName;
                        modeltoupdate.MiddleName = MiddleName;
                        modeltoupdate.LastName = LastName;
                        modeltoupdate.FullName = FirstName + " " + MiddleName + " " + LastName;
                        modeltoupdate.Gender = Gender;
                        modeltoupdate.DateOfBirth = DateOfBirth;
                        modeltoupdate.Phone = Phone;
                        modeltoupdate.DepartmentId = DepartmentId;
                        modeltoupdate.PositionId = PositionId;
                        modeltoupdate.EmployeeType = EmployeeType;
                        modeltoupdate.Street = Street;
                        modeltoupdate.Barangay = Barangay;
                        modeltoupdate.City = City;
                        modeltoupdate.State = State;
                        modeltoupdate.PostalCode = PostalCode;
                        modeltoupdate.DateHired = DateHired;
                        modeltoupdate.ActiveStatus = activeStatus;
                        modeltoupdate.DeleteStatus = deleteStatus;

                        var result = await _userManager.UpdateAsync(modeltoupdate);

                        if (result.Succeeded)
                        {
                            return Ok("Update Successfully!");
                        }
                        return BadRequest("No resource");
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                return NotFound("No Record Found!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return Ok(user.FullName + " is Delete Successfully!");
                    }
                    return BadRequest("Not succeeded!");
                }
                return NotFound("No Record Found!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex.Message);
            }
        }
    }
}
