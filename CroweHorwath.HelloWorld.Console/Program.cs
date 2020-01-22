using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CroweHorwath.HelloWorld.Console.Interfaces;
using CroweHorwath.HelloWorld.Console.OutputFactories;
using Microsoft.Extensions.Configuration;

namespace CroweHorwath.HelloWorld.Console
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task RunHelloWorld(string apiBaseUrl, IOutputHandler outputHandler)
        {
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var apiResponse = await client.GetAsync("api/HelloWorld");

                if (apiResponse.IsSuccessStatusCode)
                {
                    var payload = await apiResponse.Content.ReadAsStringAsync();
                    
                    outputHandler.ProcessOutput(payload);
                }
                else
                {
                    System.Console.WriteLine($"The API returned an unsuccessful response code ({apiResponse.StatusCode}).");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"An error has occurred: {e.Message}");
            }

            System.Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            OutputFactory factory = null;

            // output handler is specified in appsettings.json configuration file
            var outputHandlerType = config["OutputHandler"];

            switch (outputHandlerType?.ToLower())
            {
                case "console":
                    factory = new ConsoleOutputFactory();
                    break;

                case "database":
                    factory = new DatabaseOutputFactory();
                    break;

                case "mobile":
                    factory = new MobileOutputFactory();
                    break;

                default:
                    factory = new ConsoleOutputFactory();
                    break;
            }

            RunHelloWorld(config["HelloWorldApiBaseUrl"], factory.GetOutputHandler()).GetAwaiter().GetResult();
        }
    }
}
