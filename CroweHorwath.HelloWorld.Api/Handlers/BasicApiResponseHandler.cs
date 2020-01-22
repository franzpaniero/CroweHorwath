using CroweHorwath.HelloWorld.Api.Interfaces;
using CroweHorwath.HelloWorld.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CroweHorwath.HelloWorld.Api.Handlers
{
    /// <summary>
    /// Class for performing basic mapping of internal service responses to an appropriate HTTP method response.
    /// </summary>
    public class BasicApiResponseHandler : IApiResponseHandler
    {
        /// <summary>
        /// Maps a ServiceResponse to an HTTP based IActionResult for a GET request.
        /// </summary>
        /// <typeparam name="T">The type of the response data being sent back in the IActionResult.</typeparam>
        /// <param name="serviceResponse">Internal business service response.</param>
        /// <returns>HTTP based IActionResult mapped from <paramref name="serviceResponse"/>.</returns>
        public IActionResult Get<T>(ServiceResponse<T> serviceResponse)
        {
            if (serviceResponse.NotFound)
            {
                return new NotFoundObjectResult(serviceResponse.ResponseMessage);
            }

            return new OkObjectResult(serviceResponse.ResponseData);
        }
    }
}
