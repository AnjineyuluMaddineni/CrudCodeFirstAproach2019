using CrudCodeFirstAproach2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrudCodeFirstAproach2019.Controllers
{
    public class DemoController : Controller
    {
        EmpDataContext objDataContext = new EmpDataContext();
        // GET: Demo
        public ActionResult EmpDetails()
        {
            return View(objDataContext.employees.ToList());
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Employee objEmp)
        {
            objDataContext.employees.Add(objEmp);
            objDataContext.SaveChanges();
            return View();
        }
        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
            var data = objDataContext.employees.Find(objEmp.EmpId);
            if (data != null)
            {
                data.Name = objEmp.Name;
                data.Address = objEmp.Address;
                data.Email = objEmp.Email;
                data.MobileNo = objEmp.MobileNo;
            }
            objDataContext.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            using (EmpDataContext emp = new EmpDataContext())
            {
                return View(emp.employees.Where(x=>x.EmpId==id).FirstOrDefault());
            }
            
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                using (EmpDataContext emp=new EmpDataContext())
                {
                    Employee employee = emp.employees.Where(x => x.EmpId == id).FirstOrDefault();
                    emp.employees.Remove(employee);
                    emp.SaveChanges();
                }
                return RedirectToAction("EmpDetails");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        protected override void Dispose(bool disposing)
        {
            objDataContext.Dispose();
            base.Dispose(disposing);
        }
    }
}