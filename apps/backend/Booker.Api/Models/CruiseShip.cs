namespace Booker.Api.Models;

public class CruiseShip
{
    public required Guid Id { get; set; }

    public required Guid VesselOperatorId { get; set; }
     public VesselOperator? VesselOperator { get; set; }
    public required string ShipName { get; set; }

    public required int Capacity { get; set; }
    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}