using AspNetCoreHero.ToastNotification.Abstractions;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        private readonly INotyfService _notify;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf)
        {
            _logger = logger;
            _notify = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult HomePages()
        {
            var policy = JsonConvert.DeserializeObject<IEnumerable<Policy>>(client.GetStringAsync(url + "Admin/").Result);
            var company = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            ViewData["policy"] = policy;
            ViewData["company"] = company;
            return View();
        }
        public ActionResult UpdatePro(int? id)
        {
            var cus = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + "Employees/" + id).Result);
            return View(cus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePro(int id, Employee emp)
        {
            try
            {
                var model = client.PutAsJsonAsync<Employee>(url + "Employees/" + id, emp).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Update Employee Success", 5);
                    return RedirectToAction("HomePages");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View();
        }
        public ActionResult EmpFeedback()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmpFeedback(Feedback fb)
        {
            try
            {
                var model = client.PostAsJsonAsync<Feedback>(url + "Feedbacks/", fb).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Send Feedback Success",5);
                }
                else
                {
                    _notify.Error("Send Feedback Error", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("HomePages");
        }

        // Request Detail
        public ActionResult EmpRequest()
        {
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees/").Result);
            var policy = JsonConvert.DeserializeObject<IEnumerable<Policy>>(client.GetStringAsync(url + "Policies/").Result);
            var company = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            ViewData["data"] = emp;
            ViewData["policy"] = policy;
            ViewData["company"] = company;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmpRequest(RequestDetail rq)
        {
            rq.RequestDate = System.DateTime.Now;
            try
            {
                var model = client.PostAsJsonAsync<RequestDetail>(url + "RequestDetails/", rq).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Send Request Success",5);
                }
                else
                {
                    _notify.Error("Send Request Failed", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("HomePages");
        }
    }
}
