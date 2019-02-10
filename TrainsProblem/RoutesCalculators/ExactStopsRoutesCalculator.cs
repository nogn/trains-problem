using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.RoutesCalculators
{
    public class ExactStopsRoutesCalculator<T>
    {
        private readonly Graph<T> graph;
        private readonly int exactStops;

        public ExactStopsRoutesCalculator(Graph<T> graph, int exactStops)
        {
            this.graph = graph;
            this.exactStops = exactStops;
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
                    routesCount = CountRoutes(edge.Destination, destValue, routesCount, 1);
            else
                routesCount = CountRoutes(source, destValue, routesCount, 0);

            return routesCount;
        }

        private void ValidateInputs(T srcValue, T destValue)
        {
            if (srcValue.Equals(default(T)) || destValue.Equals(default(T)))
                throw new ArgumentException();
        }

        private int CountRoutes(Vertex<T> source, T destValue, int routesCount, int stopsCount)
        {
            if (source.Value.Equals(destValue) && stopsCount == exactStops)
                routesCount++;
            else if (stopsCount < exactStops)
                foreach (var edge in source.Edges)
                    routesCount = CountRoutes(edge.Destination, destValue, routesCount, stopsCount + 1);

            return routesCount;
        }
    }
}
