using Domain.Customers;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.CollaboratorBranches.GetCustomerByBranchId;

public record GetCustomersByBranchIdCommand(Guid BranchId) : IRequest<ErrorOr<List<Customer>>>;
