using System;
using TrainsProblem.Graphs.Builders;
using TrainsProblem.Graphs.Models;
using TrainsProblem.TownRoutes.InputReaders;
using TrainsProblem.TownRoutes.Models;
using TrainsProblem.TownRoutes.Validators;

namespace TrainsProblem.TownRoutes.Builders
{
    class TownRoutesConsoleBuilder : ITownRoutesBuilder
    {
        private readonly ITownRouteInputReader routeReader;
        private readonly ITownRouteValidator routeValidator;

        public TownRoutesConsoleBuilder()
        {
            routeReader = new TownRouteInputReader();
            routeValidator = new TownRouteValidator();
        }

        public Graph<char> ReadAndBuildTownRoutes()
        {
            WriteInputInstructions();
            var graphBuilder = new DirectedGraphBuilder<char>();

            string routeInput;
            while ((routeInput = ReadInputRoute()) != "OK")
            {
                try
                {
                    var routeModel = ParseAndValidateRoute(graphBuilder, routeInput);
                    AddRoute(graphBuilder, routeModel);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n");
                }
            }

            var routesGraph = graphBuilder.GetGraph();
            WriteInputSummary(routesGraph);

            return routesGraph;
        }

        private void WriteInputInstructions()
        {
            Console.WriteLine("Please, provide all possible routes.");
            Console.WriteLine("A route between two towns (A to B) with a distance of 5 is represented as 'AB5'.");
            Console.WriteLine("To finish the input process, enter 'OK' at any time.\n");
        }

        private string ReadInputRoute()
        {
            Console.Write("Enter next route: ");
            return Console.ReadLine().ToUpper();
        }

        private TownRouteModel ParseAndValidateRoute(DirectedGraphBuilder<char> graphBuilder, string routeInput)
        {
            var routeModel = routeReader.CreateRouteModelFromInput(routeInput);
            routeValidator.ValidateRoute(routeModel, graphBuilder.GetGraph());

            return routeModel;
        }

        private static void AddRoute(DirectedGraphBuilder<char> graphBuilder, TownRouteModel routeModel)
        {
            graphBuilder.AddEdge(routeModel.Source, routeModel.Destination, routeModel.Distance);
            Console.WriteLine($"Route '{routeModel}' successfully added.\n");
        }

        private void WriteInputSummary(Graph<char> routesGraph)
        {
            Console.WriteLine("\nInput Summary:");
            Console.WriteLine($"{routesGraph}\n");
        }
    }
}
