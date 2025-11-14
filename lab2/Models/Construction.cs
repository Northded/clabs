public abstract class Construction : IBuilding
{
    protected string address;
    protected int year;

    public Construction(string address, int year)
    {
        this.address = address;
        this.year = year;
    }

    public string GetAddress() => address;
    public int GetYear() => year;
    public virtual string GetInfo() => $"Адрес: {address}, Год постройки: {year}";
}