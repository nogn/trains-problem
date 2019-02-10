namespace TrainsProblem.TownRoutes
{
    public interface IRouteInputParser
    {
        RouteModel ParseInputRouteToModel(string routeInput);
    }
}
