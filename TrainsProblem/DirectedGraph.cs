using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainsProblem
{
    class DirectedGraph<T>
    {
        public DirectedGraph(params Vertex<T>[] initialVertices)
            : this((IEnumerable<Vertex<T>>)initialVertices) { }

        public DirectedGraph(IEnumerable<Vertex<T>> initialVertices = null)
        {
            Vertices = initialVertices?.ToList() ?? new List<Vertex<T>>();
        }

        public List<Vertex<T>> Vertices { get; }

        public int Size => Vertices.Count;

        public void AddEdge(Vertex<T> source, Vertex<T> destination, int weight)
        {
            AddVertexIfNew(source);
            AddVertexIfNew(destination);

            AddEdgeIfNew(source, destination, weight);
        }

        private void AddVertexIfNew(Vertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
                Vertices.Add(vertex);
        }

        private static void AddEdgeIfNew(Vertex<T> source, Vertex<T> destination, int weight)
        {
            if (!source.Edges.Where(n => n.Destination == destination).Any())
                source.AddEdge(new Edge<T>(destination, weight));
        }
    }
}
