namespace StructuralPatternsLab.AdapterPattern
{
    public class GasCylinder
    {
        public double Volume { get; set; }
        public double Mass { get; set; }
        public double Molar { get; set; }

        public GasCylinder(double volume, double mass, double molar)
        {
            Volume = volume;
            Mass = mass;
            Molar = molar;
        }

        public double GetPressure(int T)
        {
            const double R = 8.31;
            return (Mass / Molar) * R * T / Volume;
        }

        public double AmountOfMatter() => Mass / Molar;

        public override string ToString() => $"Баллон: Объём={Volume} м³, Масса={Mass} кг, Молярная масса={Molar} кг/моль";
    }
}
