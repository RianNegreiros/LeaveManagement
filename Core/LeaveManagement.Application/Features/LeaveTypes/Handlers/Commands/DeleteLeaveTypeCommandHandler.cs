using AutoMapper;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using LeaveManagement.Application.Persistence.Contracts;
using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
  public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
      _leaveTypeRepository = leaveTypeRepository;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
      var leaveType = await _leaveTypeRepository.Get(request.Id);

      if (leaveType == null)
        throw new NotFoundException(nameof(LeaveType), request.Id);

      await _leaveTypeRepository.Delete(leaveType);

      return Unit.Value;
    }
  }
}