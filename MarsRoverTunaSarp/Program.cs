using MarsRoverTunaSarp.ConsoleRetrievers;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using Unity;
using Unity.Injection;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int _squadLimit = 2;
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IRetriever, ConsoleRetriever>("console",TypeLifetime.ContainerControlled);
            container.RegisterType<IExplorationService, ExplorationService>(TypeLifetime.ContainerControlled);
            container.RegisterType<IInputService, InputService>(TypeLifetime.ContainerControlled);
            container.RegisterType<IControlPanel, MarsRoverControlPanel>(TypeLifetime.ContainerControlled);

            container.RegisterType<MarsRoverControlPanel>("panel", new InjectionConstructor(container.Resolve<IRetriever>("console"), 
                                                                                                container.Resolve<IExplorationService>(), 
                                                                                                    container.Resolve<IInputService>() ,  _squadLimit));

            container.Resolve<MarsRoverControlPanel>("panel").Start();
        }
    }
}