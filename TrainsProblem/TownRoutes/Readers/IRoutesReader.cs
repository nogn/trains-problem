using TrainsProblem.DataStructures.Graph;

namespace TrainsProblem.TownRoutes.Readers
{
    public interface IRoutesReader
    {
        Graph<char> ReadAndBuildRoutes();
    }
}
