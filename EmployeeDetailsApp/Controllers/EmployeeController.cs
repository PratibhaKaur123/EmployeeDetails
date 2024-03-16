using EmployeeDetails.Models;
using System.Net.Http;
using EmployeeDetailsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EmployeeDetailsApp.Controllers
{
    public class EmployeeController : Controller
    {
        
        Uri baseAddress = new Uri("https://localhost:7008/api");
        private readonly HttpClient _client;
        public EmployeeController()
        {
                _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

             HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/EmployeeDetails/GetEmployees");
            //HttpResponseMessage response = await _client.GetAsync("api/Employee/GetEmployees");
            if (response.IsSuccessStatusCode) { 
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
                
            }   
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create() {



            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/EmployeeDetails/PostEmployee", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employee details Added Successfully";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
