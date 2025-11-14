public class IndustrialBuilding : Construction, IManufacturable
{
    private int safetyLevel;

    public IndustrialBuilding(string address, int year, int safetyLevel) : base(address, year)
    {
        this.safetyLevel = safetyLevel;
    }

    public void Produce() => Console.WriteLine($"Запущено производство! Уровень безопасности: {safetyLevel}");
    public int GetSafetyLevel() => safetyLevel;
    public override string GetInfo() => base.GetInfo() + $", Тип: Производственный корпус, Уровень безопасности: {safetyLevel}";
}