using System;
using TrainsProblem.TownRoutes;

namespace TrainsProblem.TestCases
{
    public class TrainsProblemApplication
    {
        private static TrainsProblemApplication trainProblemApplication;

        private readonly IRoutesReader routesReader;
        private readonly TestCasesExecuter testCasesExecuter;

        private TrainsProblemApplication()
        {
            routesReader = new RoutesConsoleReader();
            testCasesExecuter = new TestCasesExecuter();
        }

        public static TrainsProblemApplication GetInstance()
        {
            if (trainProblemApplication == null)
                trainProblemApplication = new TrainsProblemApplication();

            return trainProblemApplication;
        }

        public void Start()
        {
            Console.WriteLine("Starting Application...\n");

            var graph = routesReader.ReadAndBuildRoutes();
            testCasesExecuter.RunAll(graph);

            Console.WriteLine("\nApplication finished. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
