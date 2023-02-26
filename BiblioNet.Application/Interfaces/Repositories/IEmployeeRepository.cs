using BiblioNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioNet.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IDisposable
    {
        public IEnumerable<Employee> GetEmployee();
        public Employee GetEmployee(string userName);
        public Employee GetEmployeeByID(int employeeId);
        public Employee InsertEmployee(Employee employee);
        public void DeleteEmployee(int employeeID);
        public void UpdateEmployee(Employee employee);
        public Employee GetEmployeeByName(string name);

        public void Save();
    }
}
