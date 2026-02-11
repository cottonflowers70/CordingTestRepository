using System;
using System.Collections.Generic;

namespace CordingTest
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] elements = Console.ReadLine().Split(' ');
            int[] T = new int[4];
            SortedSet<int> sort = new SortedSet<int>();
            for (int i = 0; i < T.Length; i++)
            {
                if (!int.TryParse(elements[i], out T[i]))
                {
                    Console.WriteLine("Error");
                }
                sort.Add(T[i]);
            }
            int playTime = 0;
            if (sort.Min != 0)
            {
                for (int i = 0; i < T.Length; i++)
                {
                    T[i] -= sort.Min;
                    playTime += sort.Min;
                }
                if (T[1].Equals(0))
                    if (T[0].Equals(0))
                    {
                        if (!T[3].Equals(0))
                            playTime += T[3];
                        Console.WriteLine(playTime);
                        return;
                    }
                    else
                    {
                        playTime += T[0];
                        if (!T[3].Equals(0))
                            playTime += T[3];
                        Console.WriteLine(playTime);
                        return;
                    }

            }
            bool isSlowStart = T[0].Equals(0) && T[1].Equals(0);
            if (isSlowStart)
            {
                playTime += T[3];
                if (!T[2].Equals(0))
                    playTime++;
            }
            else
            {
                if (T[1].Equals(0))
                {
                    playTime += T[0];
                    Console.WriteLine(playTime);
                    return;
                }
                if (T[1].Equals(0) || T[2].Equals(0))
                    if (!(T[1].Equals(0) && T[2].Equals(0))) 
                        playTime++;
                    else
                    {

                    }
                else
                {
                    playTime += T[1] > T[2] ? (2 * T[2]) + 1 : 2 * T[1];
                }
                if (!(T[1].Equals(0) && T[2].Equals(0)))
                    playTime += T[3];
                playTime += T[0];
            }
            Console.WriteLine(playTime);
        }
    }
}