using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        protected double area;
        public ConsoleColor Color { get; set; }
        public abstract double Area { get; }
        public Shape(ConsoleColor _color)
        {
            Color = _color;
        }
        public Shape()
        {
            Color = ConsoleColor.White;
        }
        virtual public void Display()
        {
            Console.ForegroundColor = Color;
        }
    }
}
