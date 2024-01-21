using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DArticle
{
    /// <summary>
    /// **Référence de l’article
    /// </summary>
    public string ArRef { get; set; } = null!;

    /// <summary>
    /// **Désignation de l’article
    /// </summary>
    public string? ArDesign { get; set; }

    /// <summary>
    /// Référence d&apos;origine
    /// </summary>
    public string? ArRefOrig { get; set; }

    /// <summary>
    /// **Type Article ,standard ou gamme (0=Standard) et (1=Gamme)
    /// </summary>
    public short? ArType { get; set; }

    public string? Gamme1 { get; set; }

    public string? Gamme2 { get; set; }

    /// <summary>
    /// **Code de la famille 
    /// </summary>
    public string FaCodeFamille { get; set; } = null!;

    /// <summary>
    /// **Unité de l&apos;article
    /// </summary>
    public string? ArUnite { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? ArCommentaire { get; set; }

    public short? ArEtat { get; set; }

    /// <summary>
    /// **Suivi Stock : (0=Acun) et (1=CMUP)
    /// </summary>
    public short? ArSuiviStock { get; set; }

    /// <summary>
    /// Code à barre
    /// </summary>
    public string? ArCodeBarre { get; set; }

    /// <summary>
    /// Modéle
    /// </summary>
    public string? ArModel { get; set; }

    /// <summary>
    /// Code analytique
    /// </summary>
    public string? ArCodeAnalytique { get; set; }

    /// <summary>
    /// Immobilisation
    /// </summary>
    public int? ArImmobilisation { get; set; }

    /// <summary>
    /// Prix TTC
    /// </summary>
    public short? ArPrixTtc { get; set; }

    /// <summary>
    /// Prix Achat
    /// </summary>
    public decimal? ArPrixAch { get; set; }

    /// <summary>
    /// Dérnier prix d&apos;achat HT
    /// </summary>
    public decimal? ArPrixAchNouv { get; set; }

    /// <summary>
    /// Prix unitaire net
    /// </summary>
    public decimal? ArPunet { get; set; }

    public decimal? ArCoef { get; set; }

    /// <summary>
    /// Délai de livraison
    /// </summary>
    public decimal? ArDelaiLiv { get; set; }

    /// <summary>
    /// Garantie
    /// </summary>
    public decimal? ArGarantie { get; set; }

    /// <summary>
    /// Délai de sécurité
    /// </summary>
    public decimal? ArDelaiS { get; set; }

    /// <summary>
    /// Délai préparation
    /// </summary>
    public decimal? ArDelaiP { get; set; }

    /// <summary>
    /// Complément
    /// </summary>
    public string? ArComp { get; set; }

    /// <summary>
    /// Photo Article
    /// </summary>
    public byte[]? ArPhoto { get; set; }

    /// <summary>
    /// Coeifficient
    /// </summary>
    public decimal? ArPrixLoc { get; set; }

    /// <summary>
    /// Coût standard
    /// </summary>
    public decimal? ArPrixVente { get; set; }

    /// <summary>
    /// Coût standard
    /// </summary>
    public decimal? ArCoutVente { get; set; }

    public short? ArNomencl { get; set; }

    public string? RpCode { get; set; }

    public short? ArPublier { get; set; }

    public short? ArImprimer { get; set; }

    public short? ArParMetrage { get; set; }

    public short? ArParPoids { get; set; }

    public decimal? ArHauteur { get; set; }

    public decimal? ArLongueur { get; set; }

    public decimal? ArLargeur { get; set; }

    public decimal? ArPoidsNet { get; set; }

    public decimal? ArPoidsBrut { get; set; }

    public short? ArLier { get; set; }

    public short? ArPrixArtLier { get; set; }

    public decimal? ArUniteLier { get; set; }

    public bool? ArAssistance { get; set; }

    public string? ArDescAssitance { get; set; }

    public short? ArSuivitRetour { get; set; }

    /// <summary>
    /// **
    /// </summary>
    public string? ArNature { get; set; }

    /// <summary>
    /// ID unique
    /// </summary>
    public int CbMarq { get; set; }

    /// <summary>
    /// Createur (Utilisateur)
    /// </summary>
    public string? CbCreateur { get; set; }

    /// <summary>
    /// Date de modification
    /// </summary>
    public DateTime? CbModification { get; set; }

    public short? ArHorsStat { get; set; }

    public decimal? ProductionJournaliere { get; set; }

    public short? ArParZone { get; set; }

    public string? ArticleC1 { get; set; }

    public string? ArticleC2 { get; set; }

    public string? ArticleC3 { get; set; }

    public string? ArticleC4 { get; set; }

    public string? ArticleC5 { get; set; }

    public decimal? ArticleC6 { get; set; }

    public decimal? ArticleC7 { get; set; }

    public int? ArticleC8 { get; set; }

    public int? ArticleC9 { get; set; }

    public DateTime? ArticleC10 { get; set; }

    public string? ArticleC11 { get; set; }

    public string? ArticleC12 { get; set; }

    public string? ArticleC13 { get; set; }

    public decimal? ArticleC14 { get; set; }

    public decimal? ArticleC15 { get; set; }

    public int? ArticleC16 { get; set; }

    public int? ArticleC17 { get; set; }

    public DateTime? ArticleC18 { get; set; }

    public DateTime? ArticleC19 { get; set; }

    public DateTime? ArticleC20 { get; set; }

    public short? ArFavori { get; set; }

    public short? ArPremption { get; set; }
}
