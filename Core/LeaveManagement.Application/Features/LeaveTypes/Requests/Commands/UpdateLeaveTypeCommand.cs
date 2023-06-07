using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class UpdateLeaveTypeCommand : IRequest<Unit>
  {
    public LeaveTypeDto LeaveTypeDto { get; set; }

  }
}