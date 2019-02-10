using TrainsProblem.DataStructures;

namespace TrainsProblem.TownRoutes
{
    public interface IRouteValidator
    {
        void ValidateRoute(RouteModel routeModel, Graph<char> graph);
    }
}