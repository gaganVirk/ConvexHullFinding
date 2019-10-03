using System;
using System.Collections.Generic;
using System.Globalization;
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

            string line = Console.ReadLine();
            int dataSet = int.Parse(line);

            for(int j = 0; j < dataSet; j++)
            {
                line = Console.ReadLine();
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("N: {0}", n);
                for (int i = 0; i < n; i++)
                {
                    string[] vertices = line.Split(' ');

                    int v1 = int.Parse(vertices[0]);
                    int v2 = int.Parse(vertices[1]);
                    Console.WriteLine("V1: {0} V2: {1}", v1, v2);
                    if (pivot.X > v1)
                    {
                        if (pivot.Y > v1)
                        {
                            pivot = new Point(v1, v2);
                        }
                    }
                    points.Add(new Point(v1, v2));
                }
                string line = Console.ReadLine();
                if(line == "-1")
                {
                    Console.WriteLine(line);
                }

            }



            points.Sort(new Rad(pivot));
            Console.WriteLine("Pivot is" +pivot);

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

            static Point LowestYThenLowestX(List<Point> points)
            {
                int lowestY = points.Min(m => m.Y);
                var lowYs = points.Where(m => (m.Y == lowestY));
                if (lowYs.Count() > 1)
                {
                    int lowestX = lowYs.Min(m => m.X);
                    return lowYs.Where(m => m.X == lowestX).First();
                }
                else
                {
                    return lowYs.First();
                }
            }
        }
    }
}
