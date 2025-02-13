using Domain.Branches;
using Domain.Collaborators;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.CollaboratorBranches;

public sealed class CollaboratorBranch : AggregateRoot
{
    public CollaboratorBranch(CollaboratorBranchId id,CollaboratorId collaboratorId, BranchId branchId, decimal distanceKm)
    {
        Id = id;
        CollaboratorId = collaboratorId;
        BranchId = branchId;
        DistanceKm = distanceKm;
    }

    public CollaboratorBranch() { }

    public CollaboratorBranchId Id { get; private set; }

    public CollaboratorId CollaboratorId{ get; private set; }

    public BranchId BranchId { get; private set; }

    public decimal DistanceKm { get; private set; }
}
