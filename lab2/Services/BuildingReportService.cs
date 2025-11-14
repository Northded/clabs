public class BuildingReportService
{
    private readonly IBuilding building;

    public BuildingReportService(IBuilding building)
    {
        this.building = building;
    }

    public void PrintReport()
    {
        Console.WriteLine("ОТЧЕТ ПО СТРОЕНИЮ");
        Console.WriteLine(building.GetInfo());
        Console.WriteLine("------------------");
    }
}