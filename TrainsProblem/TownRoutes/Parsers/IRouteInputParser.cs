using TrainsProblem.TownRoutes.Models;

namespace TrainsProblem.TownRoutes.Parsers
{
    public interface IRouteInputParser
    {
        RouteModel ParseInputRouteToModel(string routeInput);
    }
}
