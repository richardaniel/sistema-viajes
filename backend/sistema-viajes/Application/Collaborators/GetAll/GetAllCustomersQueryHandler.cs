using Domain.Collaborators;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll
{
    internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<List<Collaborator>>>
    {
        private readonly ICollaboratorRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICollaboratorRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<ErrorOr<List<Collaborator>>> Handle(GetAllCustomersQuery command, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync(); // Implementa este método en tu repositorio
                return customers;
            }
            catch (Exception ex)
            {
                return Error.Failure("GetAllCustomers.Failure", ex.Message);
            }
        }
    }
}
