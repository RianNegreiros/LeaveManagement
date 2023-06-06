using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain
{
  public class LeaveRequest : BaseDomainEntity
  {
    public DateTime StartDate { get; set; }
    public DateTime EndtDate { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public DateTime DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
  }
}