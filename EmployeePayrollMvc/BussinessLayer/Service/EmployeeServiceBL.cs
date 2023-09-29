using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositeryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class EmployeeServiceBL : IEmployeeBL
    {
        // using Repo level interface
        private readonly IEmployeeService employeeServiceRepo;
        public EmployeeServiceBL(IEmployeeService employeeRepo)
        {
            this.employeeServiceRepo = employeeRepo;
        }

        public EmployeeModel AddEmployee(EmployeeModel model)
        {
            try
            {
                return employeeServiceRepo.AddEmployee(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel UpdateEmployee(EmployeeModel model)
        {
            try
            {
                return employeeServiceRepo.UpdateEmployee(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {

            try
            {
                return employeeServiceRepo.GetAllEmployees();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public EmployeeModel GetEmployeeById(int EmpId)
        {
            try
            {
                return employeeServiceRepo.GetEmployeeById(EmpId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel Delete(int EmpId)
        {
            try
            {
                return employeeServiceRepo.Delete(EmpId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel EmployeeLogin(EmployeeLoginModel LoginModel)
        {
            try
            {
                return employeeServiceRepo.EmployeeLogin(LoginModel);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }
        public ReviewModel AddReview(ReviewModel model)
        {
            try
            {
                return employeeServiceRepo.AddReview(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
