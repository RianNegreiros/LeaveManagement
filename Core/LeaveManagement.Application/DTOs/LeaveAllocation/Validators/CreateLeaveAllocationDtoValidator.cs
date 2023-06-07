using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
  public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
      _leaveTypeRepository = leaveTypeRepository;
      Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
    }
  }
}