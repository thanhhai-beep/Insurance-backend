using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        private readonly InsuranceDBContext _con;
        public LoginController(InsuranceDBContext con)
        {
            _con = con;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (email != null && password != null)
            {
                var login = _con.Employees.FirstOrDefault(s => s.Email == email && s.Password == password);
                if (login != null)
                {
                    HttpContext.Session.SetString("SSLogin", email);
                    HttpContext.Session.SetString("Username", login.Fname + login.Lname);
                    HttpContext.Session.SetInt32("EmpId", login.EmpId);
                    if (login.IsAdmin == 1)
                    { 
                        return RedirectToAction("DashBoard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("HomePages", "Home");
                    }
                }
                else
                {
                    ViewBag.Mess = "Username or password is";
                    return View();
                }
            }
            else
            {
                ViewBag.Mess = "Username or password is incorrect";
                return View();
            }
        }
        public ActionResult Profile(int? id)
        {
            var emp = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + "Employees/" + id).Result);
            ViewData["emp"] = emp;
            return View();
        }
    }
}
