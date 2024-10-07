
using Application.Customers.Create;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Create;


internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand,ErrorOr<Unit>>
{

    private readonly ICustomerRepository _customerRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository ,IUnitOfWork unitOfWork){
        _customerRepository=customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork=unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    }


    public async Task <ErrorOr<Unit>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
      try
      {
         if(PhoneNumber.Create(command.PhoneNumber)is not PhoneNumber phoneNumber){
        //throw new ArgumentException(nameof(command.PhoneNumber));
        //devolvemos objeto para el error
        return Error.Validation("Customer.PhoneNumber","Phone number has not valid format");

       }

       var customer = new Customer(
        new CustomerId(Guid.NewGuid()),
        command.Name,
        command.LastName,
        command.Email,
        phoneNumber,
        true
       );

       await _customerRepository.Add(customer);
       
       await _unitOfWork.SaveChangesAsync(cancellationToken);

       return Unit.Value;
      }
      catch (Exception ex)
      {
        
        return Error.Failure("CreateCustomer.Failure",ex.Message);
      }
    }
}

