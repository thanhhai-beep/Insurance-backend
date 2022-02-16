using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult EmpList()
        {
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees/").Result);
            return View(emp);
        }
        public ActionResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmp(Employee emp)
        {
            try
            {
                var model = client.PostAsJsonAsync<Employee>(url + "Employees/", emp).Result;
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
            return View();
        }
        public ActionResult EditEmp(int? id)
        {
            var emp = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + "Employees/" + id).Result);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmp(int id, Employee emp)
        {
            try
            {
                var model = client.PutAsJsonAsync<Employee>(url + "Employees/" + id, emp).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View();
        }

        public IActionResult FeedBackList()
        {
            var fb = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(client.GetStringAsync(url + "Feedbacks/").Result);
            return View(fb);
        }
        public IActionResult HospitalInfoesList()
        {
            var hp = JsonConvert.DeserializeObject<IEnumerable<HospitalInfo>>(client.GetStringAsync(url + "HospitalInfoes/").Result);
            return View(hp);
        }
        public IActionResult AddHp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHp(HospitalInfo hp)
        {
            try
            {
                var model = client.PostAsJsonAsync<HospitalInfo>(url + "HospitalInfoes/", hp).Result;
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
            return View();
        }
    }
}
