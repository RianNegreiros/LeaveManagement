using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
  public class BadRequestException : ApplicationException
  {
    public BadRequestException(string message) : base(message)
    {

    }
  }
}