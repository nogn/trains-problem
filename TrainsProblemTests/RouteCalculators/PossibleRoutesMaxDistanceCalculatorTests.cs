using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.DataStructures.Graph;
using TrainsProblem.RouteCalculators;

namespace TrainsProblemTests.RouteCalculators
{
    [TestClass]
    public class PossibleRoutesMaxDistanceCalculatorTests
    {
        [TestMethod]
        public void Execute_DifferentSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var maxDistance = 30;
            var calculator = new PossibleRoutesMaxDistanceCalculator<char>(graph, maxDistance);

            var source = 'A';
            var destination = 'C';
            var expectedResult = 11;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Execute_SameSourceAndDestination_CorrectResult()
        {
            var graph = TestUtils.BuildDefaultTestGraph();
            var maxDistance = 30;
            var calculator = new PossibleRoutesMaxDistanceCalculator<char>(graph, maxDistance);

            var source = 'C';
            var destination = 'C';
            var expectedResult = 7;

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
            var maxDistance = 30;
            var calculator = new PossibleRoutesMaxDistanceCalculator<char>(graph, maxDistance);

            var result = calculator.Execute(source, destination);
        }

        [TestMethod]
        public void Execute_SourceNotExists_IncorrectResult()
        {
            var graph = new Graph<char>();
            var maxDistance = 30;
            var calculator = new PossibleRoutesMaxDistanceCalculator<char>(graph, maxDistance);

            var source = 'C';
            var destination = 'C';
            var expectedResult = 0;

            var result = calculator.Execute(source, destination);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
