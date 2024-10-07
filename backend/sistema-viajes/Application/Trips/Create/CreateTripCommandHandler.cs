using Application.Trips.Create;
using Domain.Trips;
using Domain.Branches;
using Domain.Customers;
using Domain.Transporters;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Trips.Create;

internal sealed class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, ErrorOr<Unit>>
{
    private readonly ITripRepository _tripRepository;
    private readonly ICustomerRepository _customerRepository; // Repositorio para cargar los Customers
    private readonly IUnitOfWork _unitOfWork;

    public CreateTripCommandHandler(
        ITripRepository tripRepository,
        ICustomerRepository customerRepository, // Inyectamos el repositorio de Customers
        IUnitOfWork unitOfWork)
    {
        _tripRepository = tripRepository ?? throw new ArgumentNullException(nameof(tripRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateTripCommand command, CancellationToken cancellationToken)
    {
        try
        {
            // Validar que la distancia total no exceda 100 km
            if (command.TotalDistance > 100)
            {
                return Error.Validation("Trip.TotalDistance", "Total distance cannot exceed 100 km");
            }

            // Cargar la lista completa de Customers desde los CustomerId
            var customers = new List<Customer>();
            foreach (var customerId in command.CustomerId)
            {
                var customer = await _customerRepository.GetByIdAsync(new CustomerId(customerId));
                if (customer is null)
                {
                    return Error.NotFound("Customer.NotFound", $"Customer with ID {customerId} not found");
                }
                customers.Add(customer);
            }

            // Calcular el costo total del viaje
            decimal totalCost = CalculateTotalCost(command.TotalDistance);

            // Crear la entidad Trip
            var trip = new Trip(
                new TripId(Guid.NewGuid()),
                new BranchId(command.BranchId),
                new TransporterId(command.TransporterId),
                command.TripDate,
                customers, // Pasamos la lista de Customers completa
                command.TotalDistance,
                totalCost
            );

            // Guardar el viaje
            await _tripRepository.Add(trip);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateTrip.Failure", ex.Message);
        }
    }

    private decimal CalculateTotalCost(decimal distance)
    {
        // Ejemplo de cálculo simple de costo basado en distancia
        decimal costPerKm = 10m; // Costo por kilómetro
        return distance * costPerKm;
    }
}
