using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
  public class LeaveAllocation : BaseDomainEntity
  {
    public int NumberOfDays { get; set; }
  }
}