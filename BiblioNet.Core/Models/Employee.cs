using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Models;

namespace BiblioNet.Core.Models
{
    public class Employee
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public RefreshToken refreshToken { get; set; }
        public Employee()
        {
            refreshToken = new RefreshToken();
        }
    }
}
