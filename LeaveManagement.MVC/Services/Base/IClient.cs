namespace LeaveManagement.MVC.Services.Base
{
  public partial interface IClient
  {
    System.Net.Http.HttpClient HttpClient { get; }
  }
}
