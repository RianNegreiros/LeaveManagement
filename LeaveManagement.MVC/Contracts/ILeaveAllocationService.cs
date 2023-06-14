using LeaveManagement.MVC.Services.Base;

namespace LeaveManagement.MVC.Contracts
{
  public interface ILeaveAllocationService
  {
    Task<Response<int>> CreateLeaveAllocations(int leaveTypeId);
  }
}
