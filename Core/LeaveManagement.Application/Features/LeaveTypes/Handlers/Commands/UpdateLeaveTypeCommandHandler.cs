using AutoMapper;
using LeaveManagement.Application.DTOs.LeaveType.Validators;
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
  public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
      _leaveTypeRepository = leaveTypeRepository;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
      var validator = new UpdateLeaveTypeDtoValidator();
      var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

      if (validationResult.IsValid == false)
        throw new ValidationException(validationResult);

      var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);

      _mapper.Map(request.LeaveTypeDto, leaveType);

      await _leaveTypeRepository.Update(leaveType);

      return Unit.Value;
    }
  }
}