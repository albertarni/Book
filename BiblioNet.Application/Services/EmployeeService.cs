using BiblioNet.Application.Interfaces.Repositories;
using BiblioNet.Application.Interfaces.Services;
using BiblioNet.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Application.Helper;
using Timesheet.Core.Exceptions;

namespace BiblioNet.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public Employee GetEmployee(string userName)
        {
            return EmployeeRepository.GetEmployee(userName);
        }

        public Employee GetEmployeeByName(string name)
        {
            var employee = EmployeeRepository.GetEmployeeByName(name);
            return employee;

        }
        public string Login(string password, string userName, HttpResponse Response, IConfiguration configuration)
        {
            //String hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Employee employee = new Employee();
            try
            {
                employee = GetEmployee(userName);
            }
            catch (EmployeeNotFoundException e)
            {
                throw new EmployeeNotFoundException("Username or password is incorrect");
            }
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Username or password is incorrect");
            }
            if (!BCrypt.Net.BCrypt.Verify(password, employee.Password))
            {
                throw new EmployeeNotFoundException("Password is incorrect");
            }
            string token = TokenHelper.CreateToken(employee, configuration);
            var refreshToken = TokenHelper.GenerateRefreshToken();
            TokenHelper.SetRefreshToken(refreshToken, employee, Response);
            return token;
        }
        public void Register(Employee employee)
        {
            employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
            try
            {
                Insert(employee);
            }
            catch (Exception e)
            {
                throw new Exception("The user name already exists");
            }

        }

        public string RefreshToken(HttpRequest Request, ClaimsPrincipal principal, IConfiguration configuration, HttpResponse Response)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            Employee employee;
            if (refreshToken != null)
            {
                var employeeName = principal?.FindFirst(ClaimTypes.Name).Value;
                employee = GetEmployeeByName(employeeName);


                //if (employee.refreshToken.ExpireDate < DateTime.Now)
                //{
                //    throw new Exception("Token expired");
                //}
            }
            else
            {
                throw new Exception("Invalid refresh token.");
            }
            string token = TokenHelper.CreateToken(employee, configuration);
            var newRefreshToken = TokenHelper.GenerateRefreshToken();
            TokenHelper.SetRefreshToken(newRefreshToken, employee, Response);
            return token;
        }
        public void Insert(Employee employee)
        {
            EmployeeRepository.InsertEmployee(employee);
            Save();
        }
        public void Save()
        {
            EmployeeRepository.Save();
        }
    }
}
