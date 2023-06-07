using LeaveManagement.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LeaveManagement.Application.Persistence.Contracts
{
  public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
  {
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
  }
}