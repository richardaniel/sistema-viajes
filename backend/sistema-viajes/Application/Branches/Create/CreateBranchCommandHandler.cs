using Application.Branches.Create;
using Domain.Branches;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Branches.Create;

internal sealed class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, ErrorOr<Unit>>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork)
    {
        _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var branch = new Branch(
                new BranchId(Guid.NewGuid()),
                command.Name,
                command.Address
            );

            await _branchRepository.Add(branch);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (Exception ex)
        {
            return Error.Failure("CreateBranch.Failure", ex.Message);
        }
    }
}
