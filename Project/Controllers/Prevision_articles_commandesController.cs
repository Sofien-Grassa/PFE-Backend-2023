using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Prevision_articles_commandesController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public Prevision_articles_commandesController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }
        [HttpGet("commandes")]
        public async Task<Dictionary<string, List<string>>> GetLignesCommandeAsync()
        {
            string queryString = @"
        SELECT 
            L.[DO_Piece] AS DoPiece,
            L.[AR_Ref] AS ArRef,
            L.[DL_Design] AS DlDesign
        FROM 
            D_DOCLIGNE AS L
        WHERE 
            L.[DO_Domaine] = 0 AND L.[DO_Type] = 1
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var commandes = new Dictionary<string, List<string>>();
                    while (await result.ReadAsync())
                    {
                        string doPiece = result.GetString(result.GetOrdinal("DoPiece"));
                        string arRef = result.GetString(result.GetOrdinal("ArRef"));
                        if (!commandes.ContainsKey(doPiece))
                        {
                            commandes[doPiece] = new List<string>();
                        }
                        commandes[doPiece].Add(arRef);
                    }
                    return commandes;
                }
            }
        }
        private Dictionary<(string, string), int> ComputeAssociations(Dictionary<string, List<string>> commandes)
        {
            var associations = new Dictionary<(string, string), int>();

            foreach (var commande in commandes.Values)
            {
                for (int i = 0; i < commande.Count; i++)
                {
                    for (int j = i + 1; j < commande.Count; j++)
                    {
                        var pair = (commande[i], commande[j]);

                        if (associations.ContainsKey(pair))
                        {
                            associations[pair]++;
                        }
                        else
                        {
                            associations[pair] = 1;
                        }
                    }
                }
            }

            return associations;
        }
        [HttpGet("recommendations")]
        public async Task<IActionResult> GetRecommendations(string arRef)
        {
            var commandes = await GetLignesCommandeAsync();
            var associations = ComputeAssociations(commandes);

            var totalAssociations = associations
                .Where(pair => pair.Key.Item1 == arRef || pair.Key.Item2 == arRef)
                .Sum(pair => pair.Value);

            var recommendations = associations
                .Where(pair => pair.Key.Item1 == arRef || pair.Key.Item2 == arRef)
                .Select(pair => new
                {
                    product = pair.Key.Item1 == arRef ? pair.Key.Item2 : pair.Key.Item1,
                    percentage = Math.Round((double)pair.Value / totalAssociations * 100, 2)  // Round to 2 decimal places
                })
                .OrderByDescending(pair => pair.percentage)
                .ToList();

            return Ok(recommendations);
        }

        [HttpGet("unique-articles")]
        public async Task<IActionResult> GetUniqueArticles()
        {
            string queryString = @"
        SELECT DISTINCT L.[AR_Ref] AS ArRef
        FROM D_DOCLIGNE AS L
        WHERE L.[DO_Domaine] = 0 AND L.[DO_Type] = 1
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var uniqueArticles = new List<string>();
                    while (await result.ReadAsync())
                    {
                        string arRef = result.GetString(result.GetOrdinal("ArRef"));
                        uniqueArticles.Add(arRef);
                    }

                    return Ok(uniqueArticles);
                }
            }
        }

    }
}
