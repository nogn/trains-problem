namespace TrainsProblem.TownRoutes.Models
{
    class TownRouteModel
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
