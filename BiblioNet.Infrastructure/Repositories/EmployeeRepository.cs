using BiblioNet.Application.Interfaces.Repositories;
using BiblioNet.Core.Models;
using BiblioNet.Infrastructure.Helper;
using BiblioNet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.Core.Exceptions;

namespace BiblioNet.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private BiblioNetContext context;

        public EmployeeRepository(BiblioNetContext context)
        {
            this.context = context;
        }

        public Employee GetEmployee(string userName)
        {
            try
            {
                return Converter.fromEmployeeDALToEmployee(context.Employees.Where(u => u.UserName == userName).FirstOrDefault());
            }
            catch
            {
                throw new EmployeeNotFoundException();
            }
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return context.Employees.Select(Converter.fromEmployeeDALToEmployee);
        }
        public Employee GetEmployeeByID(int employeeId)
        {
            return context.Employees.Find(employeeId).fromEmployeeDALToEmployee();
        }
        public Employee GetEmployeeByName(string name)
        {
            EmployeeDAL emp = context.Employees.Where(t => t.UserName == name).FirstOrDefault();
            return emp.fromEmployeeDALToEmployee();
        }
        public Employee InsertEmployee(Employee employee)
        {
            return context.Employees.Add(employee.fromEmployeeToEmployeeDAL()).Entity.fromEmployeeDALToEmployee();
        }

        public void DeleteEmployee(int employeeID)
        {
            context.Employees.Remove(GetEmployeeByID(employeeID).fromEmployeeToEmployeeDAL());
        }
        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
