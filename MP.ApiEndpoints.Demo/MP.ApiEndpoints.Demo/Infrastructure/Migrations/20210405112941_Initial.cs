using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MP.ApiEndpoints.Demo.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    Version = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("688a4bab-15a2-4159-bdf8-83cd551995ba"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Test Person 01", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("aadf65a8-d14d-4f87-b25a-cc0b7741db60"), new DateTime(1985, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Test Person 02", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Name", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("8befcb97-6cdf-4a40-9511-9197ba715379"), new DateTime(1990, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), null, null, "Test Person 02", new DateTime(2021, 3, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("95514eb0-50f1-4e13-a7c2-36c7b4984dd8"), 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");
        }
    }
}
