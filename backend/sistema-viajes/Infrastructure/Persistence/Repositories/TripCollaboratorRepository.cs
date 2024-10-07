using System.Threading.Tasks;
using Domain.TripCollaborators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TripCollaboratorRepository : ITripCollaboratorRepository
{
    private readonly ApplicationDbContext _context;

    public TripCollaboratorRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(TripCollaborator tripCollaborator)
    {
        await _context.TripCollaborators.AddAsync(tripCollaborator);
    }

    public async Task<TripCollaborator?> GetByIdAsync(TripCollaboratorId id)
    {
        return await _context.TripCollaborators
            .SingleOrDefaultAsync(tc => tc.Id == id);
    }

    // Aquí puedes agregar más métodos según sea necesario
}
