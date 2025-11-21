using System;

namespace StructuralPatternsLab.AdapterPattern
{
    public class GasCylinderAdapter : IGasCylinderAdapter
    {
        private GasCylinder _cylinder;

        public GasCylinderAdapter(GasCylinder cylinder)
        {
            _cylinder = cylinder;
        }

        public double CalculateDp(int T0, int dT)
        {
            double p0 = _cylinder.GetPressure(T0);
            double p1 = _cylinder.GetPressure(T0 + dT);
            return p1 - p0;
        }

        public void ModifMass(double dm)
        {
            _cylinder.Mass += dm;
            Console.WriteLine($"Масса изменена на {dm} кг. Новая масса: {_cylinder.Mass} кг");
        }

        public string GetData()
        {
            double pressure = _cylinder.GetPressure(273);
            double amount = _cylinder.AmountOfMatter();
            return $"{_cylinder}\nКоличество вещества: {amount:F3} моль\nДавление при 273K: {pressure:F2} Па";
        }
    }
}
