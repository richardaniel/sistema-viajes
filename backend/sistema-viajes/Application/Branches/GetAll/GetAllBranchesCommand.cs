using ErrorOr;
using MediatR;
using Domain.Branches;

namespace Application.Branches.GetAll;

public record GetAllBranchesCommand: IRequest<ErrorOr<List<Branch>>>;
