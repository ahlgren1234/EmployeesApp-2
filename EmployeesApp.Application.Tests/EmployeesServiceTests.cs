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

            var employeeService = new EmployeeService(employeeRepository.Object);

            var emp= new Employee
            {
                Name = "Anders",
                Email = ""
            };

            employeeService.Add(emp);

            employeeRepository.Verify(repo => repo.Add(It.Is<Employee>(e => e.Name == "Anders" && e.Email == "")),Times.Once);
        }

        [Fact]
        public void GetAllEmplyoeesTest()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository
                .Setup(o => o.GetAll())
                .Returns([
                    new Employee{Id = 1, Name = "Test 1", Email = "Test1@email.com"},
                    new Employee{Id = 2, Name = "Test 2", Email = "Test2@email.com"},
                    new Employee{Id = 3, Name = "Test 3", Email = "Test3@email.com"}
                    ]);

            var employeeService = new EmployeeService (employeeRepository.Object);

            var result = employeeService.GetAll();

            Assert.Equal(3, result.Count());
            Assert.Equal("Test 1", result[0].Name);
        }


        [Fact]
        public void GetAllEmplyoeeByIdTest()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository
                .Setup(o => o.GetById(It.IsAny<int>()))
                .Returns(new Employee { Id= 1, Name = "test-1", Email= "test-1@mail.com"});

            var employeeService = new EmployeeService (employeeRepository.Object);

            var result = employeeService.GetById(1);

            Assert.Equal("test-1", result.Name);
      
        }

        [Fact]
        public void CheckIsVIPIsValidTest()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            var emp = new Employee
            {
                Name = "Anders",
                Email = "admin@mail.com"
            };


            var employeeService = new EmployeeService(employeeRepository.Object);

            var result = employeeService.CheckIsVIP(emp);

            Assert.True(result);
        }


        [Fact]
        public void CheckIsVIPIsInValidTest()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();

            var emp = new Employee
            {
                Name = "Anders",
                Email = "anders@mail.com"
            };


            var employeeService = new EmployeeService(employeeRepository.Object);

            var result = employeeService.CheckIsVIP(emp);

            Assert.False(result);
        }

    }
}
