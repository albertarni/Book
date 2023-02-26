using BiblioNet.Core.Models;
using BiblioNet.Dtos;
using BiblioNet.Models;

namespace BiblioNet.Helper
{
    public static class Converter
    {
      

        public static BookDTO fromBookToBookDTO(this Book book)
        {
            BookDTO bookDTO = new BookDTO
            {
                Title = book.Title,
                Description = book.Description,
                NumberOfCharacters = book.NumberOfCharacters
            };

            return bookDTO;
        }

        public static Book fromBookDTOToBook (this BookDTO bookDTO)
        {
            Book book = new Book
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                NumberOfCharacters = bookDTO.NumberOfCharacters,
            };

            return book;
        }

        public static EmployeeDTO fromEmployeeToEmplyeeDTO (this Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                UserName = employee.UserName,
                Password = employee.Password,
                Type= employee.Type,
            };
            return employeeDTO;
        }

        public static Employee fromEmployeeDTOToEmplyee(this EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                UserName = employeeDTO.UserName,
                Password = employeeDTO.Password,
                Type= employeeDTO.Type,
            };
            return employee;
        }
    }
}
