using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tp3.Migrations
{
    public partial class NewAnnotations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FLM_URLPHOTO",
                table: "film",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FLM_SYNOPSIS",
                table: "film",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "CPT_TELPORTABLE",
                table: "compte",
                type: "char(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FLM_URLPHOTO",
                table: "film",
                type: "timestamp without time zone",
                maxLength: 200,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FLM_SYNOPSIS",
                table: "film",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPT_TELPORTABLE",
                table: "compte",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
