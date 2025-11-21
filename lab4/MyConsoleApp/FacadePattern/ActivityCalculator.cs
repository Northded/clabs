namespace StructuralPatternsLab.FacadePattern
{
    internal class ActivityCalculator
    {
        public double GetActivityCoefficient(ActivityLevel level) => level switch
        {
            ActivityLevel.Low => 1.2,
            ActivityLevel.Medium => 1.55,
            ActivityLevel.High => 1.9,
            _ => 1.2
        };
    }
}
