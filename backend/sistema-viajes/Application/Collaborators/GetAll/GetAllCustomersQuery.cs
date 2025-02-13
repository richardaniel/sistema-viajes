using ErrorOr;
using MediatR;
using Domain.Collaborators; 

namespace Application.Customers.GetAll
{
    public record GetAllCustomersQuery : IRequest<ErrorOr<List<Collaborator>>>;
}
