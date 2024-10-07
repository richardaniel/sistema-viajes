namespace Domain.Transporters;

public interface ITransporterRepository
{
    Task<Transporter?> GetByIdAsync(TransporterId id);

     Task<Transporter?> GetAllAsync();
    Task Add(Transporter transporter);
    Task Update(Transporter transporter);
}