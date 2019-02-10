using TrainsProblem.Graphs.Models;
using TrainsProblem.TownRoutes.Models;

namespace TrainsProblem.TownRoutes.Validators
{
    interface ITownRouteValidator
    {
        void ValidateRoute(TownRouteModel routeModel, Graph<char> graph);
    }
}