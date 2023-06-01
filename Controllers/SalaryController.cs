using departments.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace departments.Controllers
{
  public class SalaryController : Controller
  {
    public async Task<IActionResult> Index()
    {
      List<Salary> list = new List<Salary>();
      HttpClient client = new HttpClient();
      HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:7249/api/salaries");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jstring = await responseMessage.Content.ReadAsStringAsync();
        list = JsonConvert.DeserializeObject<List<Salary>>(jstring);
        return View(list);
      }
      else
      {
        return View(list);
      }
    }

    public async Task<IActionResult> Delete(int Id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage message = await client.DeleteAsync("http://localhost:7249/api/salaries/" + Id);
      if (message.IsSuccessStatusCode)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
  }
}
