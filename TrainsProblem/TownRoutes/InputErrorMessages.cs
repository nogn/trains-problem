namespace TrainsProblem.TownRoutes
{
    public static class InputErrorMessages
    {
        public const string InvalidInputLength = "The input should be either a valid route or the finishing command 'OK'.";
        public const string InvalidSourceInput = "The first digit of the input should be a letter.";
        public const string InvalidDestinationInput = "The second digit of the input should be a letter.";
        public const string InvalidDistanceInput = "The third digit of the input should be a number.";
        public const string EqualSourceAndDestination = "The starting and ending town should not be the same town.";
        public const string InvalidDistanceInputRange = "The distance input should be a positive number.";
        public const string RepeatedRoute = "A given route should not appear more than once.";
    }
}
