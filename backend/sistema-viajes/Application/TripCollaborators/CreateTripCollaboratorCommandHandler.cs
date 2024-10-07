using Application.TripCollaborators.Create;
using Domain.TripCollaborators;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using Domain.Trips;
using Domain.Customers;

namespace Application.TripCollaborators.Create;

internal sealed class CreateTripCollaboratorCommandHandler : IRequestHandler<CreateTripCollaboratorCommand, ErrorOr<Unit>>
{
    private readonly ITripCollaboratorRepository _tripCollaboratorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTripCollaboratorCommandHandler(ITripCollaboratorRepository tripCollaboratorRepository, IUnitOfWork unitOfWork)
    {
        _tripCollaboratorRepository = tripCollaboratorRepository ?? throw new ArgumentNullException(nameof(tripCollaboratorRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateTripCollaboratorCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var tripCollaborator = new TripCollaborator(
                new TripCollaboratorId(Guid.NewGuid()), // Asignar 0 para la identidad, se generará al guardar
                new TripId(Guid.NewGuid()),
                new CustomerId(Guid.NewGuid()),
                command.DistanceKm,
                command.Cost
            );

            await _tripCollaboratorRepository.Add(tripCollaborator);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateTripCollaborator.Failure", ex.Message);
        }
    }
}
