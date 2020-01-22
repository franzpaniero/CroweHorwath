using System;
using CroweHorwath.HelloWorld.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CroweHorwath.HelloWorld.Api.Controllers
{
    /// <summary>
    /// Hello World Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly IApiResponseHandler _responseHandler;
        private readonly IHelloWorldService _helloWorldService;

        /// <summary>
        /// Constructor for HelloWorldController
        /// </summary>
        /// <param name="logger">Logging object</param>
        /// <param name="responseHandler">API Response Handler/mapper</param>
        /// <param name="helloWorldService">Business service</param>
        public HelloWorldController(ILogger<HelloWorldController> logger, IApiResponseHandler responseHandler, IHelloWorldService helloWorldService)
        {
            _logger = logger;
            _responseHandler = responseHandler;
            _helloWorldService = helloWorldService;
        }

        /// <summary>
        /// Returns Hello World.
        /// </summary>
        /// <returns>Returns the string "Hello World"</returns>
        [HttpGet, Produces("text/plain")]
        public IActionResult Get()
        {
            try
            {
                return _responseHandler.Get(_helloWorldService.GetHelloWorld());
            }
            catch (Exception ex)
            {
                // log the exception
                _logger.LogError(ex, "An error has occurred in HelloWorld");

                // return 500, obscure the exception from the caller
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}