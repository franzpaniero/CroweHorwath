using CroweHorwath.HelloWorld.Console.Interfaces;

namespace CroweHorwath.HelloWorld.Console.OutputFactories
{
    public abstract class OutputFactory
    {
        public abstract IOutputHandler GetOutputHandler();
    }
}
