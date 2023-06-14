using LeaveManagement.MVC.Models;

namespace LeaveManagement.MVC.Contracts
{
  public interface IAuthenticationService
  {
    Task<bool> Authenticate(string email, string password);
    Task<bool> Register(RegisterVM registration);
    Task Logout();
  }
}
