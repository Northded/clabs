class Program
{
    static void Main(string[] args)
    {
        // Создаем объекты
        var theatre = new Theatre("ул. Театральная, 1", 1985, 500);
        var hotel = new Hotel("ул. Гостиничная, 15", 2010, 120);
        var industrial = new IndustrialBuilding("пр. Заводской, 77", 1978, 8);
        var construction = new IndustrialBuilding("ул. Строителей, 10", 2005, 5);

        // Используем принцип подстановки LSP
        List<IBuilding> buildings = new List<IBuilding> { theatre, hotel, industrial, construction };

        foreach (var building in buildings)
        {
            var reportService = new BuildingReportService(building);
            reportService.PrintReport();

            // Используем специфичные интерфейсы без нарушения ISP
            if (building is IEntertainable entertainable)
            {
                entertainable.PerformShow();
            }

            if (building is IAccommodable accommodable)
            {
                accommodable.BookRoom();
            }

            if (building is IManufacturable manufacturable)
            {
                manufacturable.Produce();
            }

            Console.WriteLine();
        }
    }
}