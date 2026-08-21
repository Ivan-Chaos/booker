namespace Booker.Api.Models;


public class Cruise
{
    public Guid id {get; set;}

    public required string Name {get; set;}

    public required DateTime DateFrom {get; set;}

    public required DateTime DateTo {get; set;}

    public required CruiseShip CruiseVessel {get; set;}
}