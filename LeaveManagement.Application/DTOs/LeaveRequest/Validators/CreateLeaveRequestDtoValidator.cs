using FluentValidation;
using LeaveManagement.Application.Persistence.Contracts;

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