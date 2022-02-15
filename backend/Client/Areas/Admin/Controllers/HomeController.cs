using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly string url = "http://localhost:40316/api/Employee/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmpList()
        {
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url).Result);
            return View(emp);
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Employee employee)
        {
            //var name = HttpContext.Session.GetString("UserLogin");
            //if (name == null)
            //{
            //    return RedirectToAction("Login");
            //}
            try
            {
                var model = client.PostAsJsonAsync<Employee>(url, employee).Result;
                if (model.IsSuccessStatusCode)
                {
                    ViewBag.Mess = "Inserted successfull!!";
                }
                else
                {
                    ViewBag.Mess = "Inserted faild!!";
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
