using CroweHorwath.HelloWorld.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CroweHorwath.HelloWorld.Api.Interfaces
{
    /// <summary>
    /// Interface representing a handler for mapping service responses to an HTTP method response.
    /// </summary>
    public interface IApiResponseHandler
    {
        /// <summary>
        /// Maps a ServiceResponse to an HTTP based IActionResult for a GET request.
        /// </summary>
        /// <typeparam name="T">The type of the response data to be sent back in the IActionResult.</typeparam>
        /// <param name="serviceResponse">Internal business service response.</param>
        /// <returns>HTTP based IActionResult mapped from <paramref name="serviceResponse"/>.</returns>
        IActionResult Get<T>(ServiceResponse<T> serviceResponse);

        // TODO: Additionally, other generic response handlers could be implemented (LIST, DELETE, PUT, etc)
    }
}
