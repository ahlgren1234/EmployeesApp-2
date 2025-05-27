using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Controllers;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Xml.Linq;

namespace EmployeesApp.Web.Tests
{
    public class EmployeesControllersTests
    {
        [Fact]
        public void IndexTest()
        {
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(o => o.GetAll()).Returns([
                new Employee{ Id = 1, Name = "Test", Email = "test@mail.com" },
                new Employee { Id = 2, Name = "Test2", Email = "test2@mail.com" }
                ]);
            var controller = new EmployeesController(mockService.Object);

            var result = controller.Index();


            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            mockService.Verify(r => r.GetAll(), Times.Exactly(1));
        }


        [Fact]
        public void CreateHttpGetTest()
        {
            var mockService = new Mock<IEmployeeService>();
            var controller = new EmployeesController(mockService.Object);

            var result = controller.Create();


            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void CreateHttpPostTest()
        {
            var mockService = new Mock<IEmployeeService>();
            var controller = new EmployeesController(mockService.Object);
            var mockModel = new Mock<CreateVM>();
            var result = controller.Create(mockModel.Object);


            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);
            mockService.Verify(r => r.Add(It.IsAny<Employee>()), Times.Exactly(1));
        }



        [Fact]
        public void DetailsTest()
        {
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(o => o.GetById(1)).Returns(new Employee { Id= 1, Name = "Test", Email= "test@mail.com"});
            var controller = new EmployeesController(mockService.Object);

            var result = controller.Details(1);
            

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            mockService.Verify(r => r.GetById(1), Times.Exactly(1));
        }
    }
}
