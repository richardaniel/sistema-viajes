
namespace Domain.Trips;

public interface ITripRepository
{
    Task<Trip?> GetByIdAsync(TripId id);
    Task Add(Trip trip);
    Task Update(Trip trip);
    Task<Trip> GetAllAsync();
}