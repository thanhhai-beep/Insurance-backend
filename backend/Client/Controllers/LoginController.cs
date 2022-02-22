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
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        private readonly InsuranceDBContext _con;
        private readonly INotyfService _notyf;
        public LoginController(InsuranceDBContext con, INotyfService notyf)
        {
            _con = con;
            _notyf = notyf;
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
                    HttpContext.Session.SetString("SSImage", login.Image);
                    HttpContext.Session.SetInt32("EmpId", login.EmpId);
                    if (login.IsAdmin == 1)
                    {
                        _notyf.Success("Welcome" + login.Fname + login.Lname, 5);
                        return RedirectToAction("DashBoard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("HomePages", "Home");
                    }
                }
                else
                {
                    _notyf.Error("Your username or password is invalid",5);
                    return View();
                }
            }
            else
            {
                _notyf.Error("Your username or password is invalid",5);
                return View();
            }
        }
        public ActionResult Profile(int? id)
        {
            var res = JsonConvert.DeserializeObject<List<ProfileResult>>(client.GetStringAsync(url + "Security/" + id).Result);
            ViewData["emp"] = res;
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("SSLogin");
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("EmpId");
            return RedirectToAction("Login");
        }
    }
}
