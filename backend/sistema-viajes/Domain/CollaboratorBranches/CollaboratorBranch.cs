using Domain.Branches;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.CollaboratorBranches;

public sealed class CollaboratorBranch : AggregateRoot
{
    public CollaboratorBranch(CollaboratorBranchId id,CustomerId customerId, BranchId branchId, decimal distanceKm)
    {
        Id = id;
        CustomerId = customerId;
        BranchId = branchId;
        DistanceKm = distanceKm;
    }

    public CollaboratorBranch() { }

    public CollaboratorBranchId Id { get; private set; }

    public CustomerId CustomerId{ get; private set; }

    public BranchId BranchId { get; private set; }

    public decimal DistanceKm { get; private set; }
}
