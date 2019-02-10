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

            var distance = 0;

            for (int i = 0; i < routes.Length - 1; i++)
            {
                var source = graph.GetVertex(routes[i]);

                if (source == null)
                    return -1;

                var destination = source.GetEdge(routes[i + 1]);

                if (destination == null)
                    return -1;

                distance += destination.Weight;
            }

            return distance;
        }

        private void ValidateInput(T[] routes)
        {
            if (routes == null)
                throw new ArgumentException();
        }
    }
}
