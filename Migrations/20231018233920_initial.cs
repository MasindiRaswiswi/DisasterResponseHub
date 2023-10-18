using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterResponseHub.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsDonated",
                columns: table => new
                {
                    GoodDonatedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDonated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    DonationCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDonated", x => x.GoodDonatedId);
                });

            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    DonorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DonorType = table.Column<int>(type: "int", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "bit", nullable: false),
                    GoodsDonatedGoodDonatedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.DonorID);
                    table.ForeignKey(
                        name: "FK_Donor_GoodsDonated_GoodsDonatedGoodDonatedId",
                        column: x => x.GoodsDonatedGoodDonatedId,
                        principalTable: "GoodsDonated",
                        principalColumn: "GoodDonatedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donor_GoodsDonatedGoodDonatedId",
                table: "Donor",
                column: "GoodsDonatedGoodDonatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "GoodsDonated");
        }
    }
}
