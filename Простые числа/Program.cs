using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int n = 1000000000;
            int topNumber = n+1;
            int i;
            byte[] gr = new byte[n +1];
            int[] numbers = new int[n+ 1];

            for (i = 2; i < topNumber; i++)
            {
                if (numbers[i] == 0)

                {
                    for (int j = i * 2; j < topNumber; j += i)
                        if (numbers[j] == 0)
                            numbers[j] = i;
                }
            }
            gr[0] = 1;
            gr[1] = 1;
            gr[2] = 2;
            gr[3] = 2;

            for (i = 4; i < topNumber; i++)
            { 
                if (numbers[i] == 0)
                {
                    gr[i] = 2;
                }
                else
                {
                    int k = i / numbers[i];
                    gr[i] = (byte)(gr[k] + 1);
                }
            }

            //Array.ForEach(numbers, Console.WriteLine);
            //Console.WriteLine();
            //Array.ForEach(gr, Console.WriteLine);
            TimeSpan timeSpan1 = DateTime.Now.Subtract(start);
            Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan1.TotalSeconds}");
            //Console.WriteLine();

            Console.ReadKey();

        }
      
    }
}

  