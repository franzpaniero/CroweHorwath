using System;
using CroweHorwath.HelloWorld.Api.Controllers;
using CroweHorwath.HelloWorld.Api.Handlers;
using CroweHorwath.HelloWorld.Api.Interfaces;
using CroweHorwath.HelloWorld.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CroweHorwath.HelloWorld.Api.Tests
{
    /// <summary>
    /// Test class for the HelloWorldController 
    /// </summary>
    public class HelloWorldControllerTests
    {
        [Fact]
        public void GET_ExceptionReturnsInternalServerError()
        {
            // arrange
            var mockLogger = new Mock<ILogger<HelloWorldController>>();

            var mockService = new Mock<IHelloWorldService>();
            mockService.Setup(x => x.GetHelloWorld())
                .Throws(new Exception("Whoops"));

            var controller =
                new HelloWorldController(mockLogger.Object, It.IsAny<IApiResponseHandler>(), mockService.Object);

            // act
            var result = controller.Get();
            var errorResult = result as StatusCodeResult;

            // assert
            Assert.NotNull(errorResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, errorResult.StatusCode);
        }

        [Fact]
        public void GET_SuccessfulRequestReturnsOk()
        {
            // arrange
            var expectedResult = "Hello World";

            var mockService = new Mock<IHelloWorldService>();
            mockService.Setup(x => x.GetHelloWorld())
                .Returns(new ServiceResponse<string>() { NotFound = false, ResponseData = expectedResult });

            var controller = new HelloWorldController(It.IsAny<ILogger<HelloWorldController>>(),
                new BasicApiResponseHandler(), mockService.Object);

            // act
            var result = controller.Get();
            var successfulResult = result as OkObjectResult;

            // assert
            Assert.NotNull(successfulResult);
            Assert.Equal(StatusCodes.Status200OK, successfulResult.StatusCode);
            Assert.Equal(expectedResult, successfulResult.Value);
        }
    }
}
