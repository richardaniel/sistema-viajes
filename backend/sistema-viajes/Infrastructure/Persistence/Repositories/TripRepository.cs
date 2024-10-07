using System.Threading.Tasks;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TripRepository : ITripRepository
{
    private readonly ApplicationDbContext _context;

    public TripRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Trip trip) => await _context.Trips.AddAsync(trip);

    public Task<Trip> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Trip?> GetByIdAsync(TripId id) => 
        await _context.Trips.SingleOrDefaultAsync(t => t.Id == id);

    public Task Update(Trip trip)
    {
        throw new NotImplementedException();
    }
}
