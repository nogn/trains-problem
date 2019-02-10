using TrainsProblem.TestCases;

namespace TrainsProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var application = TrainsProblemApplication.GetInstance();
            application.Start();    
        }
    }
}
