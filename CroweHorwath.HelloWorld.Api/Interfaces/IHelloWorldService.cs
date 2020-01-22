using CroweHorwath.HelloWorld.Api.Models;

namespace CroweHorwath.HelloWorld.Api.Interfaces
{
    /// <summary>
    /// Interface for Hello World Business Service
    /// </summary>
    public interface IHelloWorldService
    {
        /// <summary>
        /// Hello World Service Method
        /// </summary>
        /// <returns>Returns the string "Hello World"</returns>
        ServiceResponse<string> GetHelloWorld();
    }
}
