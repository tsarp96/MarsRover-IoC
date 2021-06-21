using MarsRoverTunaSarp.ConsoleRetrievers;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverControlPanel.Instance.ConsoleRetriever = ConsoleRetriever.Instance;
            MarsRoverControlPanel.Instance.RoversCount = 2; // In further implementation it can be asked from user
            MarsRoverControlPanel.Instance.start();
        }
    }
}
