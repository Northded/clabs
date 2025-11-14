public class Hotel : Construction, IAccommodable
{
    private int roomsCount;

    public Hotel(string address, int year, int roomsCount) : base(address, year)
    {
        this.roomsCount = roomsCount;
    }

    public void BookRoom() => Console.WriteLine($"Комната в отеле забронирована! Доступно комнат: {roomsCount}");
    public int GetRoomsCount() => roomsCount;
    public override string GetInfo() => base.GetInfo() + $", Тип: Гостиница, Комнат: {roomsCount}";
}