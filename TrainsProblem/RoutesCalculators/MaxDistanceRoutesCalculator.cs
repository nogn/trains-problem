using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.RoutesCalculators
{
    public class MaxDistanceRoutesCalculator<T>
    {
        private readonly Graph<T> graph;
        private readonly int maxDistance;

        public MaxDistanceRoutesCalculator(Graph<T> graph, int maxDistance)
        {
            this.graph = graph;
            this.maxDistance = maxDistance;
        }

        public int Execute(T srcValue, T destValue)
        {
            ValidateInputs(srcValue, destValue);
            int routesCount = 0;

            var source = graph.GetVertex(srcValue);
            if (source == null)
                return routesCount;

            if (srcValue.Equals(destValue))
                foreach (var edge in source.Edges)
                    routesCount = CountRoutes(edge.Destination, destValue, routesCount, edge.Weight);
            else
                routesCount = CountRoutes(source, destValue, routesCount, 0);

            return routesCount;
        }

        private void ValidateInputs(T srcValue, T destValue)
        {
            if (srcValue.Equals(default(T)) || destValue.Equals(default(T)))
                throw new ArgumentException();
        }

        private int CountRoutes(Vertex<T> source, T destValue, int routesCount, int distanceCount)
        {
            if (source.Value.Equals(destValue))
                routesCount++;

            foreach (var edge in source.Edges)
                if (distanceCount + edge.Weight < maxDistance)
                    routesCount = CountRoutes(edge.Destination, destValue, routesCount, distanceCount + edge.Weight);

            return routesCount;
        }
    }
}
