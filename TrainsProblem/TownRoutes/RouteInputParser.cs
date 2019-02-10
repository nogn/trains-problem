using System;

namespace TrainsProblem.TownRoutes
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
            if (string.IsNullOrWhiteSpace(routeInput) || routeInput.Length < 3)
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
