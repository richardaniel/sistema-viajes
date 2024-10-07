using ErrorOr;
using MediatR;
using Domain.Transporters;

namespace Application.Transporters.GetAll;

public record GetAllTransportersQuery : IRequest<ErrorOr<List<Transporter>>>;
