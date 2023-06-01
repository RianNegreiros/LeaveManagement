using System.Text;
using departments.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace departments.Controllers
{
  public class DepartmentController : Controller
  {
    public async Task<IActionResult> Index()
    {
      List<Department> list = new List<Department>();
      HttpClient client = new HttpClient();
      HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7249/api/departments");

      if (responseMessage.IsSuccessStatusCode)
      {
        var jstring = await responseMessage.Content.ReadAsStringAsync();
        list = JsonConvert.DeserializeObject<List<Department>>(jstring);
        return View(list);
      }
      else
      {
        return View(list);
      }
    }
    public IActionResult Add()
    {
      Department department = new Department();
      return View(department);
    }

    public async Task<IActionResult> Add(Department department)
    {
      if (ModelState.IsValid)
      {
        HttpClient client = new HttpClient();
        var jsondepartment = JsonConvert.SerializeObject(department);
        StringContent content = new StringContent(jsondepartment, Encoding.UTF8, "application/json");
        HttpResponseMessage message = await client.PostAsync("http://localhost:7249/api/departments", content);
        if (message.IsSuccessStatusCode)
        {
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("Error", "API Error");
          return View(department);
        }
      }
      else
      {
        return View(department);
      }
    }

    public async Task<IActionResult> Update(int Id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage message = await client.GetAsync("http://localhost:7249/api/departments/" + Id);
      if (message.IsSuccessStatusCode)
      {
        var jstring = await message.Content.ReadAsStringAsync();
        Department department = JsonConvert.DeserializeObject<Department>(jstring);
        return View(department);
      }
      else
      {
        return RedirectToAction("Add");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Update(Department department)
    {
        if (ModelState.IsValid)
        {
            HttpClient client = new HttpClient();
            var jsondepartment = JsonConvert.SerializeObject(department);
            StringContent content = new StringContent(jsondepartment, Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PutAsync("http://localhost:7249/api/departments/" + department.DepartmentId, content);
            if (message.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Error", "API Error");
                return View(department);
            }
        }
        else
        {
            return View(department);
        }
    }
  }
}
