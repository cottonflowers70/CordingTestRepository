using System;
using System.Collections.Generic;

namespace CordingTest
{//34979
    class Program
    {
        static void Main(string[] args)
        {
            // N : 반의 개수
            // Q : 쿼리의 수
            // 1 <= N,Q <= 1000
            string[] elements = Console.ReadLine().Split(' ');
            int N;
            int Q;

            if (!int.TryParse(elements[0], out N))
            {
                Console.WriteLine("Error");
            }
            if (!int.TryParse(elements[1], out Q))
            {
                Console.WriteLine("Error");
            }
            int[,] Qs = new int[4,N];
            int[] temp = new int[3];
            List<int> answerList = new List<int>();
            for (int i = 0; i < Q; i++)
            {
                elements = Console.ReadLine().Split(' ');
                for (int j = 0; j < elements.Length; j++)
                {
                    if (!int.TryParse(elements[j], out temp[j]))
                    {
                        Console.WriteLine("Error");
                    }
                }
                if (temp[0].Equals(1))
                {
                    if (temp[1].Equals(1))
                    {
                        if (temp[2].Equals(1))
                        {
                            Qs[0, 0] -= 1;
                            Qs[1, 0] -= 1;
                            if(N>1)
                            Qs[0, 1] -= 1;
                        }
                        else if (temp[2].Equals(N))
                        {
                            Qs[0, N-1] -= 1;
                            Qs[1, N-1] -= 1;
                            Qs[0, N-1 - 1] -= 1;
                        }
                        else
                        {
                            Qs[0, temp[2]-1] -= 1;
                            Qs[1, temp[2]-1] -= 1;
                            Qs[0, temp[2]-1 - 1] -= 1;
                            Qs[0, temp[2]-1 + 1] -= 1;
                        }
                    }
                    else if (temp[1].Equals(4))
                    {
                        if (temp[2].Equals(1))
                        {
                            Qs[3, 0] -= 1;
                            Qs[2, 0] -= 1;
                            if (N > 1)
                                Qs[3, 1] -= 1;
                        }
                        else if (temp[2].Equals(N))
                        {
                            Qs[3, N-1] -= 1;
                            Qs[2, N-1] -= 1;
                            Qs[3, N-1 - 1] -= 1;
                        }
                        else
                        {
                            Qs[3, temp[2]-1] -= 1;
                            Qs[2, temp[2]-1] -= 1;
                            Qs[3, temp[2]-1 - 1] -= 1;
                            Qs[3, temp[2]-1 + 1] -= 1;
                        }
                    }
                    else
                    {
                        if (temp[2].Equals(1))
                        {
                            Qs[temp[1] - 1, 0] -= 1;
                            Qs[temp[1] - 1 - 1, 0] -= 1;
                            Qs[temp[1] - 1 + 1, 0] -= 1;
                            if (N > 1)
                                Qs[temp[1] - 1, 1] -= 1;
                        }
                        else if (temp[2].Equals(N))
                        {
                            Qs[temp[1] - 1, N-1] -= 1;
                            Qs[temp[1] - 1 - 1, N-1] -= 1;
                            Qs[temp[1] - 1 + 1, N-1] -= 1;
                            Qs[temp[1] - 1, N-1 - 1] -= 1;
                        }
                        else
                        {
                            Qs[temp[1] - 1, temp[2] - 1] -= 1;
                            Qs[temp[1] - 1 - 1, temp[2] - 1] -= 1;
                            Qs[temp[1] - 1 + 1, temp[2] - 1] -= 1;
                            Qs[temp[1] - 1, temp[2] - 1 - 1] -= 1;
                            Qs[temp[1] - 1, temp[2] - 1 + 1] -= 1;
                        }
                    }
                }
                else if (temp[0].Equals(2))
                {
                    int tempresultClass = 0;
                    int tempresultStress = 0;
                    for (int k = 0; k < N; k++)
                    {
                        if (tempresultStress > Qs[temp[1] - 1, k])
                        {
                            tempresultClass = k;
                            tempresultStress = Qs[temp[1] - 1, k];
                        }
                    }
                    answerList.Add(tempresultClass + 1);
                }
            }
            int resultClass = 0;
            int resultFloor = 0;
            int resultStress = 0;
            for(int i = 0; i < 4; i++)
            {
                for (int k = 0; k < N; k++)
                {
                    if (resultStress > Qs[i, k])
                    {
                        resultClass = k;
                        resultFloor = i;
                        resultStress = Qs[i, k];
                    }
                }
            }
            resultFloor++;
            resultClass++;
            for(int i =0; i<answerList.Count; i++)
            {
                Console.WriteLine(answerList[i]);
            }
            Console.WriteLine(resultFloor+" "+resultClass);
        }
    }
}