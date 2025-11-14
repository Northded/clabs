using System;

namespace DesignPatterns.FactoryMethod
{
    public class SuperFigureShape : IFigure
    {
        public string GetName() => "SUPER";
        public int GetCellsCount() => 8;
        
        public void Display()
        {
            Console.WriteLine("████████");
        }
    }
}
