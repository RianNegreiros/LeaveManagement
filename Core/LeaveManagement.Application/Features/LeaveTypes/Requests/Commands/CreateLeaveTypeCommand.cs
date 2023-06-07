using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class CreateLeaveTypeCommand : IRequest<int>
  {
    public CreateLeaveTypeDto LeaveTypeDto { get; set; }
  }
}