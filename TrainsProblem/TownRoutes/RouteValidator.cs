using System;
using TrainsProblem.DataStructures;

namespace TrainsProblem.TownRoutes
{
    public class RouteValidator : IRouteValidator
    {
        public void ValidateRoute(RouteModel routeModel, Graph<char> graph)
        {
            ValidateSourceValue(routeModel.Source);
            ValidateDestinationValue(routeModel.Destination);
            ValidateSourceAndDestinationDifference(routeModel.Source, routeModel.Destination);
            ValidateDistanceValue(routeModel.Distance);
            ValidateRouteExistence(routeModel, graph);
        }

        private void ValidateSourceValue(char source)
        {
            if (!IsTownNameValid(source))
                throw new ArgumentException(InputErrorMessages.InvalidSourceInput);
        }

        private bool IsTownNameValid(char name)
        {
            return name >= 'A' && name <= 'Z';
        }

        private void ValidateDestinationValue(char destination)
        {
            if (!IsTownNameValid(destination))
                throw new ArgumentException(InputErrorMessages.InvalidDestinationInput);
        }

        private static void ValidateSourceAndDestinationDifference(char source, char destination)
        {
            if (source == destination)
                throw new ArgumentException(InputErrorMessages.EqualSourceAndDestination);
        }
        
        private int ValidateDistanceValue(int distance)
        {
            if (distance <= 0)
                throw new ArgumentException(InputErrorMessages.InvalidDistanceInputRange);

            return distance;
        }

        private static void ValidateRouteExistence(RouteModel routeModel, Graph<char> graph)
        {
            var town = graph.GetVertex(routeModel.Source);

            if (town != null && town.HasEdge(routeModel.Destination))
                throw new ArgumentException(InputErrorMessages.RepeatedRoute);
        }
    }
}
