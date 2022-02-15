using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly InsuranceDBContext _con;
        public LoginController(InsuranceDBContext con)
        {
            _con = con;
        }
        private readonly string url = "http://localhost:40316/api/UserLogin/";
        HttpClient client = new HttpClient();
        [HttpGet]
        public ActionResult Login()
        {
            var name = HttpContext.Session.GetString("UserLogin");
            if (name != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var login = _con.UserLogins.FirstOrDefault(s => s.Username == username && s.PassWord == password);
                if (login != null)
                {
                    TempData["UserLogin"] = "success";
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    TempData["UserLogin"] = "falseeee";
                    return RedirectToAction("HomePage", "Home");
                }
            }
            else
            {
                TempData["UserLogin"] = "false";
                return RedirectToAction("HomePage", "Home");
            }
        }
    }
}
