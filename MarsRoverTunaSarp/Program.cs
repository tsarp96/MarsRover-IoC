using MarsRoverTunaSarp.ConsoleRetrievers;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Interfaces;
using Unity;
using Unity.Injection;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();


            container.RegisterType<IRetriever, ConsoleRetriever>("console",TypeLifetime.ContainerControlled);

            container.RegisterType<MarsRoverControlPanel>("panel", new InjectionConstructor(container.Resolve<IRetriever>("console"), 2));

            container.Resolve<MarsRoverControlPanel>("panel").Start();
        }
    }
}