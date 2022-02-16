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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind("Username, PassWord")] UserLogin user, bool? remem)
        {
            if (user.Username != null && user.PassWord != null)
            {
                var login = _con.UserLogins.FirstOrDefault(s => s.Username == user.Username && s.PassWord == user.PassWord);
                if (login != null)
                {
                    if (remem == true)
                    {
                        HttpContext.Session.SetString("SSLogin", user.Username);
                        HttpContext.Session.SetString("SSLogin", user.PassWord);
                    }
                    if (login.Roles == true)
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                }
                else
                {
                    ViewBag.Mess = "Username or password is incorrect";
                    return View();
                }
            }
            else
            {
                ViewBag.Mess = "Username or password is incorrect";
                return View();
            }
        }
    }
}
