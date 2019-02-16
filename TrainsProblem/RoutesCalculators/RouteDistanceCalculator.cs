using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.RoutesCalculators
{
    public class RouteDistanceCalculator<T>
    {
        private readonly Graph<T> graph;

        public RouteDistanceCalculator(Graph<T> graph)
        {
            this.graph = graph;
        }

        public int Execute(T[] routes)
        {
            ValidateInput(routes);
            return CalculateDistance(routes);
        }

        private void ValidateInput(T[] routes)
        {
            if (routes == null)
                throw new ArgumentException();
        }

        private int CalculateDistance(T[] nodes)
        {
            var distance = 0;

            for (int i = 0; i < nodes.Length - 1; i++)
            {
                var sourceValue = nodes[i];

                if (!graph.HasVertex(sourceValue))
                    return -1;

                var source = graph.GetVertex(sourceValue);

                var destinationValue = nodes[i + 1];

                if (!source.HasEdge(destinationValue))
                    return -1;

                var destination = source.GetEdge(destinationValue);

                distance += destination.Weight;
            }

            return distance;
        }
    }
}
