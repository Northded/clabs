using System;

namespace StructuralPatternsLab.FacadePattern
{
    public class CalorieCalculatorFacade
    {
        private Asthenic _asthenic = new Asthenic();
        private Normosthenic _normosthenic = new Normosthenic();
        private Hypersthenic _hypersthenic = new Hypersthenic();
        private ActivityCalculator _activityCalculator = new ActivityCalculator();

        public double CalculateForAsthenic(int h, int w, int a, Gender g, ActivityLevel act)
            => _asthenic.CalculateBasalMetabolicRate(h, w, a, g) * _activityCalculator.GetActivityCoefficient(act);

        public double CalculateForNormosthenic(int h, int w, int a, Gender g, ActivityLevel act)
            => _normosthenic.CalculateBasalMetabolicRate(h, w, a, g) * _activityCalculator.GetActivityCoefficient(act);

        public double CalculateForHypersthenic(int h, int w, int a, Gender g, ActivityLevel act)
            => _hypersthenic.CalculateBasalMetabolicRate(h, w, a, g) * _activityCalculator.GetActivityCoefficient(act);

        public string GetCalorieReport(string bodyType, int height, int weight, int age, Gender gender, ActivityLevel activity)
        {
            double result = bodyType.ToLower() switch
            {
                "астеник" => CalculateForAsthenic(height, weight, age, gender, activity),
                "нормостеник" => CalculateForNormosthenic(height, weight, age, gender, activity),
                "гиперстеник" => CalculateForHypersthenic(height, weight, age, gender, activity),
                _ => throw new ArgumentException("Неизвестный тип телосложения")
            };
            return $"Тип телосложения: {bodyType}\nРост: {height} см, Вес: {weight} кг, Возраст: {age} лет, Пол: {gender}\nАктивность: {activity}\nЕжедневная норма калорий: {result:F0} ккал";
        }
    }
}
