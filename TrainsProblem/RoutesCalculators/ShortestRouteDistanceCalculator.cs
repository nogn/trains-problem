using System;
using System.Collections.Generic;
using System.Linq;
using TrainsProblem.DataStructures;

namespace TrainsProblem.RoutesCalculators
{
    public class ShortestRouteDistanceCalculator<T>
    {
        private readonly Graph<T> graph;

        public ShortestRouteDistanceCalculator(Graph<T> graph)
        {
            this.graph = graph;
        }

        public int Execute(T srcValue, T destValue)
        {
            ValidateInputs(srcValue, destValue);

            var source = graph.GetVertex(srcValue);
            if (source == null)
                return -1;

            var unexploredVertices = graph.Vertices.ToList();
            var distances = new Dictionary<T, int>();

            unexploredVertices.ForEach(vertice => distances[vertice.Value] = int.MaxValue);

            if (srcValue.Equals(destValue))
            {
                source.Edges.ForEach(edge => distances[edge.Destination.Value] = edge.Weight);
                unexploredVertices.Remove(source);
            }
            else
                distances[srcValue] = 0;

            CalculateDistanceToNewVertices(unexploredVertices, distances);

            return distances[destValue];
        }

        private void ValidateInputs(T srcValue, T destValue)
        {
            if (srcValue.Equals(default(T)) || destValue.Equals(default(T)))
                throw new ArgumentException();
        }

        private void CalculateDistanceToNewVertices(List<Vertex<T>> unexploredVertices, Dictionary<T, int> distances)
        {
            while (unexploredVertices.Any())
            {
                var nextVertex = ExtractVertexWithMinValue(unexploredVertices, distances);

                foreach (var edge in nextVertex.Edges)
                    if (distances[nextVertex.Value] != int.MaxValue && distances[edge.Destination.Value] > distances[nextVertex.Value] + edge.Weight)
                        distances[edge.Destination.Value] = distances[nextVertex.Value] + edge.Weight;
            }
        }

        private Vertex<T> ExtractVertexWithMinValue(List<Vertex<T>> vertices, Dictionary<T, int> distances)
        {
            var minVertex = vertices.OrderBy(v => distances[v.Value]).FirstOrDefault();
            vertices.Remove(minVertex);

            return minVertex;
        }
    }
}
