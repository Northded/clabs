namespace StructuralPatternsLab.AdapterPattern
{
    public interface IGasCylinderAdapter
    {
        double CalculateDp(int T0, int dT);
        void ModifMass(double dm);
        string GetData();
    }
}
