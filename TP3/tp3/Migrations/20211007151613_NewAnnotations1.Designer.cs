﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tp3.Models.EntityFramework;

namespace tp3.Migrations
{
    [DbContext(typeof(tp3Context))]
    [Migration("20211007151613_NewAnnotations1")]
    partial class NewAnnotations1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "French_France.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("tp3.Models.EntityFramework.Compte", b =>
                {
                    b.Property<int>("CompteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("CPT_ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)")
                        .HasColumnName("CPT_CP");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("DATE")
                        .HasColumnName("CPT_DATECREATION")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("CPT_LATITUDE");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("CPT_LONGITUDE");

                    b.Property<string>("Mel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("char(100)")
                        .HasColumnName("CPT_MEL");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CPT_NOM");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasDefaultValue("France")
                        .HasColumnName("CPT_PAYS");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CPT_PRENOM");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("CPT_PWD");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("CPT_RUE");

                    b.Property<string>("TelPortable")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("CPT_TELPORTABLE");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CPT_VILLE");

                    b.HasKey("CompteId");

                    b.HasIndex("Mel")
                        .IsUnique();

                    b.ToTable("compte");
                });

            modelBuilder.Entity("tp3.Models.EntityFramework.Favoris", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("FLM_ID");

                    b.Property<int>("CompteId")
                        .HasColumnType("integer")
                        .HasColumnName("CPT_ID");

                    b.Property<string>("Commentaire")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("FAV_COMMENTAIRE");

                    b.HasKey("FilmId", "CompteId")
                        .HasName("pk_favoris");

                    b.HasIndex("CompteId");

                    b.ToTable("favoris");
                });

            modelBuilder.Entity("tp3.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("flm_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("FLM_ID")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateParution")
                        .HasColumnType("Date")
                        .HasColumnName("FLM_DATEPARUTION");

                    b.Property<decimal>("Duree")
                        .HasColumnType("numeric")
                        .HasColumnName("FLM_DUREE");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("FLM_GENRE");

                    b.Property<string>("Synopsis")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("FLM_SYNOPSIS");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("FLM_TITRE");

                    b.Property<string>("UrlPhoto")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("FLM_URLPHOTO");

                    b.HasKey("flm_id");

                    b.ToTable("film");
                });

            modelBuilder.Entity("tp3.Models.EntityFramework.Favoris", b =>
                {
                    b.HasOne("tp3.Models.EntityFramework.Compte", "CompteFavori")
                        .WithMany("FavorisCompte")
                        .HasForeignKey("CompteId")
                        .HasConstraintName("fk_avis_utilisateur")
                        .IsRequired();

                    b.HasOne("tp3.Models.EntityFramework.Film", "FilmFavori")
                        .WithMany("FavorisFilm")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("fk_avis_film")
                        .IsRequired();

                    b.Navigation("CompteFavori");

                    b.Navigation("FilmFavori");
                });

            modelBuilder.Entity("tp3.Models.EntityFramework.Compte", b =>
                {
                    b.Navigation("FavorisCompte");
                });

            modelBuilder.Entity("tp3.Models.EntityFramework.Film", b =>
                {
                    b.Navigation("FavorisFilm");
                });
#pragma warning restore 612, 618
        }
    }
}
