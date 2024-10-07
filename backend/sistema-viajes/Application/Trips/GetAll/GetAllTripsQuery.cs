using ErrorOr;
using MediatR;
using Domain.Trips;

namespace Application.Trips.GetAll;

public record GetAllTripsQuery : IRequest<ErrorOr<List<Trip>>>;
