
using Domain.Branches;
using ErrorOr;
using MediatR;

namespace Application.Branches.GetAll
{
internal sealed class GetAllBranchesCommandHandler : IRequestHandler<GetAllBranchesCommand, ErrorOr<List<Branch>>>
{
    private readonly IBranchRepository _branchRepository;

    public GetAllBranchesCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));
    }

    public async Task<ErrorOr<List<Branch>>> Handle(GetAllBranchesCommand command, CancellationToken cancellationToken)
    {
        try{
            var branches = await _branchRepository.GetAllAsync();

            return branches;
        }
        catch(Exception ex){
             return Error.Failure("GetAllBranches.Failure", ex.Message);
        }
    }
}

}
