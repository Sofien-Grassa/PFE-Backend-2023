using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Tools;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public LoginController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Userlogin(User_login l)
        {
            try
            {
                String password = Password.hashPassword(l.Password);
                var dbUser = _userContext.DUsers.Where(u => u.Login == l.Login && u.Password == password).Select(u => new
                {
                    u.UserId, // Add the UserId to the response
                    u.FirstName,
                    u.LastName,
                    u.Email,
                    u.Etat,
                }).FirstOrDefault();
                if (dbUser == null)
                {
                    return StatusCode(400, "user or password is incorrect");
                }
                return Ok(dbUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("userRoles/{userId}")]
        public async Task<ActionResult> GetUserRoles(string userId)
        {
            try
            {
                // Récupérer l'utilisateur
                var user = _userContext.DUsers.FirstOrDefault(u => u.UserId == userId);

                // Si l'utilisateur n'existe pas, retourner une erreur
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Si l'état de l'utilisateur est 1, retourner tous les rôles de la table Roles
                if (user.Etat == 1)
                {
                    var allRoles = _userContext.DRoles.Select(r => new { r.CodeRole }).ToList();
                    return Ok(allRoles);
                }

                // Sinon, retourner les rôles associés à l'utilisateur, sauf le rôle "gu" si l'état de l'utilisateur est 0
                var userRoles = _userContext.DUserRoles
                    .Where(ur => ur.UserId == userId && (user.Etat != 0 || ur.CodeRole != "gu"))
                    .Select(ur => new
                    {
                        ur.UserId,
                        ur.CodeRole
                    })
                    .ToList();

                // Si aucun rôle n'est trouvé pour l'utilisateur, retourner une liste vide
                if (userRoles == null || userRoles.Count == 0)
                {
                    return Ok(new List<object>());
                }

                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}

