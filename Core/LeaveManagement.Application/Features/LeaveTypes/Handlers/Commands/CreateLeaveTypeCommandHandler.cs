using LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
  public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
  {
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
      _leaveTypeRepository = leaveTypeRepository;
      _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
      var validator = new CreateLeaveTypeDtoValidator();
      var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

      if (validationResult.IsValid == false)
        throw new ValidationException(validationResult);

      var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

      leaveType = await _leaveTypeRepository.Add(leaveType);

      return leaveType.Id;
    }
  }
}