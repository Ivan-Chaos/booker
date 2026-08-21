using Booker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Booker.Api.Data;

public class BookerContext(DbContextOptions<BookerContext> options): DbContext(options)
{
    public DbSet<Cruise> Cruises => Set<Cruise>();

    public DbSet<VesselOperator> VesselOperators => Set<VesselOperator>();

    public DbSet<CruiseShip> CruiseShips => Set<CruiseShip>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var auroraId = Guid.Parse("6f9a25a6-1c2f-4b7e-9d3a-0e8b1c4d5e6f");
        var meridianId = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e");

        modelBuilder.Entity<VesselOperator>().HasData(
            new VesselOperator
            {
                Id = auroraId,
                Name = "Aurora Cruise Line",
                Description = "Scandinavian operator specializing in northern itineraries.",
                Website = "https://aurora-cruises.example.com",
                IsActive = true
            },
            new VesselOperator
            {
                Id = meridianId,
                Name = "Meridian Voyages",
                Description = "Mediterranean and Atlantic leisure cruises.",
                Website = "https://meridian-voyages.example.com",
                IsActive = true
            });

        var northernStarId = Guid.Parse("0a1b2c3d-4e5f-4a6b-8c7d-9e0f1a2b3c4d");
        var polarDawnId = Guid.Parse("1b2c3d4e-5f6a-4b7c-8d9e-0f1a2b3c4d5e");
        var azureHorizonId = Guid.Parse("2c3d4e5f-6a7b-4c8d-9e0f-1a2b3c4d5e6f");

        modelBuilder.Entity<CruiseShip>().HasData(
            new CruiseShip
            {
                Id = northernStarId,
                VesselOperatorId = auroraId,
                ShipName = "MV Northern Star",
                Capacity = 2200,
                Description = "Flagship of the Aurora fleet.",
                ImageUrl = "https://aurora-cruises.example.com/ships/northern-star.jpg"
            },
            new CruiseShip
            {
                Id = polarDawnId,
                VesselOperatorId = auroraId,
                ShipName = "MV Polar Dawn",
                Capacity = 1800,
                Description = "Ice-strengthened hull for arctic routes.",
                ImageUrl = null
            },
            new CruiseShip
            {
                Id = azureHorizonId,
                VesselOperatorId = meridianId,
                ShipName = "MV Azure Horizon",
                Capacity = 2600,
                Description = "Largest ship in the Meridian fleet.",
                ImageUrl = "https://meridian-voyages.example.com/ships/azure-horizon.jpg"
            });

        // Cruise.CruiseVessel has no FK property, so its shadow FK is seeded via an anonymous type.
        modelBuilder.Entity<Cruise>().HasData(
            new
            {
                id = Guid.Parse("3d4e5f6a-7b8c-4d9e-8f0a-1b2c3d4e5f6a"),
                Name = "Baltic Capitals",
                DateFrom = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2026, 9, 10, 0, 0, 0, DateTimeKind.Utc),
                CruiseVesselId = northernStarId
            },
            new
            {
                id = Guid.Parse("4e5f6a7b-8c9d-4e0f-9a1b-2c3d4e5f6a7b"),
                Name = "Norwegian Fjords",
                DateFrom = new DateTime(2026, 10, 5, 0, 0, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2026, 10, 15, 0, 0, 0, DateTimeKind.Utc),
                CruiseVesselId = polarDawnId
            },
            new
            {
                id = Guid.Parse("5f6a7b8c-9d0e-4f1a-8b2c-3d4e5f6a7b8c"),
                Name = "Mediterranean Odyssey",
                DateFrom = new DateTime(2026, 11, 1, 0, 0, 0, DateTimeKind.Utc),
                DateTo = new DateTime(2026, 11, 12, 0, 0, 0, DateTimeKind.Utc),
                CruiseVesselId = azureHorizonId
            });
    }
}
