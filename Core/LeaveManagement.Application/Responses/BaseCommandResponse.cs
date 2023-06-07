using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Responses
{
  public class BaseCommandResponse
  {
    public int Id { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; }
    public List<string> Errors { get; set; }
  }
}