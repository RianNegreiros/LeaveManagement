using System.Text;
using departments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace departments.Controllers
{
  public class PersonController : Controller
  {
    public async Task<IActionResult> Index()
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:7249/api/persons");

      if (responseMessage.IsSuccessStatusCode)
      {
        var jstring = await responseMessage.Content.ReadAsStringAsync();
        List<PersonALL> list = JsonConvert.DeserializeObject<List<PersonALL>>(jstring);
        return View(list);
      }
      else
      {
        return View(new List<PersonALL>());
      }
    }
    public IActionResult Add()
    {
      Person person = new Person();
      return View(person);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Person person)
    {
      if (ModelState.IsValid)
      {
        HttpClient client = new HttpClient();
        var jsonperson = JsonConvert.SerializeObject(person);
        StringContent content = new StringContent(jsonperson, Encoding.UTF8, "application/json");
        HttpResponseMessage message = await client.PostAsync("http://localhost:7249/api/persons", content);
        if (message.IsSuccessStatusCode)
        {
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("Error", "API Error");
          return View(person);
        }
      }
      else
      {
        return View(person);
      }
    }
    public async Task<IActionResult> Update(int Id)
    {
      HttpClient client = new HttpClient();
      HttpResponseMessage message = await client.GetAsync("http://localhost:7249/api/persons/" + Id);

      if (message.IsSuccessStatusCode)
      {
        var jstring = await message.Content.ReadAsStringAsync();
        Person person = JsonConvert.DeserializeObject<Person>(jstring);
        return View(person);
      }
      else
      {
        return RedirectToAction("Add");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Update(Person person)
    {
      if (ModelState.IsValid)
      {
        HttpClient client = new HttpClient();
        var jsonperson = JsonConvert.SerializeObject(person);
        StringContent content = new StringContent(jsonperson, Encoding.UTF8, "application/json");
        HttpResponseMessage message = await client.PutAsync("http://localhost:7249/api/persons/", content);
        if (message.IsSuccessStatusCode)
        {
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("Error", "API Error");
          return View(person);
        }
      }
      else
      {
        return View(person);
      }
    }
  }
}
