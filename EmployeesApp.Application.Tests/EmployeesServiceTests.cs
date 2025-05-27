using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;
using Moq;
namespace EmployeesApp.Application.Tests
{
    public class EmployeesServiceTests
    {
        [Fact]
        public void AddEmpoyeeTest()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(repo => repo.Add(It.IsAny<Employee>()));
                 // Mocking ID assignment
            /*
                Add = (Employee employee) => { /* Mock implementation  },
                GetAll = () => new Employee[] { /* Mock data  },
                GetById = (int id) => new Employee { Id = id, Name = "Mock Employee", Email = "
                };
                */
            var employeeService = new EmployeeService(employeeRepository.Object);

            var emp= new Employee
            {
                Name = "Anders",
                Email = ""
            };

            employeeService.Add(emp);

            employeeRepository.Verify(repo => repo.Add(It.Is<Employee>(e => e.Name == "Anders" && e.Email == "")),Times.Once);
        }
    }
}
