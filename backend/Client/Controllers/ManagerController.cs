using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class ManagerController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        //Policy
        public IActionResult Policy(string searchname)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var policy = JsonConvert.DeserializeObject<IEnumerable<Policy>>(client.GetStringAsync(url + "Policies?searchname=" + searchname).Result);
            return View(policy);
        }
        public ActionResult AddPolicy()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var cn = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            return View(cn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPolicy(Policy policy)
        {
            try
            {
                var model = client.PostAsJsonAsync<Policy>(url + "Policies/", policy).Result;
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
        public ActionResult EditPolicy(int? id)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var cn = JsonConvert.DeserializeObject<Policy>(client.GetStringAsync(url + "Policies/" + id).Result);
            return View(cn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPolicy(int id, Policy cn)
        {
            try
            {
                var model = client.PutAsJsonAsync<Policy>(url + "Policies/" + id, cn).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Company");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View();
        }
        public ActionResult DelPolicy(int id)
        {
            var model = client.DeleteAsync(url + "Policies/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                TempData["Mess"] = "Deleted successfull!!!!!!!!!!!!!!!";
            }
            return RedirectToAction("Policy");
        }
    }
}
