using CroweHorwath.HelloWorld.Console.Interfaces;
using CroweHorwath.HelloWorld.Console.OutputHandlers;

namespace CroweHorwath.HelloWorld.Console.OutputFactories
{
    public class MobileOutputFactory : OutputFactory
    {
        public override IOutputHandler GetOutputHandler()
        {
            return new MobileOutputHandler();
        }
    }
}
