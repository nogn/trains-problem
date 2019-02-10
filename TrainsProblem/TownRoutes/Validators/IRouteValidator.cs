using TrainsProblem.DataStructures.Graph;
using TrainsProblem.TownRoutes.Models;

namespace TrainsProblem.TownRoutes.Validators
{
    public interface IRouteValidator
    {
        void ValidateRoute(RouteModel routeModel, Graph<char> graph);
    }
}