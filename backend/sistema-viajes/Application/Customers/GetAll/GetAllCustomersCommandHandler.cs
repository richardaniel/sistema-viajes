using Domain.Customers;
using ErrorOr;
using MediatR;

namespace Application.Customers.GetAll
{
    internal sealed class GetAllCustomersCommandHandler : IRequestHandler<GetAllCustomersCommand, ErrorOr<List<Customer>>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<ErrorOr<List<Customer>>> Handle(GetAllCustomersCommand command, CancellationToken cancellationToken)
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
