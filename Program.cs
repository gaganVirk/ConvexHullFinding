using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHullFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader stdIn = Console.In;
            Console.SetIn(new StreamReader("data.txt"));

            List<Point> points = new List<Point>();
            List<Point> hull = new List<Point>();
            Point pivot = new Point(int.MaxValue, int.MaxValue);

            int times = 6;
            while (times <= 6)
            {
                int k = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    string[] vertices = input.Split(' ');
                    int v1 = int.Parse(vertices[0]);
                    int v2 = int.Parse(vertices[1]);

                    if (pivot.X > v1)
                    {
                        if (pivot.Y > v1)
                        {
                            pivot = new Point(v1, v2);
                        }
                    }
                    points.Add(new Point(v1, v2));
                }
            }

            points.Sort(new Rad(pivot));
            Console.WriteLine(pivot);

            bool isValidHull()
            {
                if(hull.Count < 3)
                {
                    return true;
                }
                Point a = hull[hull.Count - 3];
                Point b = hull[hull.Count - 2];
                Point c = hull[hull.Count - 1];
                int cw = a.X * b.Y - b.X * a.Y + b.X * c.Y - c.X * b.Y + c.X * a.Y - a.X * c.Y;
                return cw > 0;
            }

            Console.SetIn(stdIn);
            Console.ReadLine();
        }
    }
}
