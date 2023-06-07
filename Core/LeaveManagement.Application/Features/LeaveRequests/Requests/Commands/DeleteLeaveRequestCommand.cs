using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
  public class DeleteLeaveRequestCommand : IRequest
  {
    public int Id { get; set; }
  }
}