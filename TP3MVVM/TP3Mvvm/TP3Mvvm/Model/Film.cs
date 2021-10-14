using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace tp3.Models.EntityFramework
{
    [Table("film")]
    public partial class Film
    {
        public Film()
        {
            FavorisFilm = new HashSet<Favoris>();
        }

        [Key]
        [Column("FLM_ID")]
        public int flm_id { get; set; }

        [Required]
        [Column("FLM_TITRE")]
        [StringLength(100)]
        public string Titre { get; set; }

        
        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsis { get; set; }

        [Required]
        [Column("FLM_DATEPARUTION", TypeName = "Date")]
        public DateTime DateParution { get; set; }

        [Required]
        [Column("FLM_DUREE")]
        public Decimal Duree { get; set; }

        [Required]
        [Column("FLM_GENRE")]
        [StringLength(30)]
        public string Genre { get; set; }

        
        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public string UrlPhoto { get; set; }


        
     
        [InverseProperty(nameof(Favoris.FilmFavori))]
        public virtual ICollection<Favoris> FavorisFilm { get; set; }
    }
}
