using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.Repositories
{
  public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
  {
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
      var leaveAllocations = await _dbContext.LeaveAllocations
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
  }
}