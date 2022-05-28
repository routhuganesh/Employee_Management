using Employee_Management.Controllers;
using Employee_Management.Models;
using Employee_Management.Services;
using Employee_Management_Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_Tests.System.Controllers
{
    public class TestEmployeeController
    {
        private readonly Mock<IEmployeeService<Employee>> service;
        public TestEmployeeController()
        {
            service = new Mock<IEmployeeService<Employee>>();
        }
        [Fact]
        public void Getmethod_EmployeeObject_EmployeeWithspecificIdexists()
        {
            var employees = GetSampleEmployee();
            var firstEmployee = employees[0];
            service.Setup(x => x.Get(1))
                .Returns(firstEmployee);
            var controller = new EmployeeController(service.Object);
            //act
            var action = controller.Get((1));
            var result = action.Result as OkObjectResult;
            //assert
            result.Value.Should().BeEquivalentTo(firstEmployee);

        }
        [Fact]
        public void Getmethod_OkResult_EmployeeWithspecificIdexists()
        {
            var employees = GetSampleEmployee();
            var firstEmployee = employees[0];
            service.Setup(x => x.Get(1))
                .Returns(firstEmployee);
            var controller = new EmployeeController(service.Object);
            //act
            var action = controller.Get((1));
            var result = action.Result as OkObjectResult;
            //assert
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void Getmethod_shouldReturnBadRequest_EmployeeWithIDNotExists()
        {
            //arrange
            var employees = GetSampleEmployee();
            var firstEmployee = employees[0];
            service.Setup(x => x.Get(1))
                .Returns(firstEmployee);
            var controller = new EmployeeController(service.Object);

            //act
            var actionResult = controller.Get(2);

            //assert
            var result = actionResult.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void GetCount_ShouldreturnOkREsult_IfRunsSuccessful()
        {
            //arrange
            var employee = GetSampleEmployee();
            int num=2;

            service.Setup(x => x.GetCount(1))
                .Returns(num);
            var controller = new EmployeeController(service.Object);

            //act
            var actionResult = controller.GetCount(1);
            var result = actionResult.Result as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetCount_ShouldreturnCount_SumofEmployee()
        {
            //arrange
            var employee = GetSampleEmployee();
            int num = 2;

            service.Setup(x => x.GetCount(1))
                .Returns(num);
            var controller = new EmployeeController(service.Object);

            //act
            var actionResult = controller.GetCount(1);
            var result = actionResult.Result as OkObjectResult;

            //assert
            result.Value.Should().BeEquivalentTo(num);
        }


        private List<Employee> GetSampleEmployee()
        {
            List<Employee> output = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Ganesh",
                    Adress = "Andhra",
                    DepartmentId= 1
                },
                new Employee
                {
                    EmployeeId = 2,
                    Name = "Rohit",
                    Adress = "Mumbai",
                    DepartmentId= 2
                },
                new Employee
                {
                    EmployeeId = 3,
                    Name = "virat",
                    Adress = "Delhi",
                    DepartmentId= 1
                }

            };
            return output;
        }
        

    }

}

