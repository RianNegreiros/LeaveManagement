using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Domain
{
  public class LeaveAllocation : BaseDomainEntity
  {
    public int NumberOfDays { get; set; }
  }
}