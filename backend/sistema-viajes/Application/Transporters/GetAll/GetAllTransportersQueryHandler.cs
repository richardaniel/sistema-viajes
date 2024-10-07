using Application.Transporters.GetAll;
using Domain.Transporters;
using ErrorOr;
using MediatR;

namespace Application.Transporters.GetAll;
/*
internal sealed class GetAllTransportersQueryHandler : IRequestHandler<GetAllTransportersQuery, ErrorOr<List<Transporter>>>
{
    private readonly ITransporterRepository _transporterRepository;

    public GetAllTransportersQueryHandler(ITransporterRepository transporterRepository)
    {
        _transporterRepository = transporterRepository ?? throw new ArgumentNullException(nameof(transporterRepository));
    }

    public async Task<ErrorOr<List<Transporter>>> Handle(GetAllTransportersQuery request, CancellationToken cancellationToken)
    {
        var transporters = await _transporterRepository.GetAllAsync();
        return transporters is not null ? transporters : new List<Transporter>();
    }
}*/
