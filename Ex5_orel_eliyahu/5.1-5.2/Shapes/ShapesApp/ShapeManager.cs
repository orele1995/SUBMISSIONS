using ShapeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
   public class ShapeManager
    {

        ArrayList shapes = new ArrayList();
        public void Add (Shape shape)
        {
            shapes.Add(shape);
        }  
        public void DisplayAll()
        {
            foreach (Shape shape in shapes)
            {
                shape.Display();
                Console.WriteLine("Area: "+shape.Area);
                Console.WriteLine("******************");
            }
        }
        public Shape this[int i]
        {
            get { return shapes[i] as Shape; }
        }
        public int Count { get { return shapes.Count; } }
        public void Save(StringBuilder sb)
        {
            foreach (Shape shape in shapes)
           {
                IPersist s =shape as IPersist;
                if ( s != null)
                {
                    s.Write(sb);
                }
            }
            Console.WriteLine(sb.ToString());
        }


    }
}
