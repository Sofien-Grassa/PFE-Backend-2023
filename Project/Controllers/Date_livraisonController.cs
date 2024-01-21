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
    public class Date_livraisonController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public Date_livraisonController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }



        [HttpGet("filtered-data")]
        public async Task<IActionResult> GetFilteredData(DateTime startDate, DateTime endDate)
        {
            var queryString = $@"
        SELECT 
            C.[CT_Num] AS CtNum, 
            C.[CT_Intitule] AS CtIntitule,
            D.[DO_Domaine] AS DoDomaine, 
            D.[DO_Type] AS DoType, 
            D.[DO_Souche] AS DoSouche, 
            D.[DO_Piece] AS DoPiece, 
            D.[DO_Date] AS DoDate, 
            D.[DO_DateLivr] AS DoDateLivr
        FROM 
            D_COMPTET AS C
        JOIN 
            D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        WHERE 
            D.[DO_Domaine] = 0 AND D.[DO_Type] = 1 AND D.[DO_DateLivr] >= '{startDate:yyyy-MM-dd}' AND D.[DO_DateLivr] <= '{endDate:yyyy-MM-dd}';
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var data = new List<object>();
                    int id = 1;
                    while (await result.ReadAsync())
                    {
                        data.Add(new
                        {
                            Id = id++,
                            DoPiece = result.GetString(result.GetOrdinal("DoPiece")),
                            DoSouche = result.GetString(result.GetOrdinal("DoSouche")),
                            DoDate = result.GetDateTime(result.GetOrdinal("DoDate")).ToString("yyyy-MM-dd"),
                            CtNum = result.GetString(result.GetOrdinal("CtNum")),
                            CtIntitule = result.GetString(result.GetOrdinal("CtIntitule")),
                            DoDateLivr = result.GetDateTime(result.GetOrdinal("DoDateLivr")).ToString("yyyy-MM-dd"),
                            IconStatus = result.GetDateTime(result.GetOrdinal("DoDateLivr")) < DateTime.Now ? "green" : "orange"
                        });

                    }

                    return Ok(data);
                }
            }
        }



        [HttpGet("filtered-data-details/{doPiece}")]
        public async Task<IActionResult> GetFilteredDataDetails(string doPiece)
        {
            var queryString = $@"
SELECT 
    L.[DO_Piece],
    L.[AR_Ref] AS ArRef,
    L.[DL_Design] AS DlDesign,
    L.[DL_Unite] AS DlUnite,
    L.[DL_Qte] AS DlQte,
    L.[DL_PrixUnitaire] AS DlPrixUnitaire
FROM 
    D_DOCLIGNE AS L
WHERE 
    L.[DO_Domaine] = 0 AND L.[DO_Type] = 1 AND L.[DO_Piece] = '{doPiece}';
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
                            DoPiece = result.GetString(result.GetOrdinal("DO_Piece")),
                            ArRef = result.GetString(result.GetOrdinal("ArRef")),
                            DlDesign = result.GetString(result.GetOrdinal("DlDesign")),
                            DlUnite = result.GetString(result.GetOrdinal("DlUnite")),
                            DlQte = result.IsDBNull(result.GetOrdinal("DlQte")) ? (decimal?)null : result.GetDecimal(result.GetOrdinal("DlQte")),
                            DlPrixUnitaire = result.IsDBNull(result.GetOrdinal("DlPrixUnitaire")) ? (decimal?)null : result.GetDecimal(result.GetOrdinal("DlPrixUnitaire"))
                        });
                    }

                    return Ok(data);
                }
            }
        }

        [HttpGet("Calander-data")]
        public async Task<IActionResult> GetCalenderData()
        {
            var queryString = @"
        SELECT
            C.[CT_Num] AS CtNum,
            C.[CT_Intitule] AS CtIntitule,
            D.[DO_Domaine] AS DoDomaine,
            D.[DO_Type] AS DoType,
            D.[DO_Piece] AS DoPiece,
            D.[DO_DateLivr] AS DoDateLivr,
            D.[RP_Code] AS RpCode,
            D.[EM_CodeTransporteur] AS EmCodeTransporteur,
            R.[RP_Immatriculation] AS RpImmatriculation,
            CH.[EM_Prenom] AS EmPrenom,
            CH.[EM_Nom] AS EmNom
        FROM
            D_COMPTET AS C
        JOIN
            D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        JOIN
            D_Ressource AS R ON D.[RP_Code] = R.[RP_Code]
        JOIN
            D_Employeur AS CH ON D.[EM_CodeTransporteur] = CH.[EM_Code]
        WHERE
            D.[DO_Domaine] = 0 AND D.[DO_Type] = 1
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var data = new List<object>();
                    int id = 1;
                    while (await result.ReadAsync())
                    {
                        data.Add(new
                        {
                            Id = id++,
                            DoPiece = result.GetString(result.GetOrdinal("DoPiece")),
                            CtNum = result.GetString(result.GetOrdinal("CtNum")),
                            CtIntitule = result.GetString(result.GetOrdinal("CtIntitule")),
                            DoDateLivr = result.GetDateTime(result.GetOrdinal("DoDateLivr")).ToString("yyyy-MM-dd"),
                            RpCode = result.GetString(result.GetOrdinal("RpCode")),
                            EmCodeTransporteur = result.GetString(result.GetOrdinal("EmCodeTransporteur")),
                            RpImmatriculation = result.GetString(result.GetOrdinal("RpImmatriculation")),
                            EmPrenom = result.GetString(result.GetOrdinal("EmPrenom")),
                            EmNom = result.GetString(result.GetOrdinal("EmNom")),
                        });
                    }

                    return Ok(data);
                }
            }
        }
        

    }
}


       