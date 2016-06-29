using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager shapeManager = new ShapeManager();
            int choice = 0, i, j;
            double height, width;
            printMenue();
            choice = int.Parse(Console.ReadLine());

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter height and width");
                        height = int.Parse(Console.ReadLine());
                        width = int.Parse(Console.ReadLine());
                        shapeManager.Add(new Rectangle(height, width));

                        break;
                    case 2:
                        Console.WriteLine("enter height radius and width radius");
                        height = int.Parse(Console.ReadLine());
                        width = int.Parse(Console.ReadLine());
                        shapeManager.Add(new Ellipse(height, width));
                        break;
                    case 3:
                        Console.WriteLine("enter radius");
                        height = int.Parse(Console.ReadLine());
                        shapeManager.Add(new Circle(height));
                        break;
                    case 4:
                        shapeManager.DisplayAll();
                        break;
                    case 5:
                        Console.WriteLine("enter 2 indexes to compare: ");
                        i = int.Parse(Console.ReadLine());
                        j = int.Parse(Console.ReadLine());
                        if (i >= shapeManager.Count || j >= shapeManager.Count)
                        {
                            Console.WriteLine("index out of range!");
                            break;
                        }
                        IComparable shape1 = shapeManager[i] as IComparable;
                        IComparable shape2 = shapeManager[j] as IComparable;
                        try
                        {
                            if (shape1 == null && shape2 as IComparable == null)
                            {
                                Console.WriteLine("Error! not icomperable!");
                                break;
                            }
                            else if (shape1 == null)
                            {
                                if (shape2.CompareTo(shapeManager[i]) == 0)
                                { Console.WriteLine("equal"); }
                                else { Console.WriteLine("not equal"); }

                            }
                            else
                            {
                                if (shape1.CompareTo(shapeManager[j]) == 0)
                                { Console.WriteLine("equal"); }
                                else { Console.WriteLine("not equal"); }
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 6:
                        Console.WriteLine("enter string to add");
                        StringBuilder sb = new StringBuilder(Console.ReadLine());
                        shapeManager.Save(sb);
                        break;
                }
                printMenue();
                choice = int.Parse(Console.ReadLine());

            }
        }

        static private void printMenue()
        {
            Console.WriteLine("1 - to add a rectangle");
            Console.WriteLine("2 - to add an ellipse");
            Console.WriteLine("3 - to add a circle");
            Console.WriteLine("4 - to display all");
            Console.WriteLine("5 - to compare 2 shapes");
            Console.WriteLine("6 - to use save");
            Console.WriteLine("0 - to exit");
        }
    }
}
