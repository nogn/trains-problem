using System;
using TrainsProblem.TownRoutes.Messages;
using TrainsProblem.TownRoutes.Models;

namespace TrainsProblem.TownRoutes.Parsers
{
    public class RouteInputParser : IRouteInputParser
    {
        public RouteModel ParseInputRouteToModel(string routeInput)
        {
            ValidateInputLength(routeInput);

            routeInput = routeInput.ToUpper();

            return new RouteModel
            {
                Source = routeInput[0],
                Destination = routeInput[1],
                Distance = ReadDistance(routeInput.Substring(2))
            };
        }

        private void ValidateInputLength(string routeInput)
        {
            if (routeInput.Length < 3)
                throw new ArgumentException(InputErrorMessages.InvalidInputLength);
        }

        private int ReadDistance(string distanceInput)
        {
            if (!int.TryParse(distanceInput, out int distance))
                throw new ArgumentException(InputErrorMessages.InvalidDistanceInput);

            return distance;
        }
    }
}
