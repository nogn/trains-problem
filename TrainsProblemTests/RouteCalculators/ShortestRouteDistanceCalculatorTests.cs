using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.DataStructures;
using TrainsProblem.RouteCalculators;

namespace TrainsProblemTests.RouteCalculators
{
    [TestClass]
    public class ShortestRouteDistanceCalculatorTests
    {
        [TestMethod]
        public void Execute_DifferentSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var calculator = new ShortestRouteDistanceCalculator<char>(graph);

            var source = 'A';
            var destination = 'C';
            var expectedResult = 9;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Execute_SameSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var calculator = new ShortestRouteDistanceCalculator<char>(graph);

            var source = 'B';
            var destination = 'B';
            var expectedResult = 9;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(null, null)]
        [DataRow("", "")]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_InvalidArguments_ThrowsException(char source, char destination)
        {
            var graph = new Graph<char>();
            var calculator = new ShortestRouteDistanceCalculator<char>(graph);

            var result = calculator.Execute(source, destination);
        }

        [TestMethod]
        public void Execute_SourceNotExists_IncorrectResult()
        {
            var graph = new Graph<char>();
            var calculator = new ShortestRouteDistanceCalculator<char>(graph);

            var source = 'A';
            var destination = 'C';
            var expectedResult = -1;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
