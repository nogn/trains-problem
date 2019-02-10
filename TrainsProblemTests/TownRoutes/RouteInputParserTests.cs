using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TrainsProblem.TownRoutes;

namespace TrainsProblemTests.TownRoutes
{
    [TestClass]
    public class RouteInputParserTests
    {
        [TestMethod]
        [DataRow("AB12")]
        [DataRow("ab12")]
        public void ParseInputRouteToModel_ValidInput_RouteModel(string routeInput)
        {
            var routeInputParser = new RouteInputParser();
            var routeModel = routeInputParser.ParseInputRouteToModel(routeInput);

            Assert.IsNotNull(routeInput);
            Assert.AreEqual('A', routeModel.Source);
            Assert.AreEqual('B', routeModel.Destination);
            Assert.AreEqual(12, routeModel.Distance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.InvalidInputLength)]
        public void ParseInputRouteToModel_InvalidInputLenght_ThrowsException()
        {
            var routeInputParser = new RouteInputParser();
            var routeInput = "AB";

            var routeModel = routeInputParser.ParseInputRouteToModel(routeInput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), InputErrorMessages.InvalidDistanceInput)]
        public void ParseInputRouteToModel_InvalidDistanceInput_ThrowsException()
        {
            var routeInputParser = new RouteInputParser();
            var routeInput = "ABB";

            var routeModel = routeInputParser.ParseInputRouteToModel(routeInput);
        }
    }
}
