using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainsProblem.DataStructures;

namespace TrainsProblemTests.DataStructures
{
    [TestClass]
    public class DirectedGraphBuilderTests
    {
        [TestMethod]
        public void AddEdge_NewSouceAndDestination_VerticesCreatedAndDirectedEdgeAdded()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();
            var graph = graphBuilder.GetGraph();

            var source = 'A';
            var destination = 'B';
            var distance = 5;

            graphBuilder.AddEdge(source, destination, distance);

            Assert.IsTrue(graph.HasVertex(source));
            Assert.IsTrue(graph.HasVertex(destination));

            Assert.IsTrue(graph.GetVertex(source).HasEdge(destination));
            Assert.IsFalse(graph.GetVertex(destination).HasEdge(source));
        }

        [TestMethod]
        public void AddEdge_ExistingSouceAndDestination_VerticesNotCreatedAndDirectedEdgeAdded()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();
            var graph = graphBuilder.GetGraph();

            var source = 'A';
            var destination = 'B';
            var distance = 5;

            var sourceVertex = new Vertex<char>(source);
            var destinationVertex = new Vertex<char>(destination);

            graph.Vertices.Add(sourceVertex);
            graph.Vertices.Add(destinationVertex);

            graphBuilder.AddEdge(source, destination, distance);

            Assert.AreEqual(2, graph.VerticesCount);
            Assert.IsTrue(sourceVertex.HasEdge(destination));
            Assert.IsFalse(destinationVertex.HasEdge(source));
        }

        [TestMethod]
        public void AddEdge_ExistingEdge_EdgeNotAdded()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();
            var graph = graphBuilder.GetGraph();

            var source = 'A';
            var destination = 'B';
            var distance = 5;

            var sourceVertex = new Vertex<char>(source);
            var destinationVertex = new Vertex<char>(destination);
            sourceVertex.AddEdge(new Edge<char>(destinationVertex, distance));

            graph.Vertices.Add(sourceVertex);
            graph.Vertices.Add(destinationVertex);

            graphBuilder.AddEdge(source, destination, distance);

            Assert.AreEqual(1, sourceVertex.EdgesCount);
        }
    }
}
