using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using LeaveManagement.Domain;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
  public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
  {
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
      _leaveAllocationRepository = leaveAllocationRepository;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
      var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

      if (leaveAllocation == null)
        throw new NotFoundException(nameof(LeaveAllocation), request.Id);

      await _leaveAllocationRepository.Delete(leaveAllocation);

      return Unit.Value;
    }
  }
}