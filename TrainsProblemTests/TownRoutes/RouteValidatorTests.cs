using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.DataStructures;
using TrainsProblem.TownRoutes;

namespace TrainsProblemTests.TownRoutes
{
    [TestClass]
    public class RouteValidatorTests
    {
        [TestMethod]
        public void ValidateRoute_ValidModel_NotThrowsException()
        {
            var graph = new Graph<char>();
            var routeModel = new RouteModel { Source = 'A', Destination = 'B', Distance = 5 };
            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.InvalidSourceInput)]
        public void ValidateRoute_InvalidSourceInput_ThrowsException()
        {
            var graph = new Graph<char>();
            var routeModel = new RouteModel { Source = '7', Destination = 'B', Distance = 5 };
            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.InvalidDestinationInput)]
        public void ValidateRoute_InvalidDestinationInput_ThrowsException()
        {
            var graph = new Graph<char>();
            var routeModel = new RouteModel { Source = 'A', Destination = '7', Distance = 5 };
            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.EqualSourceAndDestination)]
        public void ValidateRoute_EqualSourceAndDestination_ThrowsException()
        {
            var graph = new Graph<char>();
            var routeModel = new RouteModel { Source = 'A', Destination = 'A', Distance = 5 };
            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graph);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.InvalidDistanceInputRange)]
        public void ValidateRoute_InvalidDistanceInputRange_ThrowsException(int distance)
        {
            var graph = new Graph<char>();
            var routeModel = new RouteModel { Source = 'A', Destination = 'B', Distance = distance };
            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.RepeatedRoute)]
        public void ValidateRoute_RepeatedRoute_ThrowsException()
        {
            var graphBuilder = new DirectedGraphBuilder<char>();
            var routeModel = new RouteModel { Source = 'A', Destination = 'B', Distance = 5 };

            graphBuilder.AddEdge(routeModel.Source, routeModel.Destination, routeModel.Distance);

            var routeValidator = new RouteValidator();

            routeValidator.ValidateRoute(routeModel, graphBuilder.GetGraph());
        }
    }
}
