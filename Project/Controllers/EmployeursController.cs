using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Ressources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeursController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public EmployeursController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }
        [HttpGet]
        [Route("Get_Employeurs")]
        public async Task<ActionResult<IEnumerable<DEmployeur>>> GetEmployee()
        {
            if (_userContext.DEmployeurs == null)
            {
                return NotFound();
            }
            return await _userContext.DEmployeurs.ToListAsync();

        }
        [HttpPut("employeur/{id}")]
        public IActionResult UpdateEmEtat(int id, Etat emEtat)
        {
            // Retrieve the existing Employeur object with the specified Id from your data store
            var existingEmployeur = _userContext.DEmployeurs.Find(id);

            if (existingEmployeur == null)
            {
                return NotFound();
            }

            // Update the EmEtat property of the existing Employeur object with the new value
            existingEmployeur.EmEtat = emEtat.RpEtat;

            // Save the changes to your data store
            _userContext.SaveChanges();

            // Check if the current user is a "Commercial" user
            var currentUser = _userContext.DUsers.FirstOrDefault(u => u.UserId == emEtat.UserId);
            if (currentUser != null && currentUser.Etat == 0)
            {
                // Save the action to the CommercialActions table
                var commercialAction = new DCommercialAction
                {
                    UserId = currentUser.UserId,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Action = "Modifier Etat Employeur",
                    TableName = "DEmployeur",
                    RowIdaction = id,
                    ActionDate = DateTime.UtcNow
                };

                _userContext.DCommercialActions.Add(commercialAction);
                _userContext.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DEmployeur>> DeleteEmployee(int id, string userId)
        {
            if (_userContext.DEmployeurs == null)
            {
                return NotFound();
            }
            var employee = await _userContext.DEmployeurs.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _userContext.DEmployeurs.Remove(employee);
            await _userContext.SaveChangesAsync();

            // Check if the current user is a "Commercial" user
            var currentUser = await _userContext.DUsers.FirstOrDefaultAsync(u => u.UserId == userId);
            if (currentUser != null && currentUser.Etat == 0)
            {
                // Save the action to the CommercialActions table
                var commercialAction = new DCommercialAction
                {
                    UserId = currentUser.UserId,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Action = "DeleteEmployee",
                    TableName = "DEmployeur",
                    RowIdaction = id,
                    ActionDate = DateTime.UtcNow
                };

                _userContext.DCommercialActions.Add(commercialAction);
                await _userContext.SaveChangesAsync();
            }

            return Ok();
        }



    }


}

