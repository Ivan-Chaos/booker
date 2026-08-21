using Booker.Api.Data;
using Booker.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Booker.Api.Endpoints;

public static class VesselOperatorEndpoints
{
    public static IEndpointRouteBuilder MapVesselOperatorEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/vessel-operators", async (BookerContext db) =>
            await db.VesselOperators
                .AsNoTracking()
                .OrderBy(o => o.Name)
                .Select(o => new VesselOperatorDto(o.Id, o.Name, o.Description, o.Website, o.IsActive))
                .ToListAsync());

        return app;
    }
}
