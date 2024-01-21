using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_RolesController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public User_RolesController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }
    
    [HttpGet]
    [Route("Users")]
    public async Task<List<DUser>> FetchUsersWithEtatAsync(int etat)
    {
        using (var context = new RessourcesContext()) // Replace "YourDbContext" with the actual DbContext class name
        {
            return await context.DUsers.Where(u => u.Etat == etat).ToListAsync();
        }
    }
        [HttpGet]
        [Route("Roles")]
        public async Task<List<DRole>> FetchAllRolesAsync()
        {
            using (var context = new RessourcesContext()) // Replace "YourDbContext" with the actual DbContext class name
            {
                return await context.DRoles
                    .Where(role => role.CodeRole != "gu")
                    .ToListAsync();
            }
        }

        [HttpPost]
        [Route("Add_User_Role")]
        public async Task<IActionResult> AddUserRoleAsync(string userId, string codeRole)
        {
            try
            {
                using (var context = new RessourcesContext()) // Replace "YourDbContext" with the actual DbContext class name
                {
                    // Check if the combination of UserId and CodeRole already exists in the table
                    var existingUserRole = await context.DUserRoles
                        .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.CodeRole == codeRole);

                    if (existingUserRole != null)
                    {
                        // If the combination already exists, return a BadRequest with an error message
                        return BadRequest("This user already has the specified role.");
                    }

                    var newUserRole = new DUserRole
                    {
                        UserId = userId,
                        CodeRole = codeRole
                    };

                    context.DUserRoles.Add(newUserRole);
                    await context.SaveChangesAsync();
                }

                // If the record was successfully inserted, return a 201 Created status
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("User_Roles")]
        public async Task<ActionResult<List<DRole>>> FetchRolesByUserId(string userId)
        {
            var userRoles = await _userContext.DUserRoles.Where(ur => ur.UserId == userId).ToListAsync();

            if (userRoles == null || userRoles.Count == 0)
            {
                return NotFound("No roles found for the specified user.");
            }

            var roleCodes = userRoles.Select(ur => ur.CodeRole);
            var roles = await _userContext.DRoles.Where(r => roleCodes.Contains(r.CodeRole)).ToListAsync();

            return Ok(roles);
        }
        [HttpDelete]
        [Route("Delete_User_Role")]
        public async Task<IActionResult> DeleteUserRoleAsync(string userId, string codeRole)
        {
            try
            {
                using (var context = new RessourcesContext())
                {
                    var existingUserRole = await context.DUserRoles
                        .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.CodeRole == codeRole);

                    if (existingUserRole == null)
                    {
                        return NotFound("The specified user role does not exist.");
                    }

                    context.DUserRoles.Remove(existingUserRole);
                    await context.SaveChangesAsync();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

    }
}
  