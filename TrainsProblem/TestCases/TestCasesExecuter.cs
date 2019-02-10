using System;
using TrainsProblem.DataStructures;
using TrainsProblem.RoutesCalculators;

namespace TrainsProblem.TestCases
{
    public class TestCasesExecuter
    {
        public void RunAll(Graph<char> graph = null)
        {
            graph = graph ?? BuildDefaultTestInputGraph();

            Console.WriteLine("Executing test cases 1 to 10:\n");
            try
            {
                RunTestCases1To5(graph);
                RunTestCase6(graph);
                RunTestCase7(graph);
                RunTestCase8(graph);
                RunTestCase9(graph);
                RunTestCase10(graph);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: Invalid parameters.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void RunTestCases1To5(Graph<char> graph)
        {
            var calculator = new RouteDistanceCalculator<char>(graph);

            var routes = new char[][]
            {
                new char[] { 'A', 'B', 'C' },
                new char[] { 'A', 'D' },
                new char[] { 'A', 'D', 'C' },
                new char[] { 'A', 'E', 'B', 'C', 'D' },
                new char[] { 'A', 'E', 'D' }
            };

            for (int i = 0; i < routes.Length; i++)
            {
                var distance = calculator.Execute(routes[i]);
                var result = distance != -1 ? distance.ToString() : "NO SUCH ROUTE";

                OutputResult(i + 1, result);
            }
        }

        private void OutputResult(int testCaseNumber, object result)
        {
            Console.WriteLine($"OUTPUT #{testCaseNumber}: {result}");
        }

        private void RunTestCase6(Graph<char> graph)
        {
            var result = new MaxStopsRoutesCalculator<char>(graph, maxStops: 3).Execute('C', 'C');
            OutputResult(6, result);
        }

        private void RunTestCase7(Graph<char> graph)
        {
            var result = new ExactStopsRoutesCalculator<char>(graph, exactStops: 4).Execute('A', 'C');
            OutputResult(7, result);
        }

        private void RunTestCase8(Graph<char> graph)
        {
            var result = new ShortestRouteDistanceCalculator<char>(graph).Execute('A', 'C');
            OutputResult(8, result);
        }

        private void RunTestCase9(Graph<char> graph)
        {
            var result = new ShortestRouteDistanceCalculator<char>(graph).Execute('B', 'B');
            OutputResult(9, result);
        }

        private void RunTestCase10(Graph<char> graph)
        {
            var result = new MaxDistanceRoutesCalculator<char>(graph, maxDistance: 30).Execute('C', 'C');
            OutputResult(10, result);
        }

        private Graph<char> BuildDefaultTestInputGraph()
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
