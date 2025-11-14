public class Theatre : Construction, IEntertainable
{
    private int capacity;

    public Theatre(string address, int year, int capacity) : base(address, year)
    {
        this.capacity = capacity;
    }

    public void PerformShow() => Console.WriteLine($"В театре началось представление! Вместимость: {capacity} зрителей");
    public int GetCapacity() => capacity;
    public override string GetInfo() => base.GetInfo() + $", Тип: Театр, Вместимость: {capacity}";
}