
using Domain.Users;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Users.Create;


internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,ErrorOr<Unit>>
{

    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    private readonly IHashPassword _hashPassword; 

    public CreateUserCommandHandler(IUserRepository userRepository ,IUnitOfWork unitOfWork,IHashPassword hashPassword){
        _userRepository=userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _unitOfWork=unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _hashPassword = hashPassword?? throw new ArgumentNullException(nameof(hashPassword));  
        
      }


    public async Task <ErrorOr<Unit>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
      try
      {
         if(Rol.Create(command.Rol)is not Rol rol){
        //throw new ArgumentException(nameof(command.PhoneNumber));
        //devolvemos objeto para el error
        return Error.Validation("User.rol","Rol User is not valid ");

       }

       string hashedPassword = _hashPassword.Hash(command.Password);

       var user = new User(
        new UserId(Guid.NewGuid()),
        command.Name,
        command.Email,
        hashedPassword,
        rol,
        true
       );

       await _userRepository.Add(user);
       
       await _unitOfWork.SaveChangesAsync(cancellationToken);

       return Unit.Value;
      }
      catch (Exception ex)
      {
        
        return Error.Failure("CreateUser.Failure",ex.Message);
      }
    }
}

