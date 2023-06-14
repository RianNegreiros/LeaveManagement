using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories
{
  public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
  {
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
      await _dbContext.AddRangeAsync(allocations);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
      return await _dbContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                  && q.LeaveTypeId == leaveTypeId
                                  && q.Period == period);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
      var leaveAllocations = await _dbContext.LeaveAllocations
         .Include(q => q.LeaveType)
         .ToListAsync();
      return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
      var leaveAllocations = await _dbContext.LeaveAllocations.Where(q => q.EmployeeId == userId)
         .Include(q => q.LeaveType)
         .ToListAsync();
      return leaveAllocations;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
      var leaveAllocation = await _dbContext.LeaveAllocations
          .Include(q => q.LeaveType)
          .FirstOrDefaultAsync(q => q.Id == id);

      return leaveAllocation;
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
      return await _dbContext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                  && q.LeaveTypeId == leaveTypeId);
    }
  }
}