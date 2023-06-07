using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeaveManagement.Core.Domain;

namespace LeaveManagement.Infrastructure
{
  public class LeaveManagementDbContext : DbContext
  {
    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationFromAssembly(typeof(LeaveManagementDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<BaseEntityDomain>())
      {
        entry.Entity.LastModified = DateTime.Now;

        if (entry.State == EntityState.Added)
        {
          entry.Entity.DateCreated = DateTime.Now;
        }
      }

      return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
  }
}