using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tp3.Migrations
{
    public partial class CreationBDFilmRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compte",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPT_NOM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_PRENOM = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_TELPORTABLE = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    CPT_MEL = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    CPT_PWD = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CPT_RUE = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CPT_CP = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CPT_VILLE = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CPT_PAYS = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "France"),
                    CPT_LATITUDE = table.Column<float>(type: "real", nullable: true),
                    CPT_LONGITUDE = table.Column<float>(type: "real", nullable: true),
                    CPT_DATECREATION = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "CURRENT_DATE")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compte", x => x.CPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "film",
                columns: table => new
                {
                    FLM_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FLM_TITRE = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FLM_SYNOPSIS = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    FLM_DATEPARUTION = table.Column<DateTime>(type: "Date", nullable: false),
                    FLM_DUREE = table.Column<decimal>(type: "numeric", nullable: false),
                    FLM_GENRE = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FLM_URLPHOTO = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film", x => x.FLM_ID);
                });

            migrationBuilder.CreateTable(
                name: "favoris",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(type: "integer", nullable: false),
                    FLM_ID = table.Column<int>(type: "integer", nullable: false),
                    FAV_COMMENTAIRE = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_favoris", x => new { x.FLM_ID, x.CPT_ID });
                    table.ForeignKey(
                        name: "fk_avis_film",
                        column: x => x.FLM_ID,
                        principalTable: "film",
                        principalColumn: "FLM_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_avis_utilisateur",
                        column: x => x.CPT_ID,
                        principalTable: "compte",
                        principalColumn: "CPT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compte_CPT_MEL",
                table: "compte",
                column: "CPT_MEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_favoris_CPT_ID",
                table: "favoris",
                column: "CPT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favoris");

            migrationBuilder.DropTable(
                name: "film");

            migrationBuilder.DropTable(
                name: "compte");
        }
    }
}
