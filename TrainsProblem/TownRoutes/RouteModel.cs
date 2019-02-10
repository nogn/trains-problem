namespace TrainsProblem.TownRoutes
{
    public class RouteModel
    {
        public char Source { get; set; }
        public char Destination { get; set; }
        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{Source}{Destination}{Distance}";
        }
    }
}
