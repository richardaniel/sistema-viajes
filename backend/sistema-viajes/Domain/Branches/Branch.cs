using Domain.Primitives;

namespace Domain.Branches;

public sealed class Branch : AggregateRoot
{
    public Branch(BranchId id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    public Branch() {}

    public BranchId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;
}
