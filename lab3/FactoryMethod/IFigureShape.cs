using System;

namespace DesignPatterns.FactoryMethod
{
    public class IFigureShape : IFigure
    {
        public string GetName() => "I";
        public int GetCellsCount() => 4;
        
        public void Display()
        {
            Console.WriteLine("████");
        }
    }
}
