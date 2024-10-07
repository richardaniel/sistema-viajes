using Application.CollaboratorBranches.Create;
using Domain.Branches;
using Domain.CollaboratorBranches;
using Domain.Customers;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.CollaboratorBranches.Create;

internal sealed class CreateCollaboratorBranchCommandHandler : IRequestHandler<CreateCollaboratorBranchCommand, ErrorOr<Unit>>
{
    private readonly ICollaboratorBranchRepository _collaboratorBranchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCollaboratorBranchCommandHandler(ICollaboratorBranchRepository collaboratorBranchRepository, IUnitOfWork unitOfWork)
    {
        _collaboratorBranchRepository = collaboratorBranchRepository ?? throw new ArgumentNullException(nameof(collaboratorBranchRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateCollaboratorBranchCommand command, CancellationToken cancellationToken)
    {
        try
        {
            bool isAlreadyAssociated = await _collaboratorBranchRepository.IsCustomerBranchAssociatedAsync(command.CustomerId, command.BranchId);


            
        if (isAlreadyAssociated)
        {
            return Error.Conflict(description: "El colaborador ya está asignado a esta sucursal.");
        }


            var collaboratorBranch = new CollaboratorBranch(
                new CollaboratorBranchId(Guid.NewGuid()),
                new CustomerId(command.CustomerId),
                new BranchId(command.BranchId),
                command.DistanceKm
            );

            await _collaboratorBranchRepository.Add(collaboratorBranch);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateCollaboratorBranch.Failure", ex.Message);
        }
    }
}
