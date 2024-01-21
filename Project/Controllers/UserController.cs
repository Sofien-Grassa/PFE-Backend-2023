using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Tools;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly RessourcesContext _userContext;
        public UserController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }
        [HttpGet]
        [Route("Get_Users")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                List<DUser> ListeUSers = _userContext.DUsers.ToList();
                if (ListeUSers != null)
                {
                    return Ok(ListeUSers);
                }
                return Ok("they are no users in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("User_Name")]
        public async Task<ActionResult<string>> FetchUserNameByUserId(string userId)
        {
            var user = await _userContext.DUsers.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            string role;
            if (user.Etat == 1)
            {
                role = "Admin";
            }
            else if (user.Etat == 0)
            {
                role = "Commercial";
            }
            else
            {
                return BadRequest("Invalid user state.");
            }

            return Ok($"{role} : {user.FirstName} {user.LastName}");
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> UserRegistration(DUser user)
        {
            try
            {
                var dbUser = _userContext.DUsers.Where(u => u.Login == user.Login).FirstOrDefault();
                if (dbUser != null)
                {
                    return BadRequest("Login already exists");
                }
                user.Password = Password.hashPassword(user.Password);

                // Generate UserId based on the next Id value
                int nextId = (_userContext.DUsers.Max(u => (int?)u.Id) ?? 0) + 1;
                user.UserId = "user" + nextId.ToString("D3");

                _userContext.DUsers.Add(user);
                await _userContext.SaveChangesAsync();
                return Ok("user is successfully registered");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, details = ex.ToString() });
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<DUser>> PutUser(int id, DUser employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _userContext.Entry(employee).State = EntityState.Modified;
            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<DUser>> DeleteUser(int id)
        {
            if (_userContext.DUsers == null)
            {
                return NotFound();
            }

            var user = await _userContext.DUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            // Manual cleanup of associated records in D_CommercialActions
            var associatedCommercialActions = _userContext.DCommercialActions
                                                         .Where(ca => ca.UserId == user.UserId);

            _userContext.DCommercialActions.RemoveRange(associatedCommercialActions);

            // Delete the user
            _userContext.DUsers.Remove(user);

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // You might want to handle the exception here, possibly returning a custom message to the client
                throw;
            }

            return Ok();
        }

    }
}


