using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape, IPersist, IComparable
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width):base()
        {
            Height = height;
            Width = width;
        }
        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Width: " + Width);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Height: " + Height).AppendLine("Width: " + Width);
        }

        public int CompareTo(object obj)
        {
            Rectangle other = obj as Rectangle;
            if (other == null) { throw new InvalidCastException(); }
            return Area.CompareTo(other.Area);
        }
    }
}
