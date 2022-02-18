using Client.Models;
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
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HomePages()
        {
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

        // Request Detail
        public ActionResult EmpRequest()
        {
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees/").Result);
            var policy = JsonConvert.DeserializeObject<IEnumerable<Policy>>(client.GetStringAsync(url + "Policies/").Result);
            var company = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            ViewData["data"] = emp;
            ViewData["policy"] = policy;
            ViewData["company"] = company;
            return View(ViewData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmpRequest(RequestDetail rq)
        {
            try
            {
                var model = client.PostAsJsonAsync<RequestDetail>(url + "RequestDetails/", rq).Result;
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
