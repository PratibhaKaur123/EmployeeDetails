using EmployeeDetails.Models;
using System.Net.Http;
using EmployeeDetailsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


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
    }
}
