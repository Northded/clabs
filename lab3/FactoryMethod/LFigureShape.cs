using System;

namespace DesignPatterns.FactoryMethod
{
    public class LFigureShape : IFigure
    {
        public string GetName() => "L";
        public int GetCellsCount() => 4;
        
        public void Display()
        {
            Console.WriteLine("█  ");
            Console.WriteLine("█  ");
            Console.WriteLine("██");
        }
    }
}
