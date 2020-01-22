using CroweHorwath.HelloWorld.Console.Interfaces;

namespace CroweHorwath.HelloWorld.Console.OutputHandlers
{
    public class MobileOutputHandler : IOutputHandler
    {
        public void ProcessOutput(string output)
        {
            // Do mobile specific operations
            System.Console.WriteLine($"Doing some MOBILE stuff with output: '{output}'");
        }
    }
}
