using LeaveManagement.Application.Models;

namespace LeaveManagement.Application.Contracts.Infrastructure
{
  public interface IEmailSender
  {
    Task<bool> SendEmail(Email email);
  }
}