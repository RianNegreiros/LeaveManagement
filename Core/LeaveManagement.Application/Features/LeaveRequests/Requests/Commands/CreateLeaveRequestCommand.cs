using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class CreateLeaveRequest : IRequest<BaseCommandResponse>
  {
    public CreateLeaveRequestDto LeaveRequestDto { get; set; }
  }
}