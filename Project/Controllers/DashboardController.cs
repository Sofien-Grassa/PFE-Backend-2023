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
    public class DashboardController : ControllerBase
    {
        private readonly RessourcesContext _userContext;
        public DashboardController(RessourcesContext userContext)
        {
            _userContext = userContext;
        }



        [HttpGet("TotalTTC_BL")]
        public async Task<IActionResult> GetTotalTTC_BL()
        {
            var queryString = @"
        SELECT SUM(D.[DO_TotalTTC]) AS Total_TTC
        FROM D_COMPTET AS C
        JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        WHERE D.[DO_Domaine] = 0 AND (D.[DO_Type] = 3);
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    decimal totalTTC = 0;

                    if (await result.ReadAsync())
                    {
                        totalTTC = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                    }

                    return Ok(new { Total_TTC = totalTTC });
                }
            }
        }
        [HttpGet("TotalTTC_BLP")]
        public async Task<IActionResult> GetTotalTTC_BLP()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
            DateTime sameDayPreviousMonth = today.AddMonths(-1);

            var queryString = $@"
       SELECT
    IIF(MONTH(D.[DO_Date]) = {today.Month}, 'CurrentMonth', 'PreviousMonth') AS Month,
    SUM(D.[DO_TotalTTC]) AS Total_TTC
FROM D_COMPTET AS C
JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
WHERE D.[DO_Domaine] = 0
    AND D.[DO_Type] = 3
    AND (
        (
            D.[DO_Date] >= '{firstDayOfCurrentMonth.ToString("yyyy-MM-dd")}'
            AND D.[DO_Date] <= '{today.ToString("yyyy-MM-dd")}'
        ) OR (
            D.[DO_Date] >= '{firstDayOfPreviousMonth.ToString("yyyy-MM-dd")}'
            AND D.[DO_Date] <= '{sameDayPreviousMonth.ToString("yyyy-MM-dd")}'
        )
    )
GROUP BY MONTH(D.[DO_Date]);

    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                decimal totalTTC_CurrentMonth = 0;
                decimal totalTTC_PreviousMonth = 0;

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        if (result.GetString(result.GetOrdinal("Month")) == "CurrentMonth")
                        {
                            totalTTC_CurrentMonth = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                        }
                        else
                        {
                            totalTTC_PreviousMonth = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                        }
                    }
                }

                decimal percentage = 0;

                if (totalTTC_PreviousMonth != 0)
                {
                    percentage = ((totalTTC_CurrentMonth - totalTTC_PreviousMonth) / totalTTC_PreviousMonth) * 100;
                }

                return Ok(new
                {
                    TotalTTC_CurrentMonth = totalTTC_CurrentMonth,
                    TotalTTC_PreviousMonth = totalTTC_PreviousMonth,
                    Percentage = percentage
                });
            }
        }



        [HttpGet("TotalTTC_fA")]
        public async Task<IActionResult> GetTotalTTC_FA()
        {
            var queryString = @"
        SELECT SUM(D.[DO_TotalTTC]) AS Total_TTC
        FROM D_COMPTET AS C
        JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        WHERE D.[DO_Domaine] = 0 AND (D.[DO_Type] = 6);
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    decimal totalTTC = 0;

                    if (await result.ReadAsync())
                    {
                        totalTTC = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                    }

                    return Ok(new { Total_TTC = totalTTC });
                }
            }
        }

        [HttpGet("TotalTTC_fAP")]
        public async Task<IActionResult> GetTotalTTC_FAP()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
            DateTime sameDayPreviousMonth = today.AddMonths(-1);

            var queryString = $@"
SELECT
    IIF(MONTH(D.[DO_Date]) = {today.Month}, 'CurrentMonth', 'PreviousMonth') AS Month,
    SUM(D.[DO_TotalTTC]) AS Total_TTC
FROM D_COMPTET AS C
JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
WHERE D.[DO_Domaine] = 0
    AND D.[DO_Type] = 6
    AND (
        (
            D.[DO_Date] >= '{firstDayOfCurrentMonth.ToString("yyyy-MM-dd")}'
            AND D.[DO_Date] <= '{today.ToString("yyyy-MM-dd")}'
        ) OR (
            D.[DO_Date] >= '{firstDayOfPreviousMonth.ToString("yyyy-MM-dd")}'
            AND D.[DO_Date] <= '{sameDayPreviousMonth.ToString("yyyy-MM-dd")}'
        )
    )
GROUP BY MONTH(D.[DO_Date]);

