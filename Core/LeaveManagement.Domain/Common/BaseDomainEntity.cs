namespace LeaveManagement.Domain.Common
{
  public abstract class BaseDomainEntity
  {
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public DateTime DateCreated { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
  }
}