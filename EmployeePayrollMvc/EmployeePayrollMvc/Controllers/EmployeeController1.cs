using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMvc.Controllers
{
    public class EmployeeController1 : Controller
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController1(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            /*List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = employeeBL.GetAllEmployees().ToList();*/
            return View();
        }

        // Add Employees
        [HttpGet]
        [Route("employee/add")]
        public IActionResult AddEmployee()
        {

            return View();
        }
        [HttpPost]
        [Route("employee/add")]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                employeeBL.AddEmployee(employeeModel);
                return View(employeeModel);
               // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("employee/details")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                List<EmployeeModel> employees = new List<EmployeeModel>();
                employees = employeeBL.GetAllEmployees().ToList();
                return View(employees); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("employee/detail/id")]
        public IActionResult GetEmployeeById(int id)
        {
            id = (int)HttpContext.Session.GetInt32("Employee_Id");
            if (id == 0)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = employeeBL.GetEmployeeById(id);

            if(id == 0)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // For Update
        [HttpGet]
        [Route("employee/update")]
        public IActionResult UpdateEmployee(int id)
        {
            EmployeeModel model = employeeBL.GetEmployeeById(id);
            ViewData["EmpName"] = model.EmployeeName;
            return View(model);
        }
        [HttpPost]
        [Route("employee/update")]
        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            try
            {
                employeeBL.UpdateEmployee(model);
                return View(model);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // For Delete Employee

        [HttpGet]
      //  [Route("employee/delete")]
        public IActionResult Delete(int id)
        {
            try
            {

                EmployeeModel model = employeeBL.GetEmployeeById(id);
                ViewData["EmployeeName"] = model.EmployeeName;
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost, ActionName("Delete")]
       // [Route("employee/delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {

                employeeBL.Delete(id);
                return RedirectToAction("GetAllEmployee");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // EmployeeLogin
        [HttpGet]
        [Route("employee/login")]
        public IActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        [Route("employee/login")]
        public IActionResult EmployeeLogin(EmployeeLoginModel employeeLogin)
        {
            try
            {
                var result = employeeBL.EmployeeLogin(employeeLogin);
                HttpContext.Session.SetInt32("Employee_Id", result.EmployeeId);
                if(result != null)
                {
                    return RedirectToAction("GetEmployeeById");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Details");
                    RedirectToAction("EmployeeLogin");
                }
                return View(employeeLogin);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult AddReview()
        {
            return View();
        }
        public IActionResult AddReview(ReviewModel model)
        {
            try
            {
                employeeBL.AddReview(model);
                return View(model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
