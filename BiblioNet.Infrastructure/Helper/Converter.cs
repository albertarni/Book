
using BiblioNet.Core.Models;
using BiblioNet.Infrastructure.Models;

namespace BiblioNet.Infrastructure.Helper
{
    public static class Converter
    {
        public static BookDAL fromBookToBookDAL (this Book book)
        {
            BookDAL bookDAL = new BookDAL
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,

            };

            return bookDAL;
            
        }

        public static Book fromBookDALToBook (this BookDAL bookDAL)
        {
            Book book = new Book()
            {
                Id = bookDAL.Id,
                Title = bookDAL.Title,
                Description = bookDAL.Description,
                NumberOfCharacters = bookDAL.Title.Length
            };

            return book;
        }

        public static Employee fromEmployeeDALToEmployee (this EmployeeDAL employeeDAL)
        {
            Employee employee = new Employee()
            {
                UserName = employeeDAL.UserName,
                Password = employeeDAL.Password,
                Type = employeeDAL.Type
            };

            return employee;
        }

        public static EmployeeDAL fromEmployeeToEmployeeDAL(this Employee employee)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL()
            {
                UserName = employee.UserName,
                Password = employee.Password,
                Type = employee.Type
            };

            return employeeDAL;
        }

    }
}
