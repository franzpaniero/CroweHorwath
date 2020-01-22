namespace CroweHorwath.HelloWorld.Api.Models
{
    /// <summary>
    /// Basic wrapper class for business service responses.
    /// </summary>
    /// <typeparam name="T">Type of the response returned by the business service.</typeparam>
    public class ServiceResponse<T>
    { 
        public bool NotFound { get; set; }
        public T ResponseData { get; set; }
        public string ResponseMessage { get; set; }
    }
}
