using RoleplayGame.Scenarios;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IScenario scenario = new ConsoleOurScenario();
            scenario.Setup();
            scenario.Run();
        }
    }
}
