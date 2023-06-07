using AutoMapper;
using LeaveManagement.Application.DTOs;
using LeaveManagement.Application.DTOs.LeaveRequest;
using LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using LeaveManagement.Application.Features.LeaveTypes.Requests;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveRequests.Queries
{
  public class GetLeaveRequestDetailsRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
  {
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailRequestHandler(ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper)
    {
      _leaveRequestRepository = leaveRequestRepository;
      _mapper = mapper;
    }
    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
      var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
      return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
  }
}