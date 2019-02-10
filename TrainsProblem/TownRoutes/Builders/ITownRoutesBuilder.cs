using TrainsProblem.Graphs.Models;

namespace TrainsProblem.TownRoutes.Builders
{
    interface ITownRoutesBuilder
    {
        DirectedGraph<char> ReadAndBuildTownRoutes();
    }
}
