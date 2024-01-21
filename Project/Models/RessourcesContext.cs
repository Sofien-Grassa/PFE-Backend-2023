using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class RessourcesContext : DbContext
{
    public RessourcesContext()
    {
    }

    public RessourcesContext(DbContextOptions<RessourcesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DArticle> DArticles { get; set; }

    public virtual DbSet<DCommercialAction> DCommercialActions { get; set; }

    public virtual DbSet<DComptet> DComptets { get; set; }

    public virtual DbSet<DCreglement> DCreglements { get; set; }

    public virtual DbSet<DDocentete> DDocentetes { get; set; }

    public virtual DbSet<DDocligne> DDoclignes { get; set; }

    public virtual DbSet<DEmployeur> DEmployeurs { get; set; }

    public virtual DbSet<DRessource> DRessources { get; set; }

    public virtual DbSet<DRessourcePanneArrêt> DRessourcePanneArrêts { get; set; }

    public virtual DbSet<DRole> DRoles { get; set; }

    public virtual DbSet<DUser> DUsers { get; set; }

    public virtual DbSet<DUserRole> DUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-PF0NE842\\MSSQLSERVER2022;Initial Catalog=Ressource;User ID=sa;Password=***********;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DArticle>(entity =>
        {
            entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_D_ARTICLE");

            entity.ToTable("D_ARTICLE");

            entity.Property(e => e.CbMarq)
                .HasComment("ID unique")
                .HasColumnName("cbMarq");
            entity.Property(e => e.ArAssistance).HasColumnName("AR_Assistance");
            entity.Property(e => e.ArCodeAnalytique)
                .HasMaxLength(50)
                .HasComment("Code analytique")
                .HasColumnName("AR_CodeAnalytique");
            entity.Property(e => e.ArCodeBarre)
                .HasMaxLength(50)
                .HasComment("Code à barre")
                .HasColumnName("AR_CodeBarre");
            entity.Property(e => e.ArCoef)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_Coef");
            entity.Property(e => e.ArCommentaire)
                .HasMaxLength(500)
                .HasComment("Commentaire")
                .HasColumnName("AR_Commentaire");
            entity.Property(e => e.ArComp)
                .HasMaxLength(500)
                .HasComment("Complément")
                .HasColumnName("AR_Comp");
            entity.Property(e => e.ArCoutVente)
                .HasComment("Coût standard")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_CoutVente");
            entity.Property(e => e.ArDelaiLiv)
                .HasComment("Délai de livraison")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_DelaiLiv");
            entity.Property(e => e.ArDelaiP)
                .HasComment("Délai préparation")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_DelaiP");
            entity.Property(e => e.ArDelaiS)
                .HasComment("Délai de sécurité")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_DelaiS");
            entity.Property(e => e.ArDescAssitance)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AR_DescAssitance");
            entity.Property(e => e.ArDesign)
                .HasMaxLength(500)
                .HasComment("**Désignation de l’article")
                .HasColumnName("AR_Design");
            entity.Property(e => e.ArEtat).HasColumnName("AR_Etat");
            entity.Property(e => e.ArFavori).HasColumnName("AR_Favori");
            entity.Property(e => e.ArGarantie)
                .HasComment("Garantie")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_Garantie");
            entity.Property(e => e.ArHauteur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_Hauteur");
            entity.Property(e => e.ArHorsStat).HasColumnName("AR_HorsStat");
            entity.Property(e => e.ArImmobilisation)
                .HasComment("Immobilisation")
                .HasColumnName("AR_Immobilisation");
            entity.Property(e => e.ArImprimer).HasColumnName("AR_Imprimer");
            entity.Property(e => e.ArLargeur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_Largeur");
            entity.Property(e => e.ArLier).HasColumnName("AR_Lier");
            entity.Property(e => e.ArLongueur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_Longueur");
            entity.Property(e => e.ArModel)
                .HasMaxLength(50)
                .HasComment("Modéle")
                .HasColumnName("AR_Model");
            entity.Property(e => e.ArNature)
                .HasMaxLength(50)
                .HasComment("**")
                .HasColumnName("AR_Nature");
            entity.Property(e => e.ArNomencl).HasColumnName("AR_Nomencl");
            entity.Property(e => e.ArParMetrage).HasColumnName("AR_ParMetrage");
            entity.Property(e => e.ArParPoids).HasColumnName("AR_ParPoids");
            entity.Property(e => e.ArParZone).HasColumnName("AR_ParZone");
            entity.Property(e => e.ArPhoto)
                .HasComment("Photo Article")
                .HasColumnType("image")
                .HasColumnName("AR_Photo");
            entity.Property(e => e.ArPoidsBrut)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PoidsBrut");
            entity.Property(e => e.ArPoidsNet)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PoidsNet");
            entity.Property(e => e.ArPremption).HasColumnName("AR_Premption");
            entity.Property(e => e.ArPrixAch)
                .HasComment("Prix Achat")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PrixAch");
            entity.Property(e => e.ArPrixAchNouv)
                .HasComment("Dérnier prix d'achat HT")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PrixAchNouv");
            entity.Property(e => e.ArPrixArtLier).HasColumnName("AR_PrixArtLier");
            entity.Property(e => e.ArPrixLoc)
                .HasComment("Coeifficient")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PrixLoc");
            entity.Property(e => e.ArPrixTtc)
                .HasComment("Prix TTC")
                .HasColumnName("AR_PrixTTC");
            entity.Property(e => e.ArPrixVente)
                .HasComment("Coût standard")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PrixVente");
            entity.Property(e => e.ArPublier).HasColumnName("AR_Publier");
            entity.Property(e => e.ArPunet)
                .HasComment("Prix unitaire net")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_PUNet");
            entity.Property(e => e.ArRef)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("**Référence de l’article")
                .HasColumnName("AR_Ref");
            entity.Property(e => e.ArRefOrig)
                .HasMaxLength(50)
                .HasComment("Référence d'origine")
                .HasColumnName("AR_RefOrig");
            entity.Property(e => e.ArSuiviStock)
                .HasComment("**Suivi Stock : (0=Acun) et (1=CMUP)")
                .HasColumnName("AR_SuiviStock");
            entity.Property(e => e.ArSuivitRetour).HasColumnName("AR_SuivitRetour");
            entity.Property(e => e.ArType)
                .HasComment("**Type Article ,standard ou gamme (0=Standard) et (1=Gamme)")
                .HasColumnName("AR_Type");
            entity.Property(e => e.ArUnite)
                .HasMaxLength(50)
                .HasComment("**Unité de l'article")
                .HasColumnName("AR_Unite");
            entity.Property(e => e.ArUniteLier)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("AR_UniteLier");
            entity.Property(e => e.ArticleC1)
                .HasMaxLength(50)
                .HasColumnName("Article_C1");
            entity.Property(e => e.ArticleC10)
                .HasColumnType("smalldatetime")
                .HasColumnName("Article_C10");
            entity.Property(e => e.ArticleC11)
                .HasMaxLength(50)
                .HasColumnName("Article_C11");
            entity.Property(e => e.ArticleC12)
                .HasMaxLength(50)
                .HasColumnName("Article_C12");
            entity.Property(e => e.ArticleC13)
                .HasMaxLength(50)
                .HasColumnName("Article_C13");
            entity.Property(e => e.ArticleC14)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Article_C14");
            entity.Property(e => e.ArticleC15)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Article_C15");
            entity.Property(e => e.ArticleC16).HasColumnName("Article_C16");
            entity.Property(e => e.ArticleC17).HasColumnName("Article_C17");
            entity.Property(e => e.ArticleC18)
                .HasColumnType("smalldatetime")
                .HasColumnName("Article_C18");
            entity.Property(e => e.ArticleC19)
                .HasColumnType("smalldatetime")
                .HasColumnName("Article_C19");
            entity.Property(e => e.ArticleC2)
                .HasMaxLength(50)
                .HasColumnName("Article_C2");
            entity.Property(e => e.ArticleC20)
                .HasColumnType("smalldatetime")
                .HasColumnName("Article_C20");
            entity.Property(e => e.ArticleC3)
                .HasMaxLength(50)
                .HasColumnName("Article_C3");
            entity.Property(e => e.ArticleC4)
                .HasMaxLength(50)
                .HasColumnName("Article_C4");
            entity.Property(e => e.ArticleC5)
                .HasMaxLength(50)
                .HasColumnName("Article_C5");
            entity.Property(e => e.ArticleC6)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Article_C6");
            entity.Property(e => e.ArticleC7)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Article_C7");
            entity.Property(e => e.ArticleC8).HasColumnName("Article_C8");
            entity.Property(e => e.ArticleC9).HasColumnName("Article_C9");
            entity.Property(e => e.CbCreateur)
                .HasMaxLength(50)
                .HasDefaultValueSql("('CSQL')")
                .HasComment("Createur (Utilisateur)")
                .HasColumnName("cbCreateur");
            entity.Property(e => e.CbModification)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date de modification")
                .HasColumnType("smalldatetime")
                .HasColumnName("cbModification");
            entity.Property(e => e.FaCodeFamille)
                .HasMaxLength(50)
                .HasComment("**Code de la famille ")
                .HasColumnName("FA_CodeFamille");
            entity.Property(e => e.Gamme1).HasMaxLength(50);
            entity.Property(e => e.Gamme2).HasMaxLength(50);
            entity.Property(e => e.ProductionJournaliere)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Production(Journaliere)");
            entity.Property(e => e.RpCode)
                .HasMaxLength(50)
                .HasColumnName("RP_Code");
        });

        modelBuilder.Entity<DCommercialAction>(entity =>
        {
            entity.ToTable("D_CommercialActions");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RowIdaction).HasColumnName("RowIDAction");
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(7)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.DCommercialActions)
                .HasPrincipalKey(p => p.UserId)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D_CommercialActions_D_Users");
        });

        modelBuilder.Entity<DComptet>(entity =>
        {
            entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_D_COMPTET");

            entity.ToTable("D_COMPTET");

            entity.Property(e => e.CbMarq).HasColumnName("cbMarq");
            entity.Property(e => e.BtNum).HasColumnName("BT_Num");
            entity.Property(e => e.CaNum)
                .HasMaxLength(50)
                .HasColumnName("CA_Num");
            entity.Property(e => e.CaNumIfrs)
                .HasMaxLength(50)
                .HasColumnName("CA_NumIFRS");
            entity.Property(e => e.CbCreateur)
                .HasMaxLength(50)
                .HasDefaultValueSql("('CSQL')")
                .HasColumnName("cbCreateur");
            entity.Property(e => e.CbMarqSage).HasColumnName("cbMarqSage");
            entity.Property(e => e.CbModification)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("cbModification");
            entity.Property(e => e.CgNumPrinc)
                .HasMaxLength(50)
                .HasColumnName("CG_NumPrinc");
            entity.Property(e => e.CoNo).HasColumnName("CO_No");
            entity.Property(e => e.ComptetC1)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C1");
            entity.Property(e => e.ComptetC10)
                .HasColumnType("smalldatetime")
                .HasColumnName("Comptet_C10");
            entity.Property(e => e.ComptetC11)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C11");
            entity.Property(e => e.ComptetC12)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C12");
            entity.Property(e => e.ComptetC13)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C13");
            entity.Property(e => e.ComptetC14)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Comptet_C14");
            entity.Property(e => e.ComptetC15)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Comptet_C15");
            entity.Property(e => e.ComptetC16).HasColumnName("Comptet_C16");
            entity.Property(e => e.ComptetC17).HasColumnName("Comptet_C17");
            entity.Property(e => e.ComptetC18)
                .HasColumnType("smalldatetime")
                .HasColumnName("Comptet_C18");
            entity.Property(e => e.ComptetC19)
                .HasColumnType("smalldatetime")
                .HasColumnName("Comptet_C19");
            entity.Property(e => e.ComptetC2)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C2");
            entity.Property(e => e.ComptetC20)
                .HasColumnType("smalldatetime")
                .HasColumnName("Comptet_C20");
            entity.Property(e => e.ComptetC3)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C3");
            entity.Property(e => e.ComptetC4)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C4");
            entity.Property(e => e.ComptetC5)
                .HasMaxLength(50)
                .HasColumnName("Comptet_C5");
            entity.Property(e => e.ComptetC6)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Comptet_C6");
            entity.Property(e => e.ComptetC7)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Comptet_C7");
            entity.Property(e => e.ComptetC8).HasColumnName("Comptet_C8");
            entity.Property(e => e.ComptetC9).HasColumnName("Comptet_C9");
            entity.Property(e => e.CtAdresse)
                .HasMaxLength(200)
                .HasColumnName("CT_Adresse");
            entity.Property(e => e.CtApe)
                .HasMaxLength(50)
                .HasColumnName("CT_Ape");
            entity.Property(e => e.CtAssurance)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Assurance");
            entity.Property(e => e.CtBlfact).HasColumnName("CT_BLFact");
            entity.Property(e => e.CtBonApayer).HasColumnName("CT_BonAPayer");
            entity.Property(e => e.CtClassement)
                .HasMaxLength(117)
                .HasColumnName("CT_Classement");
            entity.Property(e => e.CtCodePostal)
                .HasMaxLength(50)
                .HasColumnName("CT_CodePostal");
            entity.Property(e => e.CtCodeRegion)
                .HasMaxLength(50)
                .HasColumnName("CT_CodeRegion");
            entity.Property(e => e.CtCoface)
                .HasMaxLength(50)
                .HasColumnName("CT_Coface");
            entity.Property(e => e.CtCommentaire)
                .HasMaxLength(300)
                .HasColumnName("CT_Commentaire");
            entity.Property(e => e.CtComplement)
                .HasMaxLength(150)
                .HasColumnName("CT_Complement");
            entity.Property(e => e.CtContact)
                .HasMaxLength(150)
                .HasColumnName("CT_Contact");
            entity.Property(e => e.CtControlEnc).HasColumnName("CT_ControlEnc");
            entity.Property(e => e.CtDateCreate)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_DateCreate");
            entity.Property(e => e.CtDateFermeDebut)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_DateFermeDebut");
            entity.Property(e => e.CtDateFermeFin)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_DateFermeFin");
            entity.Property(e => e.CtDateMaj)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_DateMAJ");
            entity.Property(e => e.CtDelaiAppro).HasColumnName("CT_DelaiAppro");
            entity.Property(e => e.CtDelaiTransport).HasColumnName("CT_DelaiTransport");
            entity.Property(e => e.CtEchangeCr).HasColumnName("CT_EchangeCR");
            entity.Property(e => e.CtEchangeRappro).HasColumnName("CT_EchangeRappro");
            entity.Property(e => e.CtEdiCode)
                .HasMaxLength(50)
                .HasColumnName("CT_EdiCode");
            entity.Property(e => e.CtEdiCodeSage)
                .HasMaxLength(50)
                .HasColumnName("CT_EdiCodeSage");
            entity.Property(e => e.CtEdiCodeType).HasColumnName("CT_EdiCodeType");
            entity.Property(e => e.CtEmail)
                .HasMaxLength(69)
                .HasColumnName("CT_EMail");
            entity.Property(e => e.CtEncours)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Encours");
            entity.Property(e => e.CtFacture).HasColumnName("CT_Facture");
            entity.Property(e => e.CtFactureElec).HasColumnName("CT_FactureElec");
            entity.Property(e => e.CtIdentifiant)
                .HasMaxLength(50)
                .HasColumnName("CT_Identifiant");
            entity.Property(e => e.CtIntitule)
                .HasMaxLength(150)
                .HasColumnName("CT_Intitule");
            entity.Property(e => e.CtLangue).HasColumnName("CT_Langue");
            entity.Property(e => e.CtLangueIso2)
                .HasMaxLength(50)
                .HasColumnName("CT_LangueISO2");
            entity.Property(e => e.CtLettrage).HasColumnName("CT_Lettrage");
            entity.Property(e => e.CtLivrPartielle).HasColumnName("CT_LivrPartielle");
            entity.Property(e => e.CtLocalite)
                .HasMaxLength(50)
                .HasColumnName("CT_Localite");
            entity.Property(e => e.CtNotPenal).HasColumnName("CT_NotPenal");
            entity.Property(e => e.CtNotRappel).HasColumnName("CT_NotRappel");
            entity.Property(e => e.CtNum)
                .HasMaxLength(50)
                .HasColumnName("CT_Num");
            entity.Property(e => e.CtNumCentrale)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_NumCentrale");
            entity.Property(e => e.CtNumPayeur)
                .HasMaxLength(50)
                .HasColumnName("CT_NumPayeur");
            entity.Property(e => e.CtPays)
                .HasMaxLength(50)
                .HasColumnName("CT_Pays");
            entity.Property(e => e.CtPrioriteLivr).HasColumnName("CT_PrioriteLivr");
            entity.Property(e => e.CtProfilSoc).HasColumnName("CT_ProfilSoc");
            entity.Property(e => e.CtQualite)
                .HasMaxLength(50)
                .HasColumnName("CT_Qualite");
            entity.Property(e => e.CtRaccourci)
                .HasMaxLength(50)
                .HasColumnName("CT_Raccourci");
            entity.Property(e => e.CtRecouvreur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_Recouvreur");
            entity.Property(e => e.CtRepresentInt)
                .HasMaxLength(50)
                .HasColumnName("CT_RepresentInt");
            entity.Property(e => e.CtRepresentNif)
                .HasMaxLength(50)
                .HasColumnName("CT_RepresentNIF");
            entity.Property(e => e.CtSaut).HasColumnName("CT_Saut");
            entity.Property(e => e.CtSiret)
                .HasMaxLength(50)
                .HasColumnName("CT_Siret");
            entity.Property(e => e.CtSite)
                .HasMaxLength(69)
                .HasColumnName("CT_Site");
            entity.Property(e => e.CtSoldeCommercial)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_SoldeCommercial");
            entity.Property(e => e.CtSoldeComptable)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_SoldeComptable");
            entity.Property(e => e.CtSommeil).HasColumnName("CT_Sommeil");
            entity.Property(e => e.CtSouche)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_Souche");
            entity.Property(e => e.CtStatistique01)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique01");
            entity.Property(e => e.CtStatistique02)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique02");
            entity.Property(e => e.CtStatistique03)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique03");
            entity.Property(e => e.CtStatistique04)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique04");
            entity.Property(e => e.CtStatistique05)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique05");
            entity.Property(e => e.CtStatistique06)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique06");
            entity.Property(e => e.CtStatistique07)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique07");
            entity.Property(e => e.CtStatistique08)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique08");
            entity.Property(e => e.CtStatistique09)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_Statistique09");
            entity.Property(e => e.CtStatistique10)
                .HasMaxLength(50)
                .HasColumnName("CT_Statistique10");
            entity.Property(e => e.CtStatutContrat).HasColumnName("CT_StatutContrat");
            entity.Property(e => e.CtSurveillance).HasColumnName("CT_Surveillance");
            entity.Property(e => e.CtSvCa)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_SvCA");
            entity.Property(e => e.CtSvCotation)
                .HasMaxLength(50)
                .HasColumnName("CT_SvCotation");
            entity.Property(e => e.CtSvDateBilan)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_SvDateBilan");
            entity.Property(e => e.CtSvDateCreate)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_SvDateCreate");
            entity.Property(e => e.CtSvDateIncid)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_SvDateIncid");
            entity.Property(e => e.CtSvDateMaj)
                .HasColumnType("smalldatetime")
                .HasColumnName("CT_SvDateMaj");
            entity.Property(e => e.CtSvEffectif)
                .HasMaxLength(50)
                .HasColumnName("CT_SvEffectif");
            entity.Property(e => e.CtSvFormeJuri)
                .HasMaxLength(50)
                .HasColumnName("CT_SvFormeJuri");
            entity.Property(e => e.CtSvIncident).HasColumnName("CT_SvIncident");
            entity.Property(e => e.CtSvNbMoisBilan).HasColumnName("CT_SvNbMoisBilan");
            entity.Property(e => e.CtSvObjetMaj)
                .HasMaxLength(50)
                .HasColumnName("CT_SvObjetMaj");
            entity.Property(e => e.CtSvPrivil).HasColumnName("CT_SvPrivil");
            entity.Property(e => e.CtSvRegul)
                .HasMaxLength(50)
                .HasColumnName("CT_SvRegul");
            entity.Property(e => e.CtSvResultat)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_SvResultat");
            entity.Property(e => e.CtTaux01)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Taux01");
            entity.Property(e => e.CtTaux02)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Taux02");
            entity.Property(e => e.CtTaux03)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Taux03");
            entity.Property(e => e.CtTaux04)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("CT_Taux04");
            entity.Property(e => e.CtTelecopie)
                .HasMaxLength(50)
                .HasColumnName("CT_Telecopie");
            entity.Property(e => e.CtTelephone)
                .HasMaxLength(150)
                .HasColumnName("CT_Telephone");
            entity.Property(e => e.CtTelephone1)
                .HasMaxLength(50)
                .HasColumnName("CT_Telephone1");
            entity.Property(e => e.CtTelephoneFix)
                .HasMaxLength(50)
                .HasColumnName("CT_TelephoneFix");
            entity.Property(e => e.CtTelephonePoste)
                .HasMaxLength(50)
                .HasColumnName("CT_TelephonePoste");
            entity.Property(e => e.CtType).HasColumnName("CT_Type");
            entity.Property(e => e.CtTypeNif).HasColumnName("CT_TypeNIF");
            entity.Property(e => e.CtTypeTaux02)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_TypeTaux02");
            entity.Property(e => e.CtValidEch).HasColumnName("CT_ValidEch");
            entity.Property(e => e.CtVille)
                .HasMaxLength(50)
                .HasColumnName("CT_Ville");
            entity.Property(e => e.DeNo).HasColumnName("DE_No");
            entity.Property(e => e.EbNo).HasColumnName("EB_No");
            entity.Property(e => e.MrNo).HasColumnName("MR_No");
            entity.Property(e => e.NAnalytique).HasColumnName("N_Analytique");
            entity.Property(e => e.NAnalytiqueIfrs).HasColumnName("N_AnalytiqueIFRS");
            entity.Property(e => e.NCatCompta).HasColumnName("N_CatCompta");
            entity.Property(e => e.NCatTarif).HasColumnName("N_CatTarif");
            entity.Property(e => e.NCondition).HasColumnName("N_Condition");
            entity.Property(e => e.NDevise).HasColumnName("N_Devise");
            entity.Property(e => e.NExpedition).HasColumnName("N_Expedition");
            entity.Property(e => e.NPeriod).HasColumnName("N_Period");
            entity.Property(e => e.NRisque).HasColumnName("N_Risque");
            entity.Property(e => e.PiNoEchange).HasColumnName("PI_NoEchange");
            entity.Property(e => e.RValeur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("R_Valeur");
        });

        modelBuilder.Entity<DCreglement>(entity =>
        {
            entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_S_CREGLEMENT");

            entity.ToTable("D_CREGLEMENT");

            entity.HasIndex(e => e.RgNo, "UK_RG_No").IsUnique();

            entity.Property(e => e.CbMarq).HasColumnName("cbMarq");
            entity.Property(e => e.CaCaissier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CA_Caissier");
            entity.Property(e => e.CaNo).HasColumnName("CA_No");
            entity.Property(e => e.CaNumCaisse)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CA_NumCaisse");
            entity.Property(e => e.CarCode).HasColumnName("CAR_Code");
            entity.Property(e => e.CbCreateur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cbCreateur");
            entity.Property(e => e.CbModification)
                .HasColumnType("smalldatetime")
                .HasColumnName("cbModification");
            entity.Property(e => e.CgNum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CG_Num");
            entity.Property(e => e.CgNumCont)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CG_NumCont");
            entity.Property(e => e.CgNumEcart)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CG_NumEcart");
            entity.Property(e => e.ChNumSerie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CH_NumSerie");
            entity.Property(e => e.CoNoCaissier).HasColumnName("CO_NoCaissier");
            entity.Property(e => e.CtNumPayeur)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_NumPayeur");
            entity.Property(e => e.CtNumPayeurOrig)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CT_NumPayeurOrig");
            entity.Property(e => e.DlNumRetenue).HasColumnName("DL_NumRetenue");
            entity.Property(e => e.DoPiece)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_Piece");
            entity.Property(e => e.DoType).HasColumnName("DO_Type");
            entity.Property(e => e.EcNo).HasColumnName("EC_No");
            entity.Property(e => e.JoNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JO_Num");
            entity.Property(e => e.JoNumEcart)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("JO_NumEcart");
            entity.Property(e => e.NDevise).HasColumnName("N_Devise");
            entity.Property(e => e.NReglement).HasColumnName("N_Reglement");
            entity.Property(e => e.RgAttachementRtn)
                .HasColumnType("image")
                .HasColumnName("RG_AttachementRtn");
            entity.Property(e => e.RgBanque).HasColumnName("RG_Banque");
            entity.Property(e => e.RgCin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_CIN");
            entity.Property(e => e.RgCloture).HasColumnName("RG_Cloture");
            entity.Property(e => e.RgCommentaire)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RG_Commentaire");
            entity.Property(e => e.RgCompta).HasColumnName("RG_Compta");
            entity.Property(e => e.RgCompteBq)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_CompteBQ");
            entity.Property(e => e.RgCours)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("RG_Cours");
            entity.Property(e => e.RgDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("RG_Date");
            entity.Property(e => e.RgDateEchCont)
                .HasColumnType("smalldatetime")
                .HasColumnName("RG_DateEchCont");
            entity.Property(e => e.RgDateEscompte)
                .HasColumnType("smalldatetime")
                .HasColumnName("RG_DateEscompte");
            entity.Property(e => e.RgDoc).HasColumnName("RG_Doc");
            entity.Property(e => e.RgEtatR).HasColumnName("RG_EtatR");
            entity.Property(e => e.RgHeure)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RG_Heure");
            entity.Property(e => e.RgImpaye)
                .HasColumnType("smalldatetime")
                .HasColumnName("RG_Impaye");
            entity.Property(e => e.RgImpute).HasColumnName("RG_Impute");
            entity.Property(e => e.RgLibelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_Libelle");
            entity.Property(e => e.RgModeRtn).HasColumnName("RG_ModeRtn");
            entity.Property(e => e.RgMontant)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("RG_Montant");
            entity.Property(e => e.RgMontantDev)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("RG_MontantDev");
            entity.Property(e => e.RgMontantEcart)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("RG_MontantEcart");
            entity.Property(e => e.RgNo).HasColumnName("RG_No");
            entity.Property(e => e.RgNoBonAchat).HasColumnName("RG_NoBonAchat");
            entity.Property(e => e.RgNoCaution).HasColumnName("RG_NoCaution");
            entity.Property(e => e.RgNoRtn).HasColumnName("RG_NoRtn");
            entity.Property(e => e.RgPiece)
                .HasMaxLength(50)
                .HasColumnName("RG_Piece");
            entity.Property(e => e.RgPieceCloturer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_PieceCloturer");
            entity.Property(e => e.RgPieceRemplacer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_PieceRemplacer");
            entity.Property(e => e.RgPieceTransferer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_PieceTransferer");
            entity.Property(e => e.RgPourcentRtn)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("RG_PourcentRtn");
            entity.Property(e => e.RgReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_Reference");
            entity.Property(e => e.RgSouche)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RG_Souche");
            entity.Property(e => e.RgTicket).HasColumnName("RG_Ticket");
            entity.Property(e => e.RgTransfere).HasColumnName("RG_Transfere");
            entity.Property(e => e.RgType).HasColumnName("RG_Type");
            entity.Property(e => e.RgTypeMode).HasColumnName("RG_TypeMode");
            entity.Property(e => e.RgTypeReg).HasColumnName("RG_TypeReg");
            entity.Property(e => e.RgValorise).HasColumnName("RG_Valorise");
            entity.Property(e => e.TrNumSerie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TR_NumSerie");
        });

        modelBuilder.Entity<DDocentete>(entity =>
        {
            entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_F_DOCENTETE");

            entity.ToTable("D_DOCENTETE");

            entity.Property(e => e.CbMarq).HasColumnName("cbMarq");
            entity.Property(e => e.Bfprod)
                .HasMaxLength(50)
                .HasColumnName("BFPROD");
            entity.Property(e => e.BqNo)
                .HasDefaultValueSql("((0))")
                .HasColumnName("BQ_No");
            entity.Property(e => e.BtCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BT_Code");
            entity.Property(e => e.CbCreateur)
                .HasMaxLength(50)
                .HasDefaultValueSql("('CSQL')")
                .HasColumnName("cbCreateur");
            entity.Property(e => e.CbModification)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("cbModification");
            entity.Property(e => e.CcCode)
                .HasMaxLength(50)
                .HasColumnName("CC_Code");
            entity.Property(e => e.Central)
                .HasMaxLength(50)
                .HasColumnName("CENTRAL");
            entity.Property(e => e.Centraliste)
                .HasMaxLength(50)
                .HasColumnName("CENTRALISTE");
            entity.Property(e => e.CgNum)
                .HasMaxLength(50)
                .HasColumnName("CG_Num");
            entity.Property(e => e.DProjet)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')")
                .HasColumnName("D_Projet");
            entity.Property(e => e.DeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DE_Code");
            entity.Property(e => e.DeCodeDest)
                .HasMaxLength(50)
                .HasColumnName("DE_CodeDest");
            entity.Property(e => e.DlAutreFrais)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_AutreFrais");
            entity.Property(e => e.DlCoutArticle)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_CoutArticle");
            entity.Property(e => e.DlFraisTransport)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_FraisTransport");
            entity.Property(e => e.DmCode)
                .HasMaxLength(50)
                .HasColumnName("DM_Code");
            entity.Property(e => e.DoArchive)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_ARCHIVE");
            entity.Property(e => e.DoBcpt)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_BCPT");
            entity.Property(e => e.DoCatCompta)
                .HasMaxLength(50)
                .HasColumnName("DO_CatCompta");
            entity.Property(e => e.DoCloture)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_Cloture");
            entity.Property(e => e.DoCoffre)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_Coffre");
            entity.Property(e => e.DoCommentaires).HasColumnName("DO_Commentaires");
            entity.Property(e => e.DoCondLiv)
                .HasMaxLength(50)
                .HasColumnName("DO_CondLiv");
            entity.Property(e => e.DoCoord01)
                .HasMaxLength(100)
                .HasColumnName("DO_Coord01");
            entity.Property(e => e.DoCoord02)
                .HasMaxLength(100)
                .HasColumnName("DO_Coord02");
            entity.Property(e => e.DoCours)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_Cours");
            entity.Property(e => e.DoDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_Date");
            entity.Property(e => e.DoDateBc)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateBC");
            entity.Property(e => e.DoDateBl)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateBL");
            entity.Property(e => e.DoDateDv)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateDV");
            entity.Property(e => e.DoDateExonoration)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateExonoration");
            entity.Property(e => e.DoDateFa)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateFA");
            entity.Property(e => e.DoDateLivPrev)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateLivPrev");
            entity.Property(e => e.DoDateLivr)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateLivr");
            entity.Property(e => e.DoDateLivrRealisee)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateLivrRealisee");
            entity.Property(e => e.DoDevise).HasColumnName("DO_Devise");
            entity.Property(e => e.DoDiffIndex)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_DiffIndex");
            entity.Property(e => e.DoDomaine).HasColumnName("DO_Domaine");
            entity.Property(e => e.DoEcart)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_Ecart");
            entity.Property(e => e.DoEcartDevise)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_EcartDevise");
            entity.Property(e => e.DoEscompte)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_Escompte");
            entity.Property(e => e.DoEtatPay).HasColumnName("DO_EtatPay");
            entity.Property(e => e.DoExonoration)
                .HasMaxLength(50)
                .HasColumnName("DO_Exonoration");
            entity.Property(e => e.DoIndDeb)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_IndDeb");
            entity.Property(e => e.DoIndFin)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_IndFin");
            entity.Property(e => e.DoLieuLiv).HasColumnName("DO_LieuLiv");
            entity.Property(e => e.DoModExpo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_ModExpo");
            entity.Property(e => e.DoMontantRest)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_MontantRest");
            entity.Property(e => e.DoNature).HasColumnName("DO_Nature");
            entity.Property(e => e.DoNbreColis)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("DO_NbreColis");
            entity.Property(e => e.DoNumBl)
                .HasMaxLength(50)
                .HasColumnName("DO_NumBL");
            entity.Property(e => e.DoNumFa)
                .HasMaxLength(50)
                .HasColumnName("DO_NumFA");
            entity.Property(e => e.DoPerte)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_Perte");
            entity.Property(e => e.DoPiece)
                .HasMaxLength(50)
                .HasColumnName("DO_Piece");
            entity.Property(e => e.DoPieceBav)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceBAV");
            entity.Property(e => e.DoPieceBc)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceBC");
            entity.Property(e => e.DoPieceBl)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceBL");
            entity.Property(e => e.DoPieceBret)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceBRet");
            entity.Property(e => e.DoPieceDa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_PieceDA");
            entity.Property(e => e.DoPieceDv)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceDV");
            entity.Property(e => e.DoPieceFa)
                .HasMaxLength(50)
                .HasColumnName("DO_PieceFA");
            entity.Property(e => e.DoPieceOp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_PieceOP");
            entity.Property(e => e.DoPoidsBrut)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_PoidsBrut");
            entity.Property(e => e.DoPoidsNet)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_PoidsNet");
            entity.Property(e => e.DoPrint)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_Print");
            entity.Property(e => e.DoProvenance)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_Provenance");
            entity.Property(e => e.DoRecouvreur)
                .HasMaxLength(50)
                .HasColumnName("DO_Recouvreur");
            entity.Property(e => e.DoRemise)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_Remise");
            entity.Property(e => e.DoRepresentant)
                .HasMaxLength(50)
                .HasColumnName("DO_Representant");
            entity.Property(e => e.DoSommeQte)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_SommeQte");
            entity.Property(e => e.DoSouche)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'N° Pièce')")
                .HasColumnName("DO_Souche");
            entity.Property(e => e.DoSt)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_ST");
            entity.Property(e => e.DoStatut)
                .HasMaxLength(50)
                .HasColumnName("DO_Statut");
            entity.Property(e => e.DoTauxEscompte)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TauxEscompte");
            entity.Property(e => e.DoTauxEscompteDevise)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TauxEscompteDevise");
            entity.Property(e => e.DoTiers)
                .HasMaxLength(50)
                .HasColumnName("DO_Tiers");
            entity.Property(e => e.DoTotalHt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TotalHT");
            entity.Property(e => e.DoTotalHtdev)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TotalHTDev");
            entity.Property(e => e.DoTotalNetHt)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TotalNetHT");
            entity.Property(e => e.DoTotalNetHtdev)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TotalNetHTDev");
            entity.Property(e => e.DoTotalTtc)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DO_TotalTTC");
            entity.Property(e => e.DoType).HasColumnName("DO_Type");
            entity.Property(e => e.DoTypeColis)
                .HasMaxLength(50)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_TypeColis");
            entity.Property(e => e.DoTypeRemise).HasColumnName("DO_TypeRemise");
            entity.Property(e => e.DoValide)
                .HasDefaultValueSql("((1))")
                .HasColumnName("DO_Valide");
            entity.Property(e => e.DoValiditeExonoration)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_ValiditeExonoration");
            entity.Property(e => e.DoValorisation)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DO_Valorisation");
            entity.Property(e => e.DoValorisationDevise).HasColumnName("DO_ValorisationDevise");
            entity.Property(e => e.EbNo)
                .HasDefaultValueSql("((0))")
                .HasColumnName("EB_No");
            entity.Property(e => e.EcNo).HasColumnName("EC_No");
            entity.Property(e => e.EmCode)
                .HasMaxLength(50)
                .HasColumnName("EM_Code");
            entity.Property(e => e.EmCodeDemandeur)
                .HasMaxLength(50)
                .HasColumnName("EM_CodeDemandeur");
            entity.Property(e => e.EmCodeDemarcheur)
                .HasMaxLength(50)
                .HasColumnName("EM_CodeDemarcheur");
            entity.Property(e => e.EmCodeRespProd)
                .HasMaxLength(50)
                .HasComment("Code Reponsable PROD(CENTRALISTE)")
                .HasColumnName("EM_CodeRespPROD");
            entity.Property(e => e.EmCodeTransProd)
                .HasMaxLength(50)
                .HasComment("Code POMPISTE")
                .HasColumnName("EM_CodeTransPROD");
            entity.Property(e => e.EmCodeTransporteur)
                .HasMaxLength(50)
                .HasColumnName("EM_CodeTransporteur");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMP_Code");
            entity.Property(e => e.EnteteC1)
                .HasMaxLength(50)
                .HasColumnName("Entete_C1");
            entity.Property(e => e.EnteteC10)
                .HasColumnType("smalldatetime")
                .HasColumnName("Entete_C10");
            entity.Property(e => e.EnteteC11)
                .HasMaxLength(50)
                .HasColumnName("Entete_C11");
            entity.Property(e => e.EnteteC12)
                .HasMaxLength(50)
                .HasColumnName("Entete_C12");
            entity.Property(e => e.EnteteC13)
                .HasMaxLength(50)
                .HasColumnName("Entete_C13");
            entity.Property(e => e.EnteteC14)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Entete_C14");
            entity.Property(e => e.EnteteC15)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Entete_C15");
            entity.Property(e => e.EnteteC16).HasColumnName("Entete_C16");
            entity.Property(e => e.EnteteC17).HasColumnName("Entete_C17");
            entity.Property(e => e.EnteteC18)
                .HasColumnType("smalldatetime")
                .HasColumnName("Entete_C18");
            entity.Property(e => e.EnteteC19)
                .HasColumnType("smalldatetime")
                .HasColumnName("Entete_C19");
            entity.Property(e => e.EnteteC2)
                .HasMaxLength(50)
                .HasColumnName("Entete_C2");
            entity.Property(e => e.EnteteC20)
                .HasColumnType("smalldatetime")
                .HasColumnName("Entete_C20");
            entity.Property(e => e.EnteteC3)
                .HasMaxLength(50)
                .HasColumnName("Entete_C3");
            entity.Property(e => e.EnteteC4)
                .HasMaxLength(50)
                .HasColumnName("Entete_C4");
            entity.Property(e => e.EnteteC5)
                .HasMaxLength(50)
                .HasColumnName("Entete_C5");
            entity.Property(e => e.EnteteC6)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Entete_C6");
            entity.Property(e => e.EnteteC7)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Entete_C7");
            entity.Property(e => e.EnteteC8).HasColumnName("Entete_C8");
            entity.Property(e => e.EnteteC9).HasColumnName("Entete_C9");
            entity.Property(e => e.GrCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'Maintenance')")
                .HasColumnName("GR_Code");
            entity.Property(e => e.Heure)
                .HasMaxLength(50)
                .HasColumnName("HEURE");
            entity.Property(e => e.LivraisonSemaine)
                .HasMaxLength(50)
                .HasColumnName("LIVRAISON (Semaine)");
            entity.Property(e => e.MeNo).HasColumnName("ME_No");
            entity.Property(e => e.MrNo).HasColumnName("MR_No");
            entity.Property(e => e.NCatCompta)
                .HasDefaultValueSql("((0))")
                .HasColumnName("N_CatCompta");
            entity.Property(e => e.Pompe)
                .HasMaxLength(50)
                .HasDefaultValueSql("('POMPISTE')")
                .HasColumnName("POMPE");
            entity.Property(e => e.Pompiste)
                .HasMaxLength(50)
                .HasColumnName("POMPISTE");
            entity.Property(e => e.Prodqtebl)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("PRODQTEBL");
            entity.Property(e => e.RpCode)
                .HasMaxLength(50)
                .HasColumnName("RP_Code");
            entity.Property(e => e.RpCodeTransProd)
                .HasMaxLength(50)
                .HasComment("Code POMPE ")
                .HasColumnName("RP_CodeTransPROD");
            entity.Property(e => e.RpCodeUniteProd)
                .HasMaxLength(50)
                .HasComment("Code Unité PROD (CENTRAL)")
                .HasColumnName("RP_CodeUnitePROD");
            entity.Property(e => e.Silos)
                .HasMaxLength(50)
                .HasColumnName("SILOS");
        });

        modelBuilder.Entity<DDocligne>(entity =>
        {
            entity.HasKey(e => e.CbMarq).HasName("PK_CBMARQ_D_DOCLIGNE");

            entity.ToTable("D_DOCLIGNE");

            entity.Property(e => e.CbMarq).HasColumnName("cbMarq");
            entity.Property(e => e.ARecevoir)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("A RECEVOIR");
            entity.Property(e => e.AeCommentaire)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("AE_Commentaire");
            entity.Property(e => e.AfRefFourniss)
                .HasMaxLength(50)
                .HasColumnName("AF_RefFourniss");
            entity.Property(e => e.AgCodeBarre)
                .HasMaxLength(50)
                .HasColumnName("AG_CodeBarre");
            entity.Property(e => e.AgRef)
                .HasMaxLength(50)
                .HasColumnName("AG_Ref");
            entity.Property(e => e.ArRef)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AR_Ref");
            entity.Property(e => e.ArRefComp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AR_RefComp");
            entity.Property(e => e.BtCode)
                .HasMaxLength(50)
                .HasColumnName("BT_Code");
            entity.Property(e => e.CaNum)
                .HasMaxLength(50)
                .HasColumnName("CA_Num");
            entity.Property(e => e.CbCreateur)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'CSQL')")
                .HasColumnName("cbCreateur");
            entity.Property(e => e.CbMarqArt).HasColumnName("cbMarqArt");
            entity.Property(e => e.CbMarqArtComp).HasColumnName("cbMarqArtComp");
            entity.Property(e => e.CbMarqCr).HasColumnName("cbMarqCR");
            entity.Property(e => e.CbModification)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("cbModification");
            entity.Property(e => e.CcCode)
                .HasMaxLength(50)
                .HasColumnName("CC_Code");
            entity.Property(e => e.CgNum)
                .HasMaxLength(50)
                .HasColumnName("CG_Num");
            entity.Property(e => e.CoBa)
                .HasMaxLength(50)
                .HasColumnName("CO_BA");
            entity.Property(e => e.CoBc)
                .HasMaxLength(50)
                .HasColumnName("CO_BC");
            entity.Property(e => e.CoBl)
                .HasMaxLength(50)
                .HasColumnName("CO_BL");
            entity.Property(e => e.CoBp)
                .HasMaxLength(50)
                .HasColumnName("CO_BP");
            entity.Property(e => e.CoBr)
                .HasMaxLength(50)
                .HasColumnName("CO_BR");
            entity.Property(e => e.CoDv)
                .HasMaxLength(50)
                .HasColumnName("CO_DV");
            entity.Property(e => e.CoFa)
                .HasMaxLength(50)
                .HasColumnName("CO_FA");
            entity.Property(e => e.CoFaa)
                .HasMaxLength(50)
                .HasColumnName("CO_FAA");
            entity.Property(e => e.CoFar)
                .HasMaxLength(50)
                .HasColumnName("CO_FAR");
            entity.Property(e => e.CoFc)
                .HasMaxLength(50)
                .HasColumnName("CO_FC");
            entity.Property(e => e.CtNum)
                .HasMaxLength(50)
                .HasColumnName("CT_Num");
            entity.Property(e => e.DProjet)
                .HasMaxLength(50)
                .HasColumnName("D_Projet");
            entity.Property(e => e.DateVisitTech).HasColumnType("datetime");
            entity.Property(e => e.DeCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DE_Code");
            entity.Property(e => e.DeCodeDest)
                .HasMaxLength(50)
                .HasColumnName("DE_CodeDest");
            entity.Property(e => e.DlCbMarqBav).HasColumnName("DL_cbMarqBAV");
            entity.Property(e => e.DlCbMarqBc).HasColumnName("DL_cbMarqBC");
            entity.Property(e => e.DlCbMarqBl).HasColumnName("DL_cbMarqBL");
            entity.Property(e => e.DlCbMarqBp).HasColumnName("DL_cbMarqBP");
            entity.Property(e => e.DlCbMarqBret).HasColumnName("DL_cbMarqBRet");
            entity.Property(e => e.DlCbMarqDa).HasColumnName("DL_cbMarqDA");
            entity.Property(e => e.DlCbMarqDv).HasColumnName("DL_cbMarqDV");
            entity.Property(e => e.DlCbMarqFa).HasColumnName("DL_cbMarqFA");
            entity.Property(e => e.DlCbMarqFaa).HasColumnName("DL_cbMarqFAA");
            entity.Property(e => e.DlCbMarqFar).HasColumnName("DL_cbMarqFAR");
            entity.Property(e => e.DlCbMarqOp).HasColumnName("DL_cbMarqOP");
            entity.Property(e => e.DlCmup)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_CMUP");
            entity.Property(e => e.DlCodeFormule)
                .HasMaxLength(50)
                .HasColumnName("DL_CodeFormule");
            entity.Property(e => e.DlCodeTaxe1)
                .HasMaxLength(25)
                .HasColumnName("DL_CodeTaxe1");
            entity.Property(e => e.DlCodeTaxe2)
                .HasMaxLength(25)
                .HasColumnName("DL_CodeTaxe2");
            entity.Property(e => e.DlCodeTaxe3)
                .HasMaxLength(25)
                .HasColumnName("DL_CodeTaxe3");
            entity.Property(e => e.DlDatePieceBav)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceBAV");
            entity.Property(e => e.DlDatePieceBc)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceBC");
            entity.Property(e => e.DlDatePieceBl)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceBL");
            entity.Property(e => e.DlDatePieceBp)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceBP");
            entity.Property(e => e.DlDatePieceBret)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceBRet");
            entity.Property(e => e.DlDatePieceCr)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceCR");
            entity.Property(e => e.DlDatePieceDa)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceDA");
            entity.Property(e => e.DlDatePieceDv)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceDV");
            entity.Property(e => e.DlDatePieceFa)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceFA");
            entity.Property(e => e.DlDatePieceFaa)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceFAA");
            entity.Property(e => e.DlDatePieceFar)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceFAR");
            entity.Property(e => e.DlDatePieceOp)
                .HasColumnType("smalldatetime")
                .HasColumnName("DL_DatePieceOP");
            entity.Property(e => e.DlDescription).HasColumnName("DL_Description");
            entity.Property(e => e.DlDesign).HasColumnName("DL_Design");
            entity.Property(e => e.DlDesignGamme)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DL_DesignGamme");
            entity.Property(e => e.DlEscompte).HasColumnName("DL_Escompte");
            entity.Property(e => e.DlHauteur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Hauteur");
            entity.Property(e => e.DlKiloAct)
                .HasColumnType("numeric(26, 4)")
                .HasColumnName("DL_KiloAct");
            entity.Property(e => e.DlKilometrage)
                .HasColumnType("numeric(26, 4)")
                .HasColumnName("DL_Kilometrage");
            entity.Property(e => e.DlLargeur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Largeur");
            entity.Property(e => e.DlLigne).HasColumnName("DL_Ligne");
            entity.Property(e => e.DlLongueur)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Longueur");
            entity.Property(e => e.DlMontantHt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_MontantHT");
            entity.Property(e => e.DlMontantHtnet)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_MontantHTNet");
            entity.Property(e => e.DlMontantTtc)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_MontantTTC");
            entity.Property(e => e.DlMvtStock).HasColumnName("DL_MvtStock");
            entity.Property(e => e.DlNatureFormule)
                .HasMaxLength(50)
                .HasColumnName("DL_NatureFormule");
            entity.Property(e => e.DlNbreColis)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_NbreColis");
            entity.Property(e => e.DlNo).HasColumnName("DL_No");
            entity.Property(e => e.DlNombreArt)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_NombreArt");
            entity.Property(e => e.DlPieceBav)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceBAV");
            entity.Property(e => e.DlPieceBc)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceBC");
            entity.Property(e => e.DlPieceBl)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceBL");
            entity.Property(e => e.DlPieceBp)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceBP");
            entity.Property(e => e.DlPieceBret)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceBRet");
            entity.Property(e => e.DlPieceCr)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceCR");
            entity.Property(e => e.DlPieceDa)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceDA");
            entity.Property(e => e.DlPieceDv)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceDV");
            entity.Property(e => e.DlPieceFa)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceFA");
            entity.Property(e => e.DlPieceFaa)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceFAA");
            entity.Property(e => e.DlPieceFar)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceFAR");
            entity.Property(e => e.DlPieceOp)
                .HasMaxLength(50)
                .HasColumnName("DL_PieceOP");
            entity.Property(e => e.DlPoidBrut)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PoidBrut");
            entity.Property(e => e.DlPoidNet)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PoidNet");
            entity.Property(e => e.DlPrixUnitaire)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PrixUnitaire");
            entity.Property(e => e.DlPrixUnitaireDev)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PrixUnitaireDev");
            entity.Property(e => e.DlPunetHt)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PUNetHT");
            entity.Property(e => e.DlPunetHtdev)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PUNetHTDev");
            entity.Property(e => e.DlPuttc)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_PUTTC");
            entity.Property(e => e.DlQte)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte");
            entity.Property(e => e.DlQteBav)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_BAV");
            entity.Property(e => e.DlQteBc)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_BC");
            entity.Property(e => e.DlQteBl)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_BL");
            entity.Property(e => e.DlQteBp)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_BP");
            entity.Property(e => e.DlQteBret)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_BRet");
            entity.Property(e => e.DlQteCr)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_CR");
            entity.Property(e => e.DlQteDa)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_DA");
            entity.Property(e => e.DlQteDepot)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteDepot");
            entity.Property(e => e.DlQteDv)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_DV");
            entity.Property(e => e.DlQteFa)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_FA");
            entity.Property(e => e.DlQteFaa)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_FAA");
            entity.Property(e => e.DlQteFacture)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteFacture");
            entity.Property(e => e.DlQteFar)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_FAR");
            entity.Property(e => e.DlQteOp)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Qte_OP");
            entity.Property(e => e.DlQteParColis)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteParColis");
            entity.Property(e => e.DlQteProd)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteProd");
            entity.Property(e => e.DlQteRes)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteRes");
            entity.Property(e => e.DlQteSto)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_QteSto");
            entity.Property(e => e.DlRefOrig)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DL_RefOrig");
            entity.Property(e => e.DlRemise)
                .HasDefaultValueSql("((0))")
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Remise");
            entity.Property(e => e.DlRemise2)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Remise_2");
            entity.Property(e => e.DlRemise3)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Remise_3");
            entity.Property(e => e.DlSolde).HasColumnName("DL_Solde");
            entity.Property(e => e.DlTaxe1)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Taxe1");
            entity.Property(e => e.DlTaxe2)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Taxe2");
            entity.Property(e => e.DlTaxe3)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Taxe3");
            entity.Property(e => e.DlTnomencl).HasColumnName("DL_TNomencl");
            entity.Property(e => e.DlTtc).HasColumnName("DL_TTC");
            entity.Property(e => e.DlTypeColis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("DL_TypeColis");
            entity.Property(e => e.DlUnite)
                .HasMaxLength(50)
                .HasColumnName("DL_Unite");
            entity.Property(e => e.DlUtilisation)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_Utilisation");
            entity.Property(e => e.DlUtilisationAct)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("DL_UtilisationAct");
            entity.Property(e => e.DlValorise).HasColumnName("DL_Valorise");
            entity.Property(e => e.DlVentilation)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DL_Ventilation");
            entity.Property(e => e.DlZone)
                .HasMaxLength(50)
                .HasColumnName("DL_Zone");
            entity.Property(e => e.DmCode)
                .HasMaxLength(50)
                .HasColumnName("DM_Code");
            entity.Property(e => e.DoAvenant).HasColumnName("DO_Avenant");
            entity.Property(e => e.DoDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_Date");
            entity.Property(e => e.DoDateBl)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateBL");
            entity.Property(e => e.DoDateFa)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateFA");
            entity.Property(e => e.DoDateLivr)
                .HasColumnType("smalldatetime")
                .HasColumnName("DO_DateLivr");
            entity.Property(e => e.DoDomaine).HasColumnName("DO_Domaine");
            entity.Property(e => e.DoModExpo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_ModExpo");
            entity.Property(e => e.DoNumBl)
                .HasMaxLength(50)
                .HasColumnName("DO_NumBL");
            entity.Property(e => e.DoNumFa)
                .HasMaxLength(50)
                .HasColumnName("DO_NumFA");
            entity.Property(e => e.DoPiece)
                .HasMaxLength(50)
                .HasColumnName("DO_Piece");
            entity.Property(e => e.DoRecouvreur)
                .HasMaxLength(50)
                .HasColumnName("DO_Recouvreur");
            entity.Property(e => e.DoRepresentant)
                .HasMaxLength(50)
                .HasColumnName("DO_Representant");
            entity.Property(e => e.DoSouche)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DO_Souche");
            entity.Property(e => e.DoType).HasColumnName("DO_Type");
            entity.Property(e => e.EgEnumere1)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasColumnName("EG_Enumere1");
            entity.Property(e => e.EgEnumere2)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')")
                .HasColumnName("EG_Enumere2");
            entity.Property(e => e.EmCode)
                .HasMaxLength(50)
                .HasColumnName("EM_Code");
            entity.Property(e => e.EmCodeRespProd)
                .HasMaxLength(50)
                .HasComment("Code Reponsable PROD(CENTRALISTE)")
                .HasColumnName("EM_CodeRespPROD");
            entity.Property(e => e.EmCodeTransProd)
                .HasMaxLength(50)
                .HasComment("Code POMPISTE")
                .HasColumnName("EM_CodeTransPROD");
            entity.Property(e => e.EmCodeTransporteur)
                .HasMaxLength(50)
                .HasColumnName("EM_CodeTransporteur");
            entity.Property(e => e.Gamme1)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Gamme2)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Heure)
                .HasMaxLength(50)
                .HasColumnName("HEURE");
            entity.Property(e => e.LigneC1)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C1");
            entity.Property(e => e.LigneC10)
                .HasColumnType("smalldatetime")
                .HasColumnName("Ligne_C10");
            entity.Property(e => e.LigneC11)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C11");
            entity.Property(e => e.LigneC12)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C12");
            entity.Property(e => e.LigneC13)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C13");
            entity.Property(e => e.LigneC14)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Ligne_C14");
            entity.Property(e => e.LigneC15)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Ligne_C15");
            entity.Property(e => e.LigneC16).HasColumnName("Ligne_C16");
            entity.Property(e => e.LigneC17).HasColumnName("Ligne_C17");
            entity.Property(e => e.LigneC18)
                .HasColumnType("smalldatetime")
                .HasColumnName("Ligne_C18");
            entity.Property(e => e.LigneC19)
                .HasColumnType("smalldatetime")
                .HasColumnName("Ligne_C19");
            entity.Property(e => e.LigneC2)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C2");
            entity.Property(e => e.LigneC20)
                .HasColumnType("smalldatetime")
                .HasColumnName("Ligne_C20");
            entity.Property(e => e.LigneC3)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C3");
            entity.Property(e => e.LigneC4)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C4");
            entity.Property(e => e.LigneC5)
                .HasMaxLength(50)
                .HasColumnName("Ligne_C5");
            entity.Property(e => e.LigneC6)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Ligne_C6");
            entity.Property(e => e.LigneC7)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("Ligne_C7");
            entity.Property(e => e.LigneC8).HasColumnName("Ligne_C8");
            entity.Property(e => e.LigneC9).HasColumnName("Ligne_C9");
            entity.Property(e => e.LsNoSerie)
                .HasMaxLength(50)
                .HasColumnName("LS_NoSerie");
            entity.Property(e => e.NumeroFicheTech).HasMaxLength(50);
            entity.Property(e => e.PaiementCompl)
                .HasMaxLength(50)
                .HasColumnName("PAIEMENT COMPL");
            entity.Property(e => e.Pompe)
                .HasMaxLength(50)
                .HasColumnName("POMPE");
            entity.Property(e => e.Pompiste)
                .HasMaxLength(50)
                .HasColumnName("POMPISTE");
            entity.Property(e => e.Prodqtebl)
                .HasColumnType("numeric(24, 6)")
                .HasColumnName("PRODQTEBL");
            entity.Property(e => e.RpCode)
                .HasMaxLength(50)
                .HasColumnName("RP_Code");
            entity.Property(e => e.RpCodeTransProd)
                .HasMaxLength(50)
                .HasComment("Code POMPE ")
                .HasColumnName("RP_CodeTransPROD");
            entity.Property(e => e.RpCodeUniteProd)
                .HasMaxLength(50)
                .HasComment("Code Unité PROD (CENTRAL)")
                .HasColumnName("RP_CodeUnitePROD");
            entity.Property(e => e.Silos)
                .HasMaxLength(50)
                .HasColumnName("SILOS");
        });

        modelBuilder.Entity<DEmployeur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_D_CHAUFFEUR");

            entity.ToTable("D_Employeur");

            entity.Property(e => e.EmCode)
                .HasMaxLength(50)
                .HasColumnName("EM_Code");
            entity.Property(e => e.EmEtat).HasColumnName("EM_Etat");
            entity.Property(e => e.EmFonction)
                .HasMaxLength(50)
                .HasColumnName("EM_Fonction");
            entity.Property(e => e.EmNom)
                .HasMaxLength(50)
                .HasColumnName("EM_Nom");
            entity.Property(e => e.EmPrenom)
                .HasMaxLength(50)
                .HasColumnName("EM_Prenom");
        });

        modelBuilder.Entity<DRessource>(entity =>
        {
            entity.ToTable("D_Ressource");

            entity.Property(e => e.RpCode)
                .HasMaxLength(50)
                .HasColumnName("RP_Code");
            entity.Property(e => e.RpEtat).HasColumnName("RP_Etat");
            entity.Property(e => e.RpImmatriculation)
                .HasMaxLength(50)
                .HasColumnName("RP_Immatriculation");
            entity.Property(e => e.RpIntitule)
                .HasMaxLength(50)
                .HasColumnName("RP_Intitule");
        });

        modelBuilder.Entity<DRessourcePanneArrêt>(entity =>
        {
            entity.ToTable("D_Ressource_Panne_Arrêts");

            entity.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .HasColumnName("Date_Debut");
            entity.Property(e => e.DateFin)
                .HasColumnType("datetime")
                .HasColumnName("Date_Fin");
            entity.Property(e => e.RpCode)
                .HasMaxLength(50)
                .HasColumnName("RP_Code");
            entity.Property(e => e.RpEtat).HasColumnName("RP_Etat");
        });

        modelBuilder.Entity<DRole>(entity =>
        {
            entity.HasKey(e => e.CodeRole).HasName("PK_Roles");

            entity.ToTable("D_Roles");

            entity.Property(e => e.CodeRole)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code_role");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NomRole)
                .HasMaxLength(100)
                .HasColumnName("nom_role");
        });

        modelBuilder.Entity<DUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__D_Users__3214EC0757D64BEC");

            entity.ToTable("D_Users");

            entity.HasIndex(e => e.UserId, "UQ_D_Users_UserId").IsUnique();

            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(7)
                .IsUnicode(false); 
            entity.Property(e => e.Etat)
                      .HasColumnName("Etat")
                      .HasColumnType("smallint");
       

    });

        modelBuilder.Entity<DUserRole>(entity =>
        {
            entity.ToTable("D_User_Roles");

            entity.HasIndex(e => new { e.UserId, e.CodeRole }, "UQ_User_Role").IsUnique();

            entity.Property(e => e.CodeRole)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code_role");
            entity.Property(e => e.UserId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
