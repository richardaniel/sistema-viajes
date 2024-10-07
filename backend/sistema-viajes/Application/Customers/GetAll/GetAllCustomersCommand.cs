using ErrorOr;
using MediatR;
using Domain.Customers; 

namespace Application.Customers.GetAll
{
    public record GetAllCustomersCommand : IRequest<ErrorOr<List<Customer>>>;
}
