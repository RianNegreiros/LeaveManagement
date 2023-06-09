using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using LeaveManagement.Application.Exceptions;
using LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
  public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
  {
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
         ILeaveTypeRepository leaveTypeRepository,
         ILeaveAllocationRepository leaveAllocationRepository,
         IMapper mapper)
    {
      _leaveRequestRepository = leaveRequestRepository;
      _leaveTypeRepository = leaveTypeRepository;
      this._leaveAllocationRepository = leaveAllocationRepository;
      _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
      var leaveRequest = await _leaveRequestRepository.Get(request.Id);

      if (request.LeaveRequestDto != null)
      {
        var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
        if (validationResult.IsValid == false)
          throw new ValidationException(validationResult);
        _mapper.Map(request.LeaveRequestDto, leaveRequest);

        await _leaveRequestRepository.Update(leaveRequest);
      }
      else if (request.ChangeLeaveRequestApprovalDto != null)
      {
        await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
        if (request.ChangeLeaveRequestApprovalDto.Approved)
        {
          var allocation = await _leaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
          int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

          allocation.NumberOfDays -= daysRequested;

          await _leaveAllocationRepository.Update(allocation);
        }
      }

      return Unit.Value;
    }
  }
}