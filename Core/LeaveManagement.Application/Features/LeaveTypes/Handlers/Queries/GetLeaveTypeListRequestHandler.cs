using System;
using MediatR;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LeaveManagement.Application.DTOs;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
  public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
      _leaveTypeRepository = leaveTypeRepository;
      _mapper = mapper;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
      var leaveTypes = await _leaveTypeRepository.GetAll();
      return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
    }
  }
}