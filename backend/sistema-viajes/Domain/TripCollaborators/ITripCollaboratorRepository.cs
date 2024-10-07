using System.Threading.Tasks;

namespace Domain.TripCollaborators;

public interface ITripCollaboratorRepository
{
    Task<TripCollaborator?> GetByIdAsync(TripCollaboratorId id);
    Task Add(TripCollaborator tripCollaborator);
}
