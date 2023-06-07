using LeaveManagement.Application.DTOs.Common;
using LeaveManagement.Application.DTOs.LeaveAllocation;

namespace LeaveManagement.Application.DTOs.LeaveAllocation
{
  public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
  {
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
  }
}