using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.RouteCalculators
{
    public class RouteDistanceCalculator<T>
    {
        private readonly Graph<T> graph;

        public RouteDistanceCalculator(Graph<T> graph)
        {
            this.graph = graph;
        }

        public int Execute(T[] desiredRoute)
        {
            ValidateInput(desiredRoute);

            var distance = 0;

            for (int i = 0; i < desiredRoute.Length - 1; i++)
            {
                var source = graph.GetVertex(desiredRoute[i]);

                if (source == null)
                    return -1;

                var destination = source.GetEdge(desiredRoute[i + 1]);

                if (destination == null)
                    return -1;

                distance += destination.Weight;
            }

            return distance;
        }

        private void ValidateInput(T[] route)
        {
            if (route == null)
                throw new ArgumentException();
        }
    }
}
