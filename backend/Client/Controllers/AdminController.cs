﻿using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public IActionResult Dashboard()
        {
            return View();
        }

        //Employee
        public IActionResult EmpList(string searchname)
        {
            var emp = JsonConvert.DeserializeObject<IEnumerable<Employee>>(client.GetStringAsync(url + "Employees?=searchname" + searchname).Result);
            return View(emp);
        }
        public ActionResult AddEmp()
        {
            var cn = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails/").Result);
            return View(cn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmp(Employee emp)
        {
            try
            {
                var model = client.PostAsJsonAsync<Employee>(url + "Employees/", emp).Result;
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
        public ActionResult EditEmp(int? id)
        {
            var emp = JsonConvert.DeserializeObject<Employee>(client.GetStringAsync(url + "Employees/" + id).Result);
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmp(int id, Employee emp)
        {
            try
            {
                var model = client.PutAsJsonAsync<Employee>(url + "Employees/" + id, emp).Result;
                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }
            catch
            {
                return BadRequest();
            }
            return View();
        }
        public ActionResult DelEmp(int id)
        {
            var model = client.DeleteAsync(url + "Employees/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                TempData["Mess"] = "Deleted successfull!!!!!!!!!!!!!!!";
            }
            return RedirectToAction("EmpList");
        }

        //Feedback
        public IActionResult FeedBackList()
        {
            var fb = JsonConvert.DeserializeObject<IEnumerable<Feedback>>(client.GetStringAsync(url + "Feedbacks/").Result);
            return View(fb); 
        }
        public ActionResult DelFeedBack(int id)
        {
            var model = client.DeleteAsync(url + "Feedbacks/" + id).Result;
            if (model.IsSuccessStatusCode)
            {
                TempData["Mess"] = "Deleted successfull!!!!!!!!!!!!!!!";
            }
            return RedirectToAction("FeedBackList");
        }
        //HospitalInfo
        public IActionResult HospitalInfoesList(string searchname)
        {
            var hp = JsonConvert.DeserializeObject<IEnumerable<HospitalInfo>>(client.GetStringAsync(url + "HospitalInfoes?searchname=" + searchname).Result);
            return View(hp);
        }
        public IActionResult AddHp()
        {
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
        public ActionResult EditHp(int? id)
        {
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
                TempData["Mess"] = "Deleted successfull!!!";
            }
            return RedirectToAction("HospitalInfoesList");
        }
        //Company
        public IActionResult Company(string searchname)
        {
            var cn = JsonConvert.DeserializeObject<IEnumerable<CompanyDetail>>(client.GetStringAsync(url + "CompanyDetails?=searchname" + searchname).Result);
            return View(cn);
        }
        public IActionResult AddCompany()
        {
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
        public ActionResult EditCompany(int? id)
        {
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
                TempData["Mess"] = "Deleted successfull!!!!!!!!!!!!!!!";
            }
            return RedirectToAction("Company");
        }
    }
}