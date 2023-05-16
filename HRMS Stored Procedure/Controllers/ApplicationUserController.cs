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
        public async Task<IActionResult> Create([FromBody] AddApplicationUserDTO appDTO)
        {
            try
            {
                if (appDTO == null)
                    BadRequest("No resource found");

                if (ModelState.IsValid)
                {
                    var emp = new ApplicationUser()
                    {
                        FirstName = appDTO.FirstName,
                        MiddleName = appDTO.MiddleName,
                        LastName = appDTO.LastName,
                        FullName = appDTO.FirstName + " " + appDTO.MiddleName + " " + appDTO.LastName,
                        Gender = appDTO.Gender,
                        DateOfBirth = appDTO.DateOfBirth,
                        Phone = appDTO.Phone,
                        Email = appDTO.Email,
                        UserName = appDTO.Email,
                        EmployeeType = appDTO.EmployeeType,
                        /*SSSNumber = appDTO.SSSNumber,
                        PagIbigId = appDTO.PagIbigId,
                        PhilHealthId = appDTO.PhilHealthId,*/
                        Street = appDTO.Street,
                        Barangay = appDTO.Barangay,
                        City = appDTO.City,
                        State = appDTO.State,
                        PostalCode = appDTO.PostalCode,
                        DateHired = appDTO.DateHired,
                        ActiveStatus = true,
                        DeleteStatus = false
                    };

                    var result = await _userManager.CreateAsync(emp, appDTO.Password);

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
                return BadRequest("Error, Please Try Again!\n\n" + ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var result = await _userManager.Users.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n"+ ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var employee = await _userManager.FindByIdAsync(id);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return NotFound("No Records Found!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error, Please Try Again!\n\n" + ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] EditApplicationUserDTO editDTO)
        {
            try
            {
                var modeltoupdate = await _userManager.FindByIdAsync(id);
                if (modeltoupdate != null)
                {
                    if (ModelState.IsValid)
                    {
                        modeltoupdate.Id = id;
                        modeltoupdate.FirstName = editDTO.FirstName;
                        modeltoupdate.MiddleName = editDTO.MiddleName;
                        modeltoupdate.LastName = editDTO.LastName;
                        modeltoupdate.FullName = editDTO.FirstName + " " + editDTO.MiddleName + " " + editDTO.LastName;
                        modeltoupdate.Gender = editDTO.Gender;
                        modeltoupdate.DateOfBirth = editDTO.DateOfBirth;
                        modeltoupdate.Phone = editDTO.Phone;
                        modeltoupdate.EmployeeType = editDTO.EmployeeType;
                        /* modeltoupdate.SSSNumber = editDTO.SSSNumber;
                         modeltoupdate.PagIbigId = editDTO.PagIbigId;
                         modeltoupdate.PhilHealthId = editDTO.PhilHealthId;*/
                        modeltoupdate.Street = editDTO.Street;
                        modeltoupdate.Barangay = editDTO.Barangay;
                        modeltoupdate.City = editDTO.City;
                        modeltoupdate.State = editDTO.State;
                        modeltoupdate.PostalCode = editDTO.PostalCode;
                        modeltoupdate.DateHired = editDTO.DateHired;
                        modeltoupdate.ActiveStatus = editDTO.ActiveStatus;
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
                return BadRequest("Error, Please Try Again!\n\n" + ex);
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
                return BadRequest("Error, Please Try Again!\n\n" + ex);
            }
        }
    }
}
