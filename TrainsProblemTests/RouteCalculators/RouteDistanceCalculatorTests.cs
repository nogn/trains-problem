using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.DataStructures;
using TrainsProblem.RouteCalculators;

namespace TrainsProblemTests.RouteCalculators
{
    [TestClass]
    public class RouteDistanceCalculatorTests
    {
        [TestMethod]
        [DataRow(new char[] { 'A', 'B', 'C' }, 9)]
        [DataRow(new char[] { 'A', 'D' }, 5)]
        [DataRow(new char[] { 'A', 'D', 'C' }, 13)]
        [DataRow(new char[] { 'A', 'E', 'B', 'C', 'D' }, 22)]
        [DataRow(new char[] { 'A', 'E', 'D' }, -1)]
        public void Execute_DifferentSourceAndDestination_CorrectResult(char [] route, int expectedResult)
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var calculator = new RouteDistanceCalculator<char>(graph);

            var result = calculator.Execute(route);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_InvalidArguments_ThrowsException()
        {
            var graph = new Graph<char>();
            var calculator = new RouteDistanceCalculator<char>(graph);
            char[] route = null;

            var result = calculator.Execute(route);
        }

        [TestMethod]
        public void Execute_SourceNotExists_IncorrectResult()
        {
            var graph = new Graph<char>();
            var calculator = new RouteDistanceCalculator<char>(graph);

            var route = new char[] { 'A', 'B' };
            var expectedResult = -1;

            var result = calculator.Execute(route);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Execute_EdgeNotExists_IncorrectResult()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();
            graphBuilder.AddEdge('A','C', 5);
            
            var calculator = new RouteDistanceCalculator<char>(graphBuilder.GetGraph());

            var route = new char[] { 'A', 'B' };
            var expectedResult = -1;

            var result = calculator.Execute(route);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Execute_EmptyRoute_0()
        {
            var graph = new Graph<char>();
            var calculator = new RouteDistanceCalculator<char>(graph);

            var route = new char[] { };
            var expectedResult = 0;

            var result = calculator.Execute(route);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
