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
            ValidateSourceDestinationDiference(routeModel.Source, routeModel.Destination);
            ValidateDistance(routeModel.Distance);
            ValidateRouteExistance(routeModel, graph);
        }

        private void ValidateSourceValue(char source)
        {
            if (!IsTownNameValid(source))
                throw new ArgumentException(InputErrorMessages.InvalidSourceInput);
        }

        private bool IsTownNameValid(char destination)
        {
            return destination >= 'A' && destination <= 'Z';
        }

        private void ValidateDestinationValue(char destination)
        {
            if (!IsTownNameValid(destination))
                throw new ArgumentException(InputErrorMessages.InvalidDestinationInput);
        }

        private static void ValidateSourceDestinationDiference(char source, char destination)
        {
            if (source == destination)
                throw new ArgumentException(InputErrorMessages.EqualSourceAndDestination);
        }
        
        private int ValidateDistance(int distance)
        {
            if (distance <= 0)
                throw new ArgumentException(InputErrorMessages.InvalidDistanceInputRange);

            return distance;
        }

        private static void ValidateRouteExistance(RouteModel routeModel, Graph<char> graph)
        {
            var town = graph.GetVertex(routeModel.Source);

            if (town != null && town.HasEdge(routeModel.Destination))
                throw new ArgumentException(InputErrorMessages.RepeatedRoute);
        }
    }
}
