﻿using System;
using System.Collections.Generic;

namespace Project.Models;

public partial class DDocentete
{
    public short? DoDomaine { get; set; }

    public short? DoType { get; set; }

    public string DoPiece { get; set; } = null!;

    public string? DoSouche { get; set; }

    public DateTime? DoDate { get; set; }

    public string? DoStatut { get; set; }

    public short? DoNature { get; set; }

    public decimal? DoTotalHt { get; set; }

    public decimal? DoTotalNetHt { get; set; }

    public decimal? DoTotalTtc { get; set; }

    public decimal? DoTotalHtdev { get; set; }

    public decimal? DoTotalNetHtdev { get; set; }

    public string? DoTiers { get; set; }

    public string? CgNum { get; set; }

    public short? NCatCompta { get; set; }

    public string? DoCatCompta { get; set; }

    public string? GrCode { get; set; }

    public string? DeCode { get; set; }

    public string? DeCodeDest { get; set; }

    public string? EmpCode { get; set; }

    public string? DoPieceDv { get; set; }

    public DateTime? DoDateDv { get; set; }

    public string? DoPieceBc { get; set; }

    public DateTime? DoDateBc { get; set; }

    public string? DoPieceBl { get; set; }

    public string? DoPieceFa { get; set; }

    public string? DoPieceBav { get; set; }

    public string? DoPieceBret { get; set; }

    public string? EmCode { get; set; }

    public string? DoNumBl { get; set; }

    public DateTime? DoDateBl { get; set; }

    public string? DoNumFa { get; set; }

    public DateTime? DoDateFa { get; set; }

    public string? EmCodeDemandeur { get; set; }

    public string? EmCodeDemarcheur { get; set; }

    public string? EmCodeTransporteur { get; set; }

    public string? RpCode { get; set; }

    public DateTime? DoDateLivr { get; set; }

    public DateTime? DoDateLivrRealisee { get; set; }

    public string? DoCondLiv { get; set; }

    public decimal? DoNbreColis { get; set; }

    public string? DoTypeColis { get; set; }

    public decimal? DoTauxEscompte { get; set; }

    public decimal? DoEcart { get; set; }

    public short? DoValorisation { get; set; }

    public short? DoValide { get; set; }

    public short? DoPrint { get; set; }

    public string? DoCommentaires { get; set; }

    public string? DoCoord01 { get; set; }

    public string? DoCoord02 { get; set; }

    public int? DoProvenance { get; set; }

    public DateTime? DoDateLivPrev { get; set; }

    public short? DoDevise { get; set; }

    public decimal? DoCours { get; set; }

    public string? DoModExpo { get; set; }

    public decimal? DoPoidsBrut { get; set; }

    public decimal? DoPoidsNet { get; set; }

    public int? DoLieuLiv { get; set; }

    public int CbMarq { get; set; }

    public string? CbCreateur { get; set; }

    public DateTime? CbModification { get; set; }

    public int? DoTypeRemise { get; set; }

    public decimal? DoRemise { get; set; }

    public short? DoEtatPay { get; set; }

    public int? BqNo { get; set; }

    public int? EbNo { get; set; }

    public short? DoSt { get; set; }

    public short? DoCloture { get; set; }

    public short? DoCoffre { get; set; }

    public short? DoArchive { get; set; }

    public short? DoBcpt { get; set; }

    public string? DProjet { get; set; }

    public string? DoPieceDa { get; set; }

    public string? DoPieceOp { get; set; }

    public string? CcCode { get; set; }

    public string? BtCode { get; set; }

    public decimal? DoIndDeb { get; set; }

    public decimal? DoIndFin { get; set; }

    public decimal? DoDiffIndex { get; set; }

    public decimal? DoSommeQte { get; set; }

    public decimal? DoPerte { get; set; }

    public decimal? DoTauxEscompteDevise { get; set; }

    public decimal? DoEcartDevise { get; set; }

    public short? DoValorisationDevise { get; set; }

    public decimal? DoEscompte { get; set; }

    public int? MeNo { get; set; }

    public int? MrNo { get; set; }

    public decimal? DoMontantRest { get; set; }

    public string? DoRepresentant { get; set; }

    public string? DoRecouvreur { get; set; }

    public string? DoExonoration { get; set; }

    public DateTime? DoDateExonoration { get; set; }

    public DateTime? DoValiditeExonoration { get; set; }

    public string? Bfprod { get; set; }

    public decimal? Prodqtebl { get; set; }

    public int? EcNo { get; set; }

    public int? IdWorkflow { get; set; }

    public string? Heure { get; set; }

    public string? Central { get; set; }

    public string? Centraliste { get; set; }

    public string? Pompe { get; set; }

    public string? Pompiste { get; set; }

    public string? Silos { get; set; }

    /// <summary>
    /// Code Unité PROD (CENTRAL)
    /// </summary>
    public string? RpCodeUniteProd { get; set; }

    /// <summary>
    /// Code Reponsable PROD(CENTRALISTE)
    /// </summary>
    public string? EmCodeRespProd { get; set; }

    /// <summary>
    /// Code POMPE 
    /// </summary>
    public string? RpCodeTransProd { get; set; }

    /// <summary>
    /// Code POMPISTE
    /// </summary>
    public string? EmCodeTransProd { get; set; }

    public string? LivraisonSemaine { get; set; }

    public string? EnteteC1 { get; set; }

    public string? EnteteC2 { get; set; }

    public string? EnteteC3 { get; set; }

    public string? EnteteC4 { get; set; }

    public string? EnteteC5 { get; set; }

    public decimal? EnteteC6 { get; set; }

    public decimal? EnteteC7 { get; set; }

    public int? EnteteC8 { get; set; }

    public int? EnteteC9 { get; set; }

    public DateTime? EnteteC10 { get; set; }

    public string? DmCode { get; set; }

    public string? EnteteC11 { get; set; }

    public string? EnteteC12 { get; set; }

    public string? EnteteC13 { get; set; }

    public decimal? EnteteC14 { get; set; }

    public decimal? EnteteC15 { get; set; }

    public int? EnteteC16 { get; set; }

    public int? EnteteC17 { get; set; }

    public DateTime? EnteteC18 { get; set; }

    public DateTime? EnteteC19 { get; set; }

    public DateTime? EnteteC20 { get; set; }

    public decimal? DlCoutArticle { get; set; }

    public decimal? DlFraisTransport { get; set; }

    public decimal? DlAutreFrais { get; set; }
}
