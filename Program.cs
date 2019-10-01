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

            int dataSet = int.Parse(Console.ReadLine());
            for(int i = 0; i < dataSet; i++)
            {
                int vertices = int.Parse(Console.ReadLine());
                for(int j = 0; j < vertices; j++)
                {
                    string input = Console.ReadLine();
                    string[] parts = input.Split(' ');
                    int v1 = int.Parse(parts[0]);
                    int v2 = int.Parse(parts[1]);
                    Console.WriteLine("V1: {0} V2: {0}", v1, v2);
                }
                string line = Console.ReadLine();
                if(line == "-1")
                {
                    Console.WriteLine(line);
                }
            }

            Console.SetIn(stdIn);
            Console.ReadLine();
        }
    }
}
