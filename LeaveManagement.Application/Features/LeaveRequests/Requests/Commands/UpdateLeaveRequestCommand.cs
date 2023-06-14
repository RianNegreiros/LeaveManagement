using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class UpdateLeaveRequestCommand : IRequest<Unit>
  {
    public int Id { get; set; }

    public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }

  }
}