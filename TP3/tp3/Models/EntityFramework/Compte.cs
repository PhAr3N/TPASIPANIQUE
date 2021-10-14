using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace tp3.Models.EntityFramework
{
    [Table("compte")]
    public partial class Compte
    {
        public Compte()
        {
            FavorisCompte = new HashSet<Favoris>();
        }

        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Required]
        [Column("CPT_NOM")]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [Column("CPT_PRENOM")]
        [StringLength(50)]
        public string Prenom { get; set; }

        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Ton num est pas bon pélo")]
        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        [StringLength(10)]
        public string TelPortable { get; set; }

        [Required]
        [EmailAddress]
        [Column("CPT_MEL", TypeName ="char(5)")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string Mel { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Mot de pâsse trop izi")]
        [Column("CPT_PWD")]
        [StringLength(64)]
        public string Pwd { get; set; }

        [Required]
        [Column("CPT_RUE")]
        [StringLength(200)]
        public string Rue { get; set; }
        
        [Required]
        [Column("CPT_CP")]
        [StringLength(5)]
        public string CodePostal { get; set; }
        
        [Required]
        [Column("CPT_VILLE")]
        [StringLength(50)]
        public string Ville { get; set; }

        [Required]
        [Column("CPT_PAYS")]
        [StringLength(50)]
        public string Pays { get; set; }
        
        
        [Column("CPT_LATITUDE")]
        public float? Latitude { get; set; }

        [Column("CPT_LONGITUDE")]
        public float? Longitude { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("CPT_DATECREATION",TypeName = "DATE")]
        public DateTime DateCreation { get; set; }


        [InverseProperty(nameof(Favoris.CompteFavori))]
        public virtual ICollection<Favoris> FavorisCompte { get; set; }
    }
}
