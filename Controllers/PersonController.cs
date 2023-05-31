using departments.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace departments.Controllers
{
    public class PersonController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:5001/api/persons");

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
            return View();
        }
    }
}
