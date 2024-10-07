using System.Threading.Tasks;
using Domain.Transporters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TransporterRepository : ITransporterRepository
{
    private readonly ApplicationDbContext _context;

    public TransporterRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Transporter transporter) => await _context.Transporters.AddAsync(transporter);

    public Task<Transporter?> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Transporter?> GetByIdAsync(TransporterId id) => 
        await _context.Transporters.SingleOrDefaultAsync(t => t.Id == id);

    public Task Update(Transporter transporter)
    {
        throw new NotImplementedException();
    }
}
