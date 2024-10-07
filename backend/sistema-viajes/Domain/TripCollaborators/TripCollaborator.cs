using Domain.Customers;
using Domain.Primitives;
using Domain.Trips;


namespace Domain.TripCollaborators;

public sealed class TripCollaborator : AggregateRoot
{
    public TripCollaborator(TripCollaboratorId id, TripId tripId, CustomerId customerId, decimal distanceKm, decimal cost)
    {
        Id = id;
        TripId = tripId;
        CustomerId = customerId;
        DistanceKm = distanceKm;
        Cost = cost;
    }

    public TripCollaborator() { }

    public TripCollaboratorId Id { get; private set; }

    public TripId TripId { get; private set; }

    public CustomerId CustomerId{ get; private set; }

    public decimal DistanceKm { get; private set; }

    public decimal Cost { get; private set; }
}
