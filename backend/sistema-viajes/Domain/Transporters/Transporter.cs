using Domain.Primitives;

namespace Domain.Transporters;

public sealed class Transporter : AggregateRoot
{
    public Transporter(TransporterId id, string name, decimal ratePerKm)
    {
        Id = id;
        Name = name;
        RatePerKm = ratePerKm;
    }

    public Transporter() {}

    public TransporterId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public decimal RatePerKm { get; private set; }
}
