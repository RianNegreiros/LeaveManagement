using LeaveManagement.Application.DTOs;
using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
  public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
  {
  }
}