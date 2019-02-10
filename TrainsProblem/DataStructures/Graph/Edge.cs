namespace TrainsProblem.DataStructures.Graph
{
    public class Edge<T>
    {
        public Edge(Vertex<T> destination, int weight = 0)
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
