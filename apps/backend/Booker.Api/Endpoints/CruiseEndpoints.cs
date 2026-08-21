using Booker.Api.Data;
using Booker.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Booker.Api.Endpoints;

public static class CruiseEndpoints
{
    public static IEndpointRouteBuilder MapCruiseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cruises", async (BookerContext db) =>
            await db.Cruises
                .AsNoTracking()
                .OrderBy(c => c.DateFrom)
                .Select(c => new CruiseDto(
                    c.id,
                    c.Name,
                    c.DateFrom,
                    c.DateTo,
                    new CruiseShipSummaryDto(c.CruiseVessel.Id, c.CruiseVessel.ShipName)))
                .ToListAsync());

        return app;
    }
}
