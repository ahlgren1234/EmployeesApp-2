using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using EmployeesApp.Web.Controllers;
using EmployeesApp.Web.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeesApp.Web.Tests
{
    public class EmployeesViewModelsTests
    {
        [Fact]
        public void CreateViewModelIsInvalidEmailTest()
        {
            var model = new CreateVM
            {
                Name = "name",
                Email= "email",
                BotCheck = 4
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();


            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            Assert.False(isValid); 

        }

        [Fact]
        public void CreateViewModelIsInvalidBotcheckTest()
        {
            var model = new CreateVM
            {
                Name = "name",
                Email = "email@mail.com",
                BotCheck = 3
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();


            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            Assert.False(isValid);

        }


        [Fact]
        public void CreateViewModelIsvalidTest()
        {
            var model = new CreateVM
            {
                Name = "name",
                Email = "email@mail.com",
                BotCheck = 4
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();


            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            Assert.True(isValid);

        }



    }
}
