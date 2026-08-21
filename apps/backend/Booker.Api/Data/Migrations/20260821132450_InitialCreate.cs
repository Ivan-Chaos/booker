using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booker.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VesselOperators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselOperators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CruiseShips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VesselOperatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShipName = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruiseShips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CruiseShips_VesselOperators_VesselOperatorId",
                        column: x => x.VesselOperatorId,
                        principalTable: "VesselOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cruises",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CruiseVesselId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cruises", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cruises_CruiseShips_CruiseVesselId",
                        column: x => x.CruiseVesselId,
                        principalTable: "CruiseShips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VesselOperators",
                columns: new[] { "Id", "Description", "IsActive", "Name", "Website" },
                values: new object[,]
                {
                    { new Guid("6f9a25a6-1c2f-4b7e-9d3a-0e8b1c4d5e6f"), "Scandinavian operator specializing in northern itineraries.", true, "Aurora Cruise Line", "https://aurora-cruises.example.com" },
                    { new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), "Mediterranean and Atlantic leisure cruises.", true, "Meridian Voyages", "https://meridian-voyages.example.com" }
                });

            migrationBuilder.InsertData(
                table: "CruiseShips",
                columns: new[] { "Id", "Capacity", "Description", "ImageUrl", "ShipName", "VesselOperatorId" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-4a6b-8c7d-9e0f1a2b3c4d"), 2200, "Flagship of the Aurora fleet.", "https://aurora-cruises.example.com/ships/northern-star.jpg", "MV Northern Star", new Guid("6f9a25a6-1c2f-4b7e-9d3a-0e8b1c4d5e6f") },
                    { new Guid("1b2c3d4e-5f6a-4b7c-8d9e-0f1a2b3c4d5e"), 1800, "Ice-strengthened hull for arctic routes.", null, "MV Polar Dawn", new Guid("6f9a25a6-1c2f-4b7e-9d3a-0e8b1c4d5e6f") },
                    { new Guid("2c3d4e5f-6a7b-4c8d-9e0f-1a2b3c4d5e6f"), 2600, "Largest ship in the Meridian fleet.", "https://meridian-voyages.example.com/ships/azure-horizon.jpg", "MV Azure Horizon", new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e") }
                });

            migrationBuilder.InsertData(
                table: "Cruises",
                columns: new[] { "id", "CruiseVesselId", "DateFrom", "DateTo", "Name" },
                values: new object[,]
                {
                    { new Guid("3d4e5f6a-7b8c-4d9e-8f0a-1b2c3d4e5f6a"), new Guid("0a1b2c3d-4e5f-4a6b-8c7d-9e0f1a2b3c4d"), new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Baltic Capitals" },
                    { new Guid("4e5f6a7b-8c9d-4e0f-9a1b-2c3d4e5f6a7b"), new Guid("1b2c3d4e-5f6a-4b7c-8d9e-0f1a2b3c4d5e"), new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Norwegian Fjords" },
                    { new Guid("5f6a7b8c-9d0e-4f1a-8b2c-3d4e5f6a7b8c"), new Guid("2c3d4e5f-6a7b-4c8d-9e0f-1a2b3c4d5e6f"), new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Mediterranean Odyssey" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cruises_CruiseVesselId",
                table: "Cruises",
                column: "CruiseVesselId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseShips_VesselOperatorId",
                table: "CruiseShips",
                column: "VesselOperatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cruises");

            migrationBuilder.DropTable(
                name: "CruiseShips");

            migrationBuilder.DropTable(
                name: "VesselOperators");
        }
    }
}
