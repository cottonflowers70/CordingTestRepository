using System;
using System.Collections.Generic;

namespace CordingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            string[] elements = Console.ReadLine().Split(' ');
            int N;
            if (!int.TryParse(elements[0], out N))
            {
                Console.WriteLine("Error");
            }
            int K;
            if (!int.TryParse(elements[1], out K))
            {
                Console.WriteLine("Error");
            }
            int[] Ks = new int[K];
            int[] Ns = new int[N - K];
            if (!int.TryParse(Console.ReadLine(), out Ks[0]))
            {
                Console.WriteLine("Error");
            }
            SortedSet<int> lion = new SortedSet<int>();
            int difference = 0;
            int sum = 0;
            for (int i = 1; i < K; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out Ks[i]))
                {
                    Console.WriteLine("Error");
                }
                lion.Add(Ks[i]);
                difference = Ks[i-1]- Ks[i];
                sum += difference < 0 ? -difference : difference;
                Console.WriteLine(i+"'s difference : "+ difference);
                Console.WriteLine(i+ "'s sum : " + sum);
            }
            int hightNum = lion.Max;
            int lowNum = lion.Min;
            //int hightnoLionIndex = -1;
            //int lownoLionIndex = -1;
            SortedSet<int> ant = new SortedSet<int>();
            for (int i = 0; i < Ns.Length; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out Ns[i]))
                {
                    Console.WriteLine("Error");
                }
                ant.Add(Ns[i]);
            }
            int hightnoLion = ant.Max > hightNum ? ant.Max : -1;
            int lownoLion = ant.Min < lowNum ? ant.Min : -1;

            Console.WriteLine("hightNum : " + hightNum);
            Console.WriteLine("lowNum : " + lowNum);
            Console.WriteLine("hightnoLion : " + hightnoLion);
            Console.WriteLine("lownoLion : " + lownoLion);
            difference = 0;
            SortedSet<int> gap = new SortedSet<int>();
            
            if (hightnoLion != -1)
            {
                difference = Ks[0] - hightnoLion;
                gap.Add(difference < 0 ? -difference : difference);
                for (int i = 1; i < K; i++)
                {
                    difference = 0;
                    difference += Ks[i-1] > hightnoLion? Ks[i - 1] - hightnoLion: hightnoLion - Ks[i - 1];
                    difference += Ks[i] > hightnoLion? Ks[i] - hightnoLion: hightnoLion - Ks[i];
                    difference -= Ks[i] > Ks[i - 1] ? Ks[i] - Ks[i - 1] : Ks[i - 1] - Ks[i];
                    gap.Add(difference);
                }
                difference = Ks[K-1] - hightnoLion;
                gap.Add(difference < 0 ? -difference : difference);
                sum += gap.Min;
            }
            gap.Clear();
            Console.WriteLine("hightnoLion's difference : " + difference);
            Console.WriteLine("hightnoLion's sum : " + sum);
            if (lownoLion != -1)
            {
                difference = Ks[0] - lownoLion;
                gap.Add(difference < 0 ? -difference : difference);
                for (int i = 1; i < K; i++)
                {
                    difference = 0;
                    difference += Ks[i - 1] > lownoLion ? Ks[i - 1] - lownoLion : lownoLion - Ks[i - 1];
                    difference += Ks[i] > lownoLion ? Ks[i] - lownoLion : lownoLion - Ks[i];
                    difference -= Ks[i] > Ks[i - 1] ? Ks[i] - Ks[i - 1] : Ks[i - 1] - Ks[i];
                    gap.Add(difference);
                }
                difference = Ks[K - 1] - lownoLion;
                gap.Add(difference < 0 ? -difference : difference);
                sum += gap.Min;
            }
            Console.WriteLine("lownoLion's difference : " + difference);
            Console.WriteLine("lownoLion's sum : " + sum);
            Console.WriteLine("difference : "+ sum);
        }
    }
}
