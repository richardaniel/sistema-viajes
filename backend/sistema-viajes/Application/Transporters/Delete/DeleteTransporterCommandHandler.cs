using Application.Transporters.Delete;
using Domain.Transporters;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Transporters.Delete;

internal sealed class DeleteTransporterCommandHandler : IRequestHandler<DeleteTransporterCommand, ErrorOr<Unit>>
{
    private readonly ITransporterRepository _transporterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransporterCommandHandler(ITransporterRepository transporterRepository, IUnitOfWork unitOfWork)
    {
        _transporterRepository = transporterRepository ?? throw new ArgumentNullException(nameof(transporterRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteTransporterCommand command, CancellationToken cancellationToken)
    {
        var transporter = await _transporterRepository.GetByIdAsync(new TransporterId(command.TransporterId));

        if (transporter is null)
        {
            return Error.NotFound("Transporter.NotFound", "Transporter not found");
        }

        //_transporterRepository.Remove(transporter);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
