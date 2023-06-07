using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
  public class NotFoundException : ApplicationException
  {
    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
    {

    }
  }
}