using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SumeraTravelCorporation.Migrations
{
    public partial class adsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryRefId",
                schema: "Master",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CountryRefId",
                schema: "Master",
                table: "City",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryRefId",
                schema: "Master",
                table: "City",
                column: "CountryRefId",
                principalSchema: "Master",
                principalTable: "Country",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryRefId",
                schema: "Master",
                table: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CountryRefId",
                schema: "Master",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryRefId",
                schema: "Master",
                table: "City",
                column: "CountryRefId",
                principalSchema: "Master",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
