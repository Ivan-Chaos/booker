namespace Booker.Api.Dtos;

public record CruiseShipDto(
    Guid Id,
    string ShipName,
    int Capacity,
    string? Description,
    string? ImageUrl,
    Guid VesselOperatorId,
    string VesselOperatorName);

/// <summary>Compact ship reference for embedding in other DTOs.</summary>
public record CruiseShipSummaryDto(Guid Id, string ShipName);
