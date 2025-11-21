namespace StructuralPatternsLab.FacadePattern
{
    internal class Normosthenic
    {
        public double CalculateBasalMetabolicRate(int height, int weight, int age, Gender gender)
        {
            return gender == Gender.Male ?
                66.5 + 13.75 * weight + 5.003 * height - 6.75 * age :
                655.1 + 9.563 * weight + 1.85 * height - 4.676 * age;
        }
    }
}
