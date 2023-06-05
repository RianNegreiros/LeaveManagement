using System;

namespace LeaveManagement.Domain
{
  public class LeaveType : BaseDomainEntity
  {
    public string Name { get; set; }
    public int DefaultDays { get; set; }
  }
}