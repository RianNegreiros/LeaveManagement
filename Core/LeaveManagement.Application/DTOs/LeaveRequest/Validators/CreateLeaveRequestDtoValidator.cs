using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
  public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
      _leaveTypeRepository = leaveTypeRepository;
      Include(new ILeaveRequestDtoValidator(_leaveTypeRepository));
    }
  }
}