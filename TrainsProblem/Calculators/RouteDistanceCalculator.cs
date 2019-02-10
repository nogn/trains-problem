using TrainsProblem.Graphs.Models;

namespace TrainsProblem
{
    class RouteDistanceCalculator
    {
        public static int Execute(Graph<char> graph, char[] route)
        {
            var distance = 0;

            for (int i = 0; i < route.Length - 1; i++)
            {
                var source = graph.GetVertex(route[i]);

                if (source == null)
                    return -1;

                var destination = source.GetEdge(route[i + 1]);

                if (destination == null)
                    return -1;

                distance += destination.Weight;
            }

            return distance;
        }
    }
}
