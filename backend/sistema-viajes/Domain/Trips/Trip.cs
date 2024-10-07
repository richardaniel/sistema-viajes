using Domain.Primitives;
using Domain.Transporters;
using Domain.Branches;
using Domain.Customers;

namespace Domain.Trips;

public sealed class Trip : AggregateRoot
{
    public Trip(TripId id, BranchId branchId, TransporterId transporterId, DateTime tripDate, List<Customer> customers, decimal totalDistance, decimal totalCost)
    {
        Id = id;
        BranchId = branchId;
        TransporterId = transporterId;
        TripDate = tripDate;
        Customers = customers;
        TotalDistance = totalDistance;
        TotalCost = totalCost;
    }

    public Trip() {}

    public TripId Id { get; private set; }

    public BranchId BranchId { get; private set; }

    public TransporterId TransporterId { get; private set; }

    public DateTime TripDate { get; private set; }

    public List<Customer> Customers{ get; private set; }

    public decimal TotalDistance { get; private set; }

    public decimal TotalCost { get; private set; }
}