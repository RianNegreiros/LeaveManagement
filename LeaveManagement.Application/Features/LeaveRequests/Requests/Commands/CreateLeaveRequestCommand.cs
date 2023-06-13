using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Responses;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
  {
    public CreateLeaveRequestDto LeaveRequestDto { get; set; }
  }
}