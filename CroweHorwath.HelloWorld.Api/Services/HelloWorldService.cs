using CroweHorwath.HelloWorld.Api.Interfaces;
using CroweHorwath.HelloWorld.Api.Models;

namespace CroweHorwath.HelloWorld.Api.Services
{
    /// <summary>
    /// Hello World Business Service Implementation
    /// </summary>
    public class HelloWorldService : IHelloWorldService
    {
        /// <inheritdoc cref="IHelloWorldService"/>
        public ServiceResponse<string> GetHelloWorld()
        {
            return new ServiceResponse<string>
            {
                ResponseData = "Hello World"
            };
        }
    }
}
