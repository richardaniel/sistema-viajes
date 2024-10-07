using Application.Branches.Delete;
using Domain.Branches;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Branches.Delete;

internal sealed class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, ErrorOr<Unit>>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBranchCommandHandler(IBranchRepository branchRepository, IUnitOfWork unitOfWork)
    {
        _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(new BranchId(command.BranchId));

        if (branch is null)
        {
            return Error.NotFound("Branch.NotFound", "Branch not found");
        }

        //_branchRepository.Remove(branch);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
