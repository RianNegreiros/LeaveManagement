using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
  public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
  {
    public bool IsLoggedInUser { get; set; }
  }
}