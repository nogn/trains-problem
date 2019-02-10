using TrainsProblem.TownRoutes.Models;

namespace TrainsProblem.TownRoutes.InputReaders
{
    interface ITownRouteInputReader
    {
        TownRouteModel CreateRouteModelFromInput(string routeInput);
    }
}
