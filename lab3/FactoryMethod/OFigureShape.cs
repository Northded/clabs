using System;

namespace DesignPatterns.FactoryMethod
{
    public class OFigureShape : IFigure
    {
        public string GetName() => "O";
        public int GetCellsCount() => 4;
        
        public void Display()
        {
            Console.WriteLine("██");
            Console.WriteLine("██");
        }
    }
}
