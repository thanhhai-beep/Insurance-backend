using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Client.Models;

namespace Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        //private readonly string url = "http://localhost:40316/api/";
        //HttpClient client = new HttpClient();
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //public IActionResult Dashboard()
        //{
        //    return View();
        //}
        //public IActionResult EmpList()
        //{
        //    //var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees/").Result);
        //    return View();
        //}
        //public IActionResult AddEmp()
        //{
        //    return View();
        //}
    }
}
