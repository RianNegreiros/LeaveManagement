using AutoMapper;
using LeaveManagement.Application.Contracts.Identity;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Queries
{
  public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
  {
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUserService userService)
    {
      _leaveRequestRepository = leaveRequestRepository;
      _mapper = mapper;
      this._userService = userService;
    }
    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
      var leaveRequest = _mapper.Map<LeaveRequestDto>(await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id));
      leaveRequest.Employee = await _userService.GetEmployee(leaveRequest.RequestingEmployeeId);
      return leaveRequest;
    }
  }
}