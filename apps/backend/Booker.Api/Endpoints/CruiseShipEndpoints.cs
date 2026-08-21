using Booker.Api.Data;
using Booker.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Booker.Api.Endpoints;

public static class CruiseShipEndpoints
{
    public static IEndpointRouteBuilder MapCruiseShipEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cruise-ships", async (BookerContext db) =>
            await db.CruiseShips
                .AsNoTracking()
                .OrderBy(s => s.ShipName)
                .Select(s => new CruiseShipDto(
                    s.Id,
                    s.ShipName,
                    s.Capacity,
                    s.Description,
                    s.ImageUrl,
                    s.VesselOperatorId,
                    s.VesselOperator!.Name))
                .ToListAsync());

        return app;
    }
}
