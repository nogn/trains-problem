using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.DataStructures;
using TrainsProblem.RoutesCalculators;

namespace TrainsProblemTests.RouteCalculators
{
    [TestClass]
    public class MaxStopsRoutesCalculatorTests
    {
        [TestMethod]
        public void Execute_DifferentSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var maxStops = 3;
            var calculator = new MaxStopsRoutesCalculator<char>(graph, maxStops);

            var source = 'A';
            var destination = 'C';
            var expectedResult = 3;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Execute_SameSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var maxStops = 3;
            var calculator = new MaxStopsRoutesCalculator<char>(graph, maxStops);

            var source = 'C';
            var destination = 'C';
            var expectedResult = 2;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow(null, null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_InvalidArguments_ThrowsException(char source, char destination)
        {
            var graph = new Graph<char>();
            var maxStops = 3;
            var calculator = new MaxStopsRoutesCalculator<char>(graph, maxStops);

            var result = calculator.Execute(source, destination);
        }

        [TestMethod]
        public void Execute_SourceNotExists_DefaultResult()
        {
            var graph = new Graph<char>();
            var maxStops = 3;
            var calculator = new MaxStopsRoutesCalculator<char>(graph, maxStops);

            var source = 'C';
            var destination = 'C';
            var expectedResult = 0;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
