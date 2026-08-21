namespace Booker.Api.Models;

public class VesselOperator
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public string? Website { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<CruiseShip> CruiseShips { get; set; } = [];
}