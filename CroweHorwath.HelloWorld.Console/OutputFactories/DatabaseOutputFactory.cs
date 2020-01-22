using CroweHorwath.HelloWorld.Console.Interfaces;
using CroweHorwath.HelloWorld.Console.OutputHandlers;

namespace CroweHorwath.HelloWorld.Console.OutputFactories
{
    public class ConsoleOutputFactory : OutputFactory
    {
        public override IOutputHandler GetOutputHandler()
        {
            return new ConsoleOutputHandler();
        }
    }
}
