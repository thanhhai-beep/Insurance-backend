﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notify;

        public ManagerController(INotyfService notify)
        {
            _notify = notify;
        }


        //Policy
        public IActionResult Policy(string searchname)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var policy = JsonConvert.DeserializeObject<List<ProfileResult>>(client.GetStringAsync(url + "Policies?searchname=" + searchname).Result);
            ViewData["policy"] = policy;
            return View();
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
                    _notify.Success("Create Policy Success", 5);
                }
                else
                {
                    _notify.Error("Create policy Failed", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("Policy");
        }

        
        public ActionResult DetailPolicy(int? id)
        {
            var plc = JsonConvert.DeserializeObject<Policy>(client.GetStringAsync(url + "Policies/" + id).Result);
            return View(plc);
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
                    _notify.Success("Update Policy Success", 5);
                    return RedirectToAction("Policy");
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
                _notify.Success("Delete Policy Success", 5);
            }
            return RedirectToAction("Policy");
        }

        // Request 
        public ActionResult Request()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var request = JsonConvert.DeserializeObject<List<ProfileResult>>(client.GetStringAsync(url + "RequestDetails/").Result);
            ViewData["request"] = request;
            return View();
        }
        public ActionResult updateStatus(RequestDetail rq)
        {
            var rqId = rq.Id;
            try
            {
                var model = client.PutAsJsonAsync<RequestDetail>(url + "RequestDetails/" + rqId,rq).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Update Request Success", 5);
                    return RedirectToAction("Request");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View();
        }

        public ActionResult DelRequest(int id)
        {
            var model = client.DeleteAsync(url + "RequestDetails/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                _notify.Error("Delete Request Success", 5);
            }
            return RedirectToAction("Request");
        }

    }
}
