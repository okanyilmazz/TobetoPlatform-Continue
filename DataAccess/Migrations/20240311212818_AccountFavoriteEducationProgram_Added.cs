using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AccountFavoriteEducationProgram_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountFavoriteEducationPrograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountFavoriteEducationPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountFavoriteEducationPrograms_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountFavoriteEducationPrograms_EducationPrograms_EducationProgramId",
                        column: x => x.EducationProgramId,
                        principalTable: "EducationPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountFavoriteEducationPrograms_AccountId",
                table: "AccountFavoriteEducationPrograms",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountFavoriteEducationPrograms_EducationProgramId",
                table: "AccountFavoriteEducationPrograms",
                column: "EducationProgramId");

            migrationBuilder.CreateIndex(
                name: "UK_Id",
                table: "AccountFavoriteEducationPrograms",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountFavoriteEducationPrograms");
        }
    }
}
