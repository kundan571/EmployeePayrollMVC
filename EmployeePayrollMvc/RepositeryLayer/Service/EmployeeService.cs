using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositeryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositeryLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration iconfig;
        readonly SqlConnection connection = new SqlConnection();
        readonly string connectionstring;

        public EmployeeService(IConfiguration iconfig)
        {
            this.iconfig = iconfig;
            connectionstring = iconfig.GetConnectionString("DBConnection");
            connection.ConnectionString = connectionstring;
        }

        public EmployeeModel AddEmployee(EmployeeModel model)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spAddEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfilePic", model.ProfilePic);
                cmd.Parameters.AddWithValue("@Gender ", model.Gender);
                cmd.Parameters.AddWithValue("@Department", model.Department);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@StartDate ", model.StartDate);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                
                cmd.ExecuteNonQuery();
                return model;
               // connection.Close();
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

                SqlCommand cmd = new SqlCommand("spUpdateEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfilePic", model.ProfilePic);
                cmd.Parameters.AddWithValue("@Gender ", model.Gender);
                cmd.Parameters.AddWithValue("@Department", model.Department);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@StartDate ", model.StartDate);
                cmd.Parameters.AddWithValue("@Notes", model.Notes);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return model;
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
                List<EmployeeModel> lstemployee = new List<EmployeeModel>();
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeId = Convert.ToInt32(rdr["Employee_Id"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfilePic = rdr["ProfilePic"].ToString();
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = rdr.GetDateTime(6);
                    employee.Notes = rdr["Notes"].ToString();
                    lstemployee.Add(employee);
                }
                connection.Close();
                return lstemployee;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {


            try
            {
                EmployeeModel employee = new EmployeeModel();
                SqlCommand cmd = new SqlCommand("spGetEmployeesById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //EmployeeModel employee = new EmployeeModel();
                    employee.EmployeeId = Convert.ToInt32(rdr["Employee_Id"]);
                    employee.EmployeeName = rdr["EmployeeName"].ToString();
                    employee.ProfilePic = rdr["ProfilePic"].ToString();
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = rdr.GetDateTime(6);
                    employee.Notes = rdr["Notes"].ToString();
                }
                return employee;
                //rdr.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel Delete(int id)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@EmployeeId", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return employeeModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public EmployeeModel EmployeeLogin(EmployeeLoginModel empLoginModel)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                SqlCommand cmd = new SqlCommand("spEmployeeLogin", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                cmd.Parameters.AddWithValue("@EmployeeId", empLoginModel.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", empLoginModel.EmployeeName);

                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employeeModel.EmployeeId = Convert.ToInt32(rdr["Employee_Id"]);
                    employeeModel.EmployeeName = rdr["EmployeeName"].ToString();
                    employeeModel.ProfilePic = rdr["ProfilePic"].ToString();
                    employeeModel.Gender = Convert.ToString(rdr["Gender"]);
                    employeeModel.Department = rdr["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(rdr["Salary"]);
                    employeeModel.StartDate = rdr.GetDateTime(6);
                    employeeModel.Notes = rdr["Notes"].ToString();
                }
                return employeeModel;
                rdr.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ReviewModel AddReview(ReviewModel model)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("spAddReview", connection)
            {
                CommandType = CommandType.StoredProcedure,
            };
            cmd.Parameters.AddWithValue("@Comment", model.Comment);
            cmd.Parameters.AddWithValue("@ReviwId", model.ReviewId);

            cmd.ExecuteNonQuery();
            connection.Close();
            return model;
        }
    }
}
