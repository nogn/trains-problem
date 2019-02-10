using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.TownRoutes
{
    public class RoutesConsoleReader : IRoutesReader
    {
        private readonly IRouteInputParser routeReader;
        private readonly IRouteValidator routeValidator;

        public RoutesConsoleReader()
        {
            routeReader = new RouteInputParser();
            routeValidator = new RouteValidator();
        }

        public Graph<char> ReadAndBuildRoutes()
        {
            WriteInputInstructions();
            var graphBuilder = new DirectedGraphBuilder<char>();

            string routeInput;
            while ((routeInput = ReadRouteInput()) != "OK")
            {
                try
                {
                    var routeModel = ParseAndValidateRouteInput(graphBuilder, routeInput);
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

        private string ReadRouteInput()
        {
            Console.Write("Enter next route: ");
            return Console.ReadLine().ToUpper();
        }

        private RouteModel ParseAndValidateRouteInput(DirectedGraphBuilder<char> graphBuilder, string routeInput)
        {
            var routeModel = routeReader.ParseInputRouteToModel(routeInput);
            routeValidator.ValidateRoute(routeModel, graphBuilder.GetGraph());

            return routeModel;
        }

        private static void AddRoute(DirectedGraphBuilder<char> graphBuilder, RouteModel routeModel)
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
