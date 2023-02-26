using BiblioNet.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BiblioNet.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        public Employee GetEmployee(string userName);
        public void Insert(Employee employee);

        public Employee GetEmployeeByName(string name);
        public void Register(Employee employee);
        public string Login(string password, string userName, HttpResponse Response, IConfiguration configuration);
        public string RefreshToken(HttpRequest Request, ClaimsPrincipal principal, IConfiguration configuration, HttpResponse Response);
    }
}
