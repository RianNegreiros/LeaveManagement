using LeaveManagement.Application.DTOs.Common;

namespace LeaveManagement.Application.DTOs.LeaveType
{
  public class CreateLeaveTypeDto : ILeaveTypeDto
  {
    public string Name { get; set; }
    public int DefaultDays { get; set; }
  }

}