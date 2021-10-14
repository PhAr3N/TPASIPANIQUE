using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace tp3.Models.EntityFramework
{
    [Table("favoris")]
    public partial class Favoris
    {
        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }
        [Column("FAV_COMMENTAIRE")]
        [StringLength(500)]
        public string Commentaire { get; set; }
        
        [JsonIgnore]
        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FavorisFilm")]
        public virtual Film FilmFavori { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CompteId))]
        [InverseProperty("FavorisCompte")]
        public virtual Compte CompteFavori { get; set; }
    }
}
