using Application.Transporters.Create;
using Domain.Transporters;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Transporters.Create;

internal sealed class CreateTransporterCommandHandler : IRequestHandler<CreateTransporterCommand, ErrorOr<Unit>>
{
    private readonly ITransporterRepository _transporterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransporterCommandHandler(ITransporterRepository transporterRepository, IUnitOfWork unitOfWork)
    {
        _transporterRepository = transporterRepository ?? throw new ArgumentNullException(nameof(transporterRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateTransporterCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var transporter = new Transporter(
                new TransporterId(Guid.NewGuid()),
                command.Name,
                command.RatePerKm
            );

            await _transporterRepository.Add(transporter);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateTransporter.Failure", ex.Message);
        }
    }
}
