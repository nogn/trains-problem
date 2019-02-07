using System;

namespace TrainsProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var graph = BuildGraph();
            PrintGraph(graph);
        }

        private static DirectedGraph<char> BuildGraph()
        {
            var A = new Vertex<char>('A');
            var B = new Vertex<char>('B');
            var C = new Vertex<char>('C');
            var D = new Vertex<char>('D');
            var E = new Vertex<char>('E');

            var graph = new DirectedGraph<char>(A, B, C, D, E);

            graph.AddEdge(A, B, 5);
            graph.AddEdge(B, C, 4);
            graph.AddEdge(C, D, 8);
            graph.AddEdge(D, C, 8);
            graph.AddEdge(D, E, 6);
            graph.AddEdge(A, D, 5);
            graph.AddEdge(C, E, 2);
            graph.AddEdge(E, B, 3);
            graph.AddEdge(A, E, 7);

            return graph;
        }

        private static void PrintGraph(DirectedGraph<char> graph)
        {
            graph.Vertices.ForEach(v => Console.WriteLine(v.ToString()));
            Console.ReadKey();
        }
    }
}
