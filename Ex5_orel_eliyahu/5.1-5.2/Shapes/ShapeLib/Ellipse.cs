using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape, IPersist, IComparable
    {
        public double HeightRadius { get; private set; }
        public double WidthRadius { get; private set; }

        public Ellipse(double rheight, double rwidth) :base()
        {
            HeightRadius = rheight;
            WidthRadius = rwidth;
        }
        public override double Area
        {
            get
            {
                return HeightRadius * WidthRadius *3.14;
            }
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Height Radius: " + HeightRadius);
            Console.WriteLine("Width Radius: " + WidthRadius);
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine("Height Radius: " + HeightRadius).AppendLine("Width Radius: " + WidthRadius);
        }

        public int CompareTo(object obj)
        {
            Ellipse other = obj as Ellipse;
            if (other == null) { throw new InvalidCastException(); }
            return Area.CompareTo(other.Area);
        }
    }
}
