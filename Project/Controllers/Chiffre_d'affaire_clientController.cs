using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Data;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Chiffre_d_affaire_clientController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public Chiffre_d_affaire_clientController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet("TotalTTCByClient")]
        public async Task<IActionResult> GetTotalTTCByClient()
        {
            var queryString = @"
        SELECT C.[CT_Num], C.[CT_Intitule], SUM(D.[DO_TotalTTC]) AS Total_TTC
        FROM D_COMPTET AS C
        JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        WHERE D.[DO_Domaine] = 0 AND (D.[DO_Type] = 3 OR D.[DO_Type] = 6)
        GROUP BY C.[CT_Num], C.[CT_Intitule];
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

               

                await _userContext.Database.OpenConnectionAsync();

                 using (var result = await command.ExecuteReaderAsync())
        {
            var data = new List<object>();
            int id = 1; // Add this line to initialize the auto-incrementing ID
            while (await result.ReadAsync())
            {
                data.Add(new
                {
                    Id = id++, // Add this line to include the auto-incrementing ID in the result
                    CT_Num = result.GetString(result.GetOrdinal("CT_Num")),
                    CT_Intitule = result.GetString(result.GetOrdinal("CT_Intitule")),
                    Total_TTC = result.GetDecimal(result.GetOrdinal("Total_TTC"))
                });
            }

            return Ok(data);
        }
    }
}


        [HttpGet("TotalReglementByClient/{ctNum}")]
        public async Task<IActionResult> GetTotalReglementByClient(string ctNum)
        {
            var queryString = $@"
        SELECT C.[CT_Num], C.[CT_Intitule], SUM(R.[RG_Montant]) AS Total_RG_Montant
        FROM D_COMPTET AS C
        JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
        WHERE R.[RG_TypeReg] = 0 AND R.[DO_Type] = 50 AND C.[CT_Num] = '{ctNum}'
        GROUP BY C.[CT_Num], C.[CT_Intitule];
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var data = new List<object>();
                    while (await result.ReadAsync())
                    {
                        data.Add(new
                        {
                            CT_Num = result.GetString(result.GetOrdinal("CT_Num")),
                            Total_RG_Montant = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"))
                        });
                    }

                    return Ok(data);
                }
            }
        }



        [HttpGet("TotalRetenueByClient/{ctNum}")]
        public async Task<IActionResult> GetTotalRetenueByClient(string ctNum)
        {
            var queryString = $@"
        SELECT C.[CT_Num], C.[CT_Intitule], SUM(R.[RG_Montant]) AS Total_RG_Montant
        FROM D_COMPTET AS C
        JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
        WHERE R.[RG_TypeReg] = 3 AND R.[DO_Type] = 50 AND C.[CT_Num] = '{ctNum}'
        GROUP BY C.[CT_Num], C.[CT_Intitule];
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var data = new List<object>();
                    while (await result.ReadAsync())
                    {
                        data.Add(new
                        {
                            CT_Num = result.GetString(result.GetOrdinal("CT_Num")),
                            Total_RG_Montant = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"))
                        });
                    }

                    return Ok(data);
                }
            }
        }




    }
}