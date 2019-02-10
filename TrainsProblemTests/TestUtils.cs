using TrainsProblem.DataStructures;

namespace TrainsProblemTests
{
    public class TestUtils
    {
        public static Graph<char> BuildDefaultTestGraph()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();

            graphBuilder.AddEdge('A', 'B', 5);
            graphBuilder.AddEdge('B', 'C', 4);
            graphBuilder.AddEdge('C', 'D', 8);
            graphBuilder.AddEdge('D', 'C', 8);
            graphBuilder.AddEdge('D', 'E', 6);
            graphBuilder.AddEdge('A', 'D', 5);
            graphBuilder.AddEdge('C', 'E', 2);
            graphBuilder.AddEdge('E', 'B', 3);
            graphBuilder.AddEdge('A', 'E', 7);

            return graphBuilder.GetGraph();
        }
    }
}
