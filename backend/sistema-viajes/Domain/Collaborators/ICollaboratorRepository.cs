

namespace Domain.Collaborators;

public interface ICollaboratorRepository{

    Task<Collaborator?> GetByIdAsync(CollaboratorId id);

    Task Add (Collaborator customer);

     Task<List<Collaborator>> GetAllAsync();
}