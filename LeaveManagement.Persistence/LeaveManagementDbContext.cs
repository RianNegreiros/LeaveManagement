using LeaveManagement.Domain;
using LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence
{
  public class LeaveManagementDbContext : DbContext
  {
    public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
      {
        entry.Entity.LastModifiedDate = DateTime.Now;

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