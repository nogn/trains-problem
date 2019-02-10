using TrainsProblem.Graphs.Models;

namespace TrainsProblem.TownRoutes.Builders
{
    interface ITownRoutesBuilder
    {
        Graph<char> ReadAndBuildTownRoutes();
    }
}
