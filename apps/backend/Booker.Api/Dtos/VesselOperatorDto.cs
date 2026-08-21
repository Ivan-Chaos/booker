namespace Booker.Api.Dtos;

public record VesselOperatorDto(
    Guid Id,
    string Name,
    string? Description,
    string? Website,
    bool IsActive);
