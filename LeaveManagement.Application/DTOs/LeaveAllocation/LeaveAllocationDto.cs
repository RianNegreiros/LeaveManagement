using LeaveManagement.Application.DTOs.Common;
using LeaveManagement.Application.DTOs.LeaveType;
using LeaveManagement.Application.Models.Identity;

namespace LeaveManagement.Application.DTOs.LeaveAllocation
{
  public class LeaveAllocationDto : BaseDto
  {
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public Employee Employee { get; set; }
    public string EmployeeId { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
  }
}