";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                decimal totalTTC_CurrentMonth = 0;
                decimal totalTTC_PreviousMonth = 0;

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        if (result.GetString(result.GetOrdinal("Month")) == "CurrentMonth")
                        {
                            totalTTC_CurrentMonth = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                        }
                        else
                        {
                            totalTTC_PreviousMonth = result.GetDecimal(result.GetOrdinal("Total_TTC"));
                        }
                    }
                }

                decimal percentage = 0;

                if (totalTTC_PreviousMonth != 0)
                {
                    percentage = ((totalTTC_CurrentMonth - totalTTC_PreviousMonth) / totalTTC_PreviousMonth) * 100;
                }

                return Ok(new
                {
                    TotalTTC_CurrentMonth = totalTTC_CurrentMonth,
                    TotalTTC_PreviousMonth = totalTTC_PreviousMonth,
                    Percentage = percentage
                });
            }
        }



        [HttpGet("TotalRetenue")]
        public async Task<IActionResult> GetTotalRetenue()
        {
            var queryString = @"
        SELECT SUM(R.[RG_Montant]) AS Total_RG_Montant
        FROM D_COMPTET AS C
        JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
        WHERE R.[RG_TypeReg] = 3 AND R.[DO_Type] = 50;
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

               

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    decimal totalRGMontant = 0;

                    if (await result.ReadAsync())
                    {
                        totalRGMontant = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                    }

                    return Ok(new { Total_RG_Montant = totalRGMontant });
                }
            }
        }

        [HttpGet("TotalRetenueP")]
        public async Task<IActionResult> GetTotalRetenueP()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
            DateTime sameDayPreviousMonth = today.AddMonths(-1);

            var queryString = $@"
SELECT
    IIF(MONTH(R.[RG_Date]) = {today.Month}, 'CurrentMonth', 'PreviousMonth') AS Month,
    SUM(R.[RG_Montant]) AS Total_RG_Montant
FROM D_COMPTET AS C
JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
WHERE R.[RG_TypeReg] = 3 AND R.[DO_Type] = 50
    AND (
        (
            R.[RG_Date] >= '{firstDayOfCurrentMonth.ToString("yyyy-MM-dd")}'
            AND R.[RG_Date] <= '{today.ToString("yyyy-MM-dd")}'
        ) OR (
            R.[RG_Date] >= '{firstDayOfPreviousMonth.ToString("yyyy-MM-dd")}'
            AND R.[RG_Date] <= '{sameDayPreviousMonth.ToString("yyyy-MM-dd")}'
        )
    )
GROUP BY MONTH(R.[RG_Date]);

";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                decimal totalRGMontant_CurrentMonth = 0;
                decimal totalRGMontant_PreviousMonth = 0;

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        if (result.GetString(result.GetOrdinal("Month")) == "CurrentMonth")
                        {
                            totalRGMontant_CurrentMonth = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                        }
                        else
                        {
                            totalRGMontant_PreviousMonth = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                        }
                    }
                }

                decimal percentage = 0;

                if (totalRGMontant_PreviousMonth != 0)
                {
                    percentage = ((totalRGMontant_CurrentMonth - totalRGMontant_PreviousMonth) / totalRGMontant_PreviousMonth) * 100;
                }

                return Ok(new
                {
                    TotalRGMontant_CurrentMonth = totalRGMontant_CurrentMonth,
                    TotalRGMontant_PreviousMonth = totalRGMontant_PreviousMonth,
                    Percentage = percentage
                });
            }
        }


        [HttpGet("TotalReglement")]
        public async Task<IActionResult> GetTotalReglement()
        {
            var queryString = @"
        SELECT SUM(R.[RG_Montant]) AS Total_RG_Montant
        FROM D_COMPTET AS C
        JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
        WHERE R.[RG_TypeReg] = 0 AND R.[DO_Type] = 50;
    ";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

               

                await _userContext.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    decimal totalRGMontant = 0;

                    if (await result.ReadAsync())
                    {
                        totalRGMontant = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                    }

                    return Ok(new { Total_RG_Montant = totalRGMontant });
                }
            }
        }

        [HttpGet("TotalReglementP")]
        public async Task<IActionResult> GetTotalReglementP()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            DateTime firstDayOfPreviousMonth = firstDayOfCurrentMonth.AddMonths(-1);
            DateTime sameDayPreviousMonth = today.AddMonths(-1);

            var queryString = $@"
SELECT
    IIF(MONTH(R.[RG_Date]) = {today.Month}, 'CurrentMonth', 'PreviousMonth') AS Month,
    SUM(R.[RG_Montant]) AS Total_RG_Montant
FROM D_COMPTET AS C
JOIN D_CREGLEMENT AS R ON C.[CT_Num] = R.[CT_NumPayeur]
WHERE R.[RG_TypeReg] = 0 AND R.[DO_Type] = 50
    AND (
        (
            R.[RG_Date] >= '{firstDayOfCurrentMonth.ToString("yyyy-MM-dd")}'
            AND R.[RG_Date] <= '{today.ToString("yyyy-MM-dd")}'
        ) OR (
            R.[RG_Date] >= '{firstDayOfPreviousMonth.ToString("yyyy-MM-dd")}'
            AND R.[RG_Date] <= '{sameDayPreviousMonth.ToString("yyyy-MM-dd")}'
        )
    )
GROUP BY MONTH(R.[RG_Date]);

";

            using (var command = _userContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = queryString;

                await _userContext.Database.OpenConnectionAsync();

                decimal totalRGMontant_CurrentMonth = 0;
                decimal totalRGMontant_PreviousMonth = 0;

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                    {
                        if (result.GetString(result.GetOrdinal("Month")) == "CurrentMonth")
                        {
                            totalRGMontant_CurrentMonth = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                        }
                        else
                        {
                            totalRGMontant_PreviousMonth = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"));
                        }
                    }
                }

                decimal percentage = 0;

                if (totalRGMontant_PreviousMonth != 0)
                {
                    percentage = ((totalRGMontant_CurrentMonth - totalRGMontant_PreviousMonth) / totalRGMontant_PreviousMonth) * 100;
                }

                return Ok(new
                {
                    TotalRGMontant_CurrentMonth = totalRGMontant_CurrentMonth,
                    TotalRGMontant_PreviousMonth = totalRGMontant_PreviousMonth,
                    Percentage = percentage
                });
            }
        }




        [HttpGet("TotalTTCByYearMonth/{year}")]
        public async Task<IActionResult> GetTotalTTCByYearMonth(int year)
        {
            var queryString = $@"
        SELECT 
            YEAR(D.[DO_Date]) AS Annee,
            MONTH(D.[DO_Date]) AS Mois,
            SUM(D.[DO_TotalTTC]) AS Total_TTC
        FROM 
            D_COMPTET AS C
        JOIN 
            D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
        WHERE 
            D.[DO_Domaine] = 0 AND (D.[DO_Type] = 3 OR D.[DO_Type] = 6) AND YEAR(D.[DO_Date]) = {year}
        GROUP BY 
            YEAR(D.[DO_Date]), MONTH(D.[DO_Date]);
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
                            Annee = result.GetInt32(result.GetOrdinal("Annee")),
                            Mois = result.GetInt32(result.GetOrdinal("Mois")),
                            Total_TTC = result.GetDecimal(result.GetOrdinal("Total_TTC"))
                        });
                    }

                    return Ok(data);
                }
            }
        }


        [HttpGet("Total_RG_MontantByYearMonth/{year}")]
        public async Task<IActionResult> GetTotal_RG_MontantByYearMonth(int year)
        {
            var queryString = $@"
        SELECT 
            YEAR(D.[RG_Date]) AS Annee,
            MONTH(D.[RG_Date]) AS Mois,
            SUM(D.[RG_Montant]) AS Total_RG_Montant
        FROM 
            D_COMPTET AS C
        JOIN 
            D_CREGLEMENT AS D ON C.[CT_Num] = D.[CT_NumPayeur]
        WHERE 
            D.[DO_Type] = 50 AND (D.[RG_TypeReg] = 0 OR D.[RG_TypeReg] = 3) AND YEAR(D.[RG_Date]) = {year}
        GROUP BY 
            YEAR(D.[RG_Date]), MONTH(D.[RG_Date]);
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
                            Annee = result.GetInt32(result.GetOrdinal("Annee")),
                            Mois = result.GetInt32(result.GetOrdinal("Mois")),
                            Total_RG_Montant = result.GetDecimal(result.GetOrdinal("Total_RG_Montant"))
                        });
                    }

                    return Ok(data);
                }
            }
        }
        [HttpGet("TotalTTCByTop5Client/{year}")]
        public async Task<IActionResult> GetTotalTTCByTop5Client(int year)
        {
            var queryString = $@"
            SELECT TOP 5 C.[CT_Num], C.[CT_Intitule], SUM(D.[DO_TotalTTC]) AS Total_TTC 
            FROM D_COMPTET AS C 
            JOIN D_DOCENTETE AS D ON C.[CT_Num] = D.[DO_Tiers]
            WHERE D.[DO_Domaine] = 0 AND (D.[DO_Type] = 3 OR D.[DO_Type] = 6) AND YEAR(D.[DO_Date]) = {year}
            GROUP BY C.[CT_Num], C.[CT_Intitule]
            ORDER BY Total_TTC DESC;
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
                            CT_Num = result.GetString(result.GetOrdinal("CT_Num")),
                            CT_Intitule = result.GetString(result.GetOrdinal("CT_Intitule")),
                            Total_TTC = result.GetDecimal(result.GetOrdinal("Total_TTC"))
                        });
                    }

                    return Ok(data);
                }
            }
        }



        [HttpGet("TopArticlesByTotalTTC/{year}")]
        public async Task<IActionResult> GetTopArticlesByTotalTTC(int year)
        {
            var queryString = $@"
        SELECT TOP 5
            A.[AR_Ref],
            A.[AR_Design],
            SUM(L.[DL_MontantTTC]) AS Total_TTC
        FROM 
            D_ARTICLE AS A
        JOIN 
            D_DOCLIGNE AS L ON A.[AR_Ref] = L.[AR_Ref]
        WHERE
            A.[AR_Nomencl] = 1
            AND YEAR(L.[DO_Date]) = {year}
        GROUP BY 
            A.[AR_Ref], A.[AR_Design]
        ORDER BY
            Total_TTC DESC;
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
                            AR_Ref = result.GetString(result.GetOrdinal("AR_Ref")),
                            AR_Design = result.GetString(result.GetOrdinal("AR_Design")),
                            Total_TTC = result.GetDecimal(result.GetOrdinal("Total_TTC"))
                        });
                    }

                    return Ok(data);
                }
            }
        }





    }
}
