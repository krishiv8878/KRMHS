using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KHRMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelevantExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentSalary = table.Column<long>(type: "bigint", nullable: false),
                    ExpectedSalary = table.Column<long>(type: "bigint", nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
