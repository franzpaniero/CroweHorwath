using CroweHorwath.HelloWorld.Api.Services;
using Xunit;

namespace CroweHorwath.HelloWorld.Api.Tests
{
    /// <summary>
    /// Test class for HelloWorld business service.
    /// </summary>
    public class HelloWorldServiceTests
    {
        [Fact]
        public void GetHelloWorldReturnsExpectedValue()
        {
            // arrange
            var expectedValue = "Hello World";
            var service = new HelloWorldService();

            // act
            var result = service.GetHelloWorld();

            // assert
            Assert.NotNull(result);
            Assert.False(result.NotFound);
            Assert.Equal(expectedValue, result.ResponseData);
        }
    }
}
