using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using System.Security.Principal;
using Azure;
using System.Data.SqlTypes;

namespace Ressources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourcesController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public RessourcesController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        [Route("Ressources")]
        public async Task<ActionResult<IEnumerable<DRessource>>> GetRessources()
        {
            if (_userContext.DRessources == null)
            {
                return NotFound();
            }
            return await _userContext.DRessources.ToListAsync();

        }
        [HttpGet]
        [Route("RessourcePanneArrêts/{etat}")]
        public async Task<ActionResult<IEnumerable<DRessourcePanneArrêt>>> GetRessourcePanneArrêts(short? etat)
        {
            if (_userContext.DRessourcePanneArrêts == null)
            {
                return NotFound();
            }
            var ressources = await _userContext.DRessourcePanneArrêts
                .Where(r => r.RpEtat == etat)
                .ToListAsync();
            return ressources;
        }


        [HttpPut("{id}")]
        public IActionResult UpdateRpEtat(int id, [FromBody] Etat rpEtat)
        {
            Console.WriteLine($"Request received for id: {id}, RpEtat: {rpEtat.RpEtat}, UserId: {rpEtat.UserId}");

            // Retrieve the existing Ressource object with the specified Id from your data store
            var existingRessource = _userContext.DRessources.FirstOrDefault(r => r.Id == id);

            if (existingRessource == null)
            {
                if (existingRessource == null)
                {
                    return NotFound(new { message = "" });
                }
            }

            // Update the RpEtat property of the existing Ressource object with the new value
            existingRessource.RpEtat = rpEtat.RpEtat;

            // Save the changes to your data store
            _userContext.SaveChanges();

            // Check if the current user is a "Commercial" user
            var currentUser = _userContext.DUsers.FirstOrDefault(u => u.UserId == rpEtat.UserId);
            if (currentUser != null && currentUser.Etat == 0)
            {
                // Save the action to the CommercialActions table
                var commercialAction = new DCommercialAction
                {
                    UserId = currentUser.UserId,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Action = "Modifier Etat Ressource",
                    TableName = "DRessource",
                    RowIdaction = id,
                    ActionDate = DateTime.UtcNow
                };

                _userContext.DCommercialActions.Add(commercialAction);
                _userContext.SaveChanges();
            }

            return Ok();
        }
        [HttpPut("UpdateRpEtatpanne/{id}")]
        public IActionResult UpdateRpEtatpanne(int id, [FromBody] Etat rpEtat)
        {
            if (rpEtat == null)
            {
                return BadRequest("RpEtat cannot be null.");
            }

            var existingRessource = _userContext.DRessources.FirstOrDefault(r => r.Id == id);

            if (existingRessource == null)
            {
                return NotFound(new { message = "" });
            }

            existingRessource.RpEtat = rpEtat.RpEtat;


            if (rpEtat.DateDebut == null || rpEtat.DateDebut < SqlDateTime.MinValue.Value)
            {
                rpEtat.DateDebut = SqlDateTime.MinValue.Value;
            }

            if (rpEtat.DateFin == null || rpEtat.DateFin < SqlDateTime.MinValue.Value)
            {
                rpEtat.DateFin = SqlDateTime.MinValue.Value;
            }

            var panneArret = new DRessourcePanneArrêt
            {
                RpCode = existingRessource.RpCode,
                RpEtat = rpEtat.RpEtat,
                DateDebut = rpEtat.DateDebut,
                DateFin = rpEtat.DateFin
            };

            _userContext.DRessourcePanneArrêts.Add(panneArret);

            try
            {
                _userContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log error here
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
            var currentUser = _userContext.DUsers.FirstOrDefault(u => u.UserId == rpEtat.UserId);
            if (currentUser != null && currentUser.Etat == 0)
            {
                // Save the action to the CommercialActions table
                var commercialAction = new DCommercialAction
                {
                    UserId = currentUser.UserId,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Action = "Modifier Etat Ressource",
                    TableName = "DRessource",
                    RowIdaction = id,
                    ActionDate = DateTime.UtcNow
                };

                _userContext.DCommercialActions.Add(commercialAction);
                _userContext.SaveChanges();
            }

            return Ok("RpEtat updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<DRessource>> DeleteRessource(int id, string userId)
        {
            if (_userContext.DRessources == null)
            {
                return NotFound();
            }
            var ressource = await _userContext.DRessources.FindAsync(id);
            if (ressource == null)
            {
                return NotFound();
            }
            _userContext.DRessources.Remove(ressource);
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
                    Action = "DeleteRessource",
                    TableName = "DRessource",
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