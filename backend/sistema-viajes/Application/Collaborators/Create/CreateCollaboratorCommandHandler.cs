
using Application.Collaborators.Create;
using Domain.Collaborators;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Create;


internal sealed class CreateCollaboratorCommandHandler : IRequestHandler<CreateCollaboratorCommand,ErrorOr<Unit>>
{

    private readonly ICollaboratorRepository _collaboratorRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateCollaboratorCommandHandler(ICollaboratorRepository collaboratorRepository ,IUnitOfWork unitOfWork){
        _collaboratorRepository=collaboratorRepository ?? throw new ArgumentNullException(nameof(collaboratorRepository));
        _unitOfWork=unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    }


    public async Task <ErrorOr<Unit>> Handle(CreateCollaboratorCommand command, CancellationToken cancellationToken)
    {
      try
      {
         if(PhoneNumber.Create(command.PhoneNumber)is not PhoneNumber phoneNumber){
        //throw new ArgumentException(nameof(command.PhoneNumber));
        
        return Error.Validation("Customer.PhoneNumber","Phone number has not valid format");

       }

       var customer = new Collaborator(
        new CollaboratorId(Guid.NewGuid()),
        command.Name,
        command.LastName,
        command.Email,
        phoneNumber,
        true
       );

       await _collaboratorRepository.Add(customer);
       
       await _unitOfWork.SaveChangesAsync(cancellationToken);

       return Unit.Value;
      }
      catch (Exception ex)
      {
        
        return Error.Failure("CreateCustomer.Failure",ex.Message);
      }
    }
}

