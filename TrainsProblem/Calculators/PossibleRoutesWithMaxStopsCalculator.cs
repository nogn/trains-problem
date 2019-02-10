using System;
using TrainsProblem.Graphs.Models;

namespace TrainsProblem
{
    class PossibleRoutesWithMaxStopsCalculator<T>
    {
        private readonly DirectedGraph<T> graph;
        private readonly int maxStops;

        public PossibleRoutesWithMaxStopsCalculator(DirectedGraph<T> graph, int maxStops)
        {
            this.graph = graph;
            this.maxStops = maxStops;
        }

        public int Execute(T srcValue, T destValue)
        {
            ValidateInputs(srcValue, destValue);
            int pathCount = 0;

            var source = graph.GetVertex(srcValue);
            if (source == null)
                return pathCount;

            if (srcValue.Equals(destValue))
                foreach (var edge in source.Edges)
                    pathCount = CountPaths(edge.Destination, destValue, pathCount, 1);
            else
                pathCount = CountPaths(source, destValue, pathCount, 0);

            return pathCount;
        }

        private void ValidateInputs(T srcValue, T destValue)
        {
            if (srcValue == null || destValue == null)
                throw new ArgumentException();
        }

        private int CountPaths(Vertex<T> source, T destValue, int pathCount, int countStops)
        {
            if (source.Value.Equals(destValue))
                pathCount++;
            else if (countStops < maxStops)
                foreach (var edge in source.Edges)
                    pathCount = CountPaths(edge.Destination, destValue, pathCount, countStops + 1);

            return pathCount;
        }
    }
}
