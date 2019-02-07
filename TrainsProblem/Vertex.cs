using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainsProblem
{
    class Vertex<T>
    {
        public Vertex(T value, params Edge<T>[] edges)
            : this(value, (IEnumerable<Edge<T>>)edges) { }

        public Vertex(T value, IEnumerable<Edge<T>> edges = null)
        {
            Value = value;
            Edges = edges?.ToList() ?? new List<Edge<T>>();
        }

        public T Value { get; }

        public List<Edge<T>> Edges { get; }

        public int EdgeCount => Edges.Count;

        public void AddEdge(Edge<T> edge)
        {
            Edges.Add(edge);
        }

        public void AddEdges(params Edge<T>[] edges)
        {
            Edges.AddRange(edges);
        }

        public void AddEdges(IEnumerable<Edge<T>> edges)
        {
            Edges.AddRange(edges);
        }

        public void RemoveEdge(Edge<T> edge)
        {
            Edges.Remove(edge);
        }

        public override string ToString()
        {
            return $"{Value}: {string.Join(" ", Edges.Select(n => n.ToString()))}";
        }
    }
}
