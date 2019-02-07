using System;
using System.Collections.Generic;
using System.Text;

namespace TrainsProblem
{
    class Edge<T>
    {
        public Edge(Vertex<T> destination, int weight)
        {
            Destination = destination;
            Weight = weight;
        }

        public Vertex<T> Destination { get; }

        public int Weight { get; }

        public override string ToString()
        {
            return $"{Destination.Value}{Weight}";
        }
    }
}
