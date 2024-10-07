
using Domain.Customers;
using Domain.CollaboratorBranches;
using ErrorOr;
using MediatR;
using Domain.Primitives;


namespace Application.CollaboratorBranches.GetCustomerByBranchId;

internal sealed class GetCustomersByBranchIdCommandHandler : IRequestHandler<GetCustomersByBranchIdCommand , ErrorOr<List<Customer>>>
{
    private readonly ICollaboratorBranchRepository _collaboratorBranchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomersByBranchIdCommandHandler(ICollaboratorBranchRepository collaboratorBranchRepository, IUnitOfWork unitOfWork)
    {
        _collaboratorBranchRepository = collaboratorBranchRepository ?? throw new ArgumentNullException(nameof(collaboratorBranchRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<List<Customer>>> Handle(GetCustomersByBranchIdCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var customers = await _collaboratorBranchRepository.GetCustomersByBranchIdAsync(command.BranchId);

            return customers;
        }
        catch (Exception ex)
        {
            return Error.Failure("GetCustomersByBranchId.Failure", ex.Message);
        }
    }
}
