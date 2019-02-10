using System;
using TrainsProblem.Graphs.Models;

namespace TrainsProblem.TestCases
{
    class TestCasesExecuter
    {
        public void RunAll(DirectedGraph<char> graph)
        {
            Console.WriteLine("Executing Questions 1 to 10:\n");

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

        private void RunTestCases1To5(DirectedGraph<char> graph)
        {
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
                var distance = RouteDistanceCalculator.Execute(graph, routes[i]);
                var result = distance != -1 ? distance.ToString() : "NO SUCH ROUTE";

                OutputResult(i + 1, result);
            }
        }

        private void OutputResult(int caseNumber, object result)
        {
            Console.WriteLine($"OUTPUT #{caseNumber}: {result}");
        }

        private void RunTestCase6(DirectedGraph<char> graph)
        {
            var result = new PossibleRoutesWithMaxStopsCalculator<char>(graph, maxStops: 3).Execute('C', 'C');
            OutputResult(6, result);
        }

        private void RunTestCase7(DirectedGraph<char> graph)
        {
            var result = new PossibleRoutesWithExactStopsCalculator<char>(graph, maxStops: 4).Execute('A', 'C');
            OutputResult(7, result);
        }

        private void RunTestCase8(DirectedGraph<char> graph)
        {
            var result = new ShortestRouteDistanceCalculator<char>(graph).Execute('A', 'C');
            OutputResult(8, result);
        }

        private void RunTestCase9(DirectedGraph<char> graph)
        {
            var result = new ShortestRouteDistanceCalculator<char>(graph).Execute('B', 'B');
            OutputResult(9, result);
        }

        private void RunTestCase10(DirectedGraph<char> graph)
        {
            var result = new PossibleRoutesMaxDistanceCalculator<char>(graph, maxDistance: 30).Execute('C', 'C');
            OutputResult(10, result);
        }
    }
}
