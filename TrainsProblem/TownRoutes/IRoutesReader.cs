using TrainsProblem.DataStructures;

namespace TrainsProblem.TownRoutes
{
    public interface IRoutesReader
    {
        Graph<char> ReadAndBuildRoutes();
    }
}
