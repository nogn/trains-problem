using System;
using TrainsProblem.Graphs.Builders;
using TrainsProblem.Graphs.Models;
using TrainsProblem.TownRoutes.Builders;

namespace TrainsProblem.TestCases
{
    class TrainsProblemApplication
    {
        private static TrainsProblemApplication trainProblemApplication;

        private readonly ITownRoutesBuilder townRoutesReader;
        private readonly TestCasesExecuter testCasesExecuter;

        private TrainsProblemApplication()
        {
            townRoutesReader = new TownRoutesConsoleBuilder();
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

            var graph = BuildDefaultTestGraph();
            testCasesExecuter.RunAll(graph);

            Console.WriteLine("\nApplication finished. Press any key to exit.");
            Console.ReadKey();
        }

        // Use this method if you wish to load the default town routes input graph
        // and use it to run the test cases
        private DirectedGraph<char> BuildDefaultTestGraph()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();

            graphBuilder.AddEdge('A', 'B', 5);
            graphBuilder.AddEdge('B', 'C', 4);
            graphBuilder.AddEdge('C', 'D', 8);
            graphBuilder.AddEdge('D', 'C', 8);
            graphBuilder.AddEdge('D', 'E', 6);
            graphBuilder.AddEdge('A', 'D', 5);
            graphBuilder.AddEdge('C', 'E', 2);
            graphBuilder.AddEdge('E', 'B', 3);
            graphBuilder.AddEdge('A', 'E', 7);

            return graphBuilder.GetGraph();
        }
    }
}
