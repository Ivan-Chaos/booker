namespace Booker.Api.Dtos;

public record CruiseDto(
    Guid Id,
    string Name,
    DateTime DateFrom,
    DateTime DateTo,
    CruiseShipSummaryDto CruiseVessel);
