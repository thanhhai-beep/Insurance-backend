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
        public ActionResult Login([Bind("Username, Pass")] UserLogin log)
        {
            var login = JsonConvert.DeserializeObject<IEnumerable<UserLogin>>(client.GetStringAsync(url).Result);
            var user = login.SingleOrDefault(e => e.Username.Equals(log.Username));
            if (user != null)
            {
                HttpContext.Session.SetString("UserLogin", log.Username);
                TempData["UserLogin"] = log.Username;
                if (user.PassWord.Equals(log.PassWord))
                {
                    //TempData["UserLogin"] = HttpContext.Session.GetString("UserLogin");
                    if (user.Roles == true)
                    {
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.mess = "Invalid password";
                }
            }
            else
            {
                ViewBag.mess = "Invalid UserName";
            }
            return View();
        }
    }
}
