using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public EmployeeModel AddEmployee(EmployeeModel model);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeById(int EmpId);
        public EmployeeModel Delete(int EmpId);
        public EmployeeModel UpdateEmployee(EmployeeModel model);
        public ReviewModel AddReview(ReviewModel model);
        public EmployeeModel EmployeeLogin(EmployeeLoginModel model);
    }
}
