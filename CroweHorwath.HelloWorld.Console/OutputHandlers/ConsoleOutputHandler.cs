using CroweHorwath.HelloWorld.Console.Interfaces;

namespace CroweHorwath.HelloWorld.Console.OutputHandlers
{
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void ProcessOutput(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}
