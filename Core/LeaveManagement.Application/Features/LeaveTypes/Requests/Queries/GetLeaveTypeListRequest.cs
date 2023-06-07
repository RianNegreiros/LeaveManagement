using LeaveManagement.Application.DTOs;
using LeaveManagement.Application.DTOs.LeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
  public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
  {
  }
}