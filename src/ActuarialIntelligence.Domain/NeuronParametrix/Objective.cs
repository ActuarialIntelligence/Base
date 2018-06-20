namespace ActuarialIntelligence.Domain.NeuronParametrix
{
    /// <summary>
    /// Objective will be a requirement on a set of parameters: 
    /// (E.g. height, weight, time it takes a person to move this object)
    /// (The above is why: If one truly knows 
    /// the question; the answer is self evident)
    /// </summary>
    public static class Objective
    {
        public static string objective { get { return "Height"; } }
        public static double Height { get{ return 100; } }
        public static double MarginOfAllowledError { get { return 10; } }
    }
}
