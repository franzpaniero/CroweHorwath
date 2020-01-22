using CroweHorwath.HelloWorld.Console.Interfaces;

namespace CroweHorwath.HelloWorld.Console.OutputHandlers
{
    public class DatabaseOutputHandler : IOutputHandler
    {
        public void ProcessOutput(string output)
        {
            // Do database specific operations
            System.Console.WriteLine($"Doing some DATABASE stuff with output: '{output}'");
        }
    }
}
