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
        private readonly InsuranceDBContext _con;
        public LoginController(InsuranceDBContext con)
        {
            _con = con;
        }
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(string username, string password)
        //{
        //    var login = JsonConvert.DeserializeObject<IEnumerable<UserLogin>>(client.GetStringAsync(url + "Security/" + username + password).Result);

        //    var user = login.SingleOrDefault(e => e.Username.Equals(username));
        //    if (user != null)
        //    {
        //        HttpContext.Session.SetString("SessionLogin", username);
        //        TempData["SessionLogin"] = username;
        //        if (user.PassWord.Equals(password))
        //        {
        //            TempData["SessionLogin"] = HttpContext.Session.GetString("SessionLogin");
        //        }
        //        else
        //        {
        //            ViewBag.mess = "Invalid password";
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.mess = "Invalid UserName";
        //    }
        //    return View();
        //}

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
