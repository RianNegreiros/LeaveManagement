using LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
  public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
  {
    public int Id { get; set; }
  }
}