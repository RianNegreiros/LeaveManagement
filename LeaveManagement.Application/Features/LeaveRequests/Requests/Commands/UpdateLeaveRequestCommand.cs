using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class UpdateLeaveRequestCommand : IRequest<Unit>
  {
    public int Id { get; set; }

    public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }

  }
}