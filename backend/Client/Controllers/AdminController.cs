using AspNetCoreHero.ToastNotification.Abstractions;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly string url = "http://localhost:40316/api/";
        HttpClient client = new HttpClient();
        private readonly INotyfService _notify;

        public AdminController(INotyfService notify)
        {
            _notify = notify;
        }

        public ActionResult Dashboard()
        {
            //var list = JsonConvert.DeserializeObject(client.GetStringAsync(url + "Security/").Result);
            //ViewData["list"] = list;
            return View();
        }

        //Employee
        public IActionResult EmpList(string searchname)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login","Login");
            }
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees?searchname=" + searchname).Result);
            return View(emp);
        }

        //emp details
        public ActionResult ViewEmp(int id)
        {
            var emp = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + "Employees/" + id).Result);
            return View(emp);
        }
        //end emp details

        public ActionResult AddEmp()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var cn = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            ViewData["company"] = cn;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmp(Employee emp, IFormFile file)
        {
            try
            {
                if(file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string file_path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/imageEmp", filename);
                    using (var stream = new FileStream(file_path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    emp.Image = "imageEmp/" + filename;
                }
                var model = client.PostAsJsonAsync<Employee>(url + "Employees/", emp).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Create Employee Success", 5);
                }
                else
                {
                    _notify.Error("Create Failed", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("EmpList");
        }
        public ActionResult DelEmp(int id)
        {
            var model = client.DeleteAsync(url + "Employees/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                _notify.Success("Delete Employee Success", 5);
            }
            return RedirectToAction("EmpList");
        }

        //Feedback
        public IActionResult FeedBackList()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var fb = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(client.GetStringAsync(url + "Feedbacks/").Result);
            return View(fb); 
        }
        public ActionResult DelFeedBack(int id)
        {
            var model = client.DeleteAsync(url + "Feedbacks/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                _notify.Success("Delete Feedback Success", 5);
            }
            return RedirectToAction("FeedBackList");
        }
        //HospitalInfo
        public IActionResult HospitalInfoesList(string searchname)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var hp = JsonConvert.DeserializeObject<IEnumerable<HospitalInfo>>(client.GetStringAsync(url + "HospitalInfoes?searchname=" + searchname).Result);
            return View(hp);
        }
        public IActionResult AddHp()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHp(HospitalInfo hp)
        {
            try
            {
                var model = client.PostAsJsonAsync<HospitalInfo>(url + "HospitalInfoes/", hp).Result;
                if (model.IsSuccessStatusCode) 
                {
                    _notify.Success("Create Hospital Success", 5);
                }
                else
                {
                    _notify.Error("Create Hospital Failed", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("HospitalInfoesList");
        }


        public ActionResult HpDetail(int? id)
        {
            var hp = JsonConvert.DeserializeObject<HospitalInfo>(client.GetStringAsync(url + "HospitalInfoes/" + id).Result);
            return View(hp);
        }


        public ActionResult EditHp(int? id)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var hp = JsonConvert.DeserializeObject<HospitalInfo>(client.GetStringAsync(url + "HospitalInfoes/" + id).Result);
            return View(hp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHp(int id, HospitalInfo hp)
        {
            try
            {
                var model = client.PutAsJsonAsync<HospitalInfo>(url + "HospitalInfoes/" + id, hp).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Update Hospital Success", 5);
                    return RedirectToAction("HospitalInfoesList");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View(); 
        }
        public ActionResult DelHp(int? id)
        {
            var model = client.DeleteAsync(url + "HospitalInfoes/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                _notify.Success("Delete Hospital Success");
            }
            return RedirectToAction("HospitalInfoesList");
        }
        //Company
        public IActionResult Company(string searchname)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var cn = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails?searchname=" + searchname).Result);
            return View(cn);
        }
        public IActionResult AddCompany()
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompany(CompanyDetail cn)
        {
            try
            {
                var model = client.PostAsJsonAsync<CompanyDetail>(url + "CompanyDetails/", cn).Result;
                if (model.IsSuccessStatusCode)
                {
                    _notify.Success("Create Company Success", 5);
                }
                else
                {
                    _notify.Error("Create Company Failed", 5);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("Company");
        }
        public ActionResult EditCompany(int? id)
        {
            var name = HttpContext.Session.GetString("SSLogin");
            if (name == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var cn = JsonConvert.DeserializeObject<CompanyDetail>(client.GetStringAsync(url + "CompanyDetails/" + id).Result);
            return View(cn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompany(int id, CompanyDetail cn)
        {
            try
            {
                var model = client.PutAsJsonAsync<CompanyDetail>(url + "CompanyDetails/" + id, cn).Result;
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
        public ActionResult DelCompany(int id)
        {
            var model = client.DeleteAsync(url + "CompanyDetails/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                _notify.Success("Delete Company Success", 5);
            }
            return RedirectToAction("Company");
        }
    }
}
