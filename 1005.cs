using System;
using System.Collections.Generic;

namespace CordingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = 0;
            string[] elements;
            int N = 0;
            int K = 0;
            int[] Ns;
            int KPointX = 0;
            int KPointY = 0;
            int[,] Ks;
            int W;
            if (!int.TryParse(Console.ReadLine(), out T))
            {
                Console.WriteLine("Error");
            }
            for (int q = 0; q < T; q++)
            {
                elements = Console.ReadLine().Split(' ');
                N = 0;
                int.TryParse(elements[0], out N);
                Ns = new int[N];
                K = 0;
                int.TryParse(elements[1], out K);
                Ks = new int[N + 1, N + 1];
                elements = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; i++)
                {
                    if (!int.TryParse(elements[i], out Ns[i]))
                    {
                        Console.WriteLine("Error");
                    }
                }
                for (int i = 0; i < K; i++)
                {
                    elements = Console.ReadLine().Split(' ');
                    if (!int.TryParse(elements[0], out KPointX))
                    {
                        Console.WriteLine("Error");
                    }
                    if (!int.TryParse(elements[1], out KPointY))
                    {
                        Console.WriteLine("Error");
                    }
                    Ks[KPointX, KPointY] = -1;
                }
                if (!int.TryParse(Console.ReadLine(), out W))
                {
                    Console.WriteLine("Error");
                }
                Queue<check> target = new Queue<check>();
                int check;
                int sumTime;
                target.Enqueue(new check(W,Ns[W-1]));
                int count;
                int longest = 0;
                while (target.Count > 0)
                {
                    count = 0;
                    check = target.Peek().target;
                    sumTime = target.Dequeue().time;
                    for (int i = 1; i < N + 1; i++)
                    {
                        if (Ks[i, check].Equals(-1))
                        {
                            count++;
                            target.Enqueue(new check(i, Ns[i - 1] + sumTime));
                        }
                    }
                    if (count.Equals(0))
                    {
                        if (sumTime > longest)
                            longest = sumTime;
                    }
                }
                Console.WriteLine(longest);
            }
        }
    }
    public class check
    {
        public int target;
        public int time;
        public check(int target,int time)
        {
            this.target = target;
            this.time = time;
        }
    }
}
