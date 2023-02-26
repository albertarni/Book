using BiblioNet.Application.Interfaces.Services;
using BiblioNet.Dtos;
using BiblioNet.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using System.Security.Principal;

namespace BiblioNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        private readonly ClaimsPrincipal _principal;
        public EmployeesController(IEmployeeService employeeService, IConfiguration configuration, IPrincipal principal)
        {
            _principal = principal as ClaimsPrincipal;
            _configuration = configuration;
            _employeeService = employeeService;
        }


        // POST api/<EmployeesController>
        [HttpPost]
        [Route("login"), AllowAnonymous]
        public ActionResult Login(EmployeeDTO login)
        {
            string token;
            try
            {
                token = _employeeService.Login(login.Password, login.UserName, Response, _configuration);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            string token;
            try
            {
                token = _employeeService.RefreshToken(Request, _principal, _configuration, Response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(token);
        }

        [HttpPost("register"), AllowAnonymous]
        public ActionResult Register(EmployeeDTO employee)
        {
            try
            {
                _employeeService.Register(employee.fromEmployeeDTOToEmplyee());
            }
            catch (Exception e)
            {
                return BadRequest("The user name already exists");
            }

            return Ok();
        }
    }
}
