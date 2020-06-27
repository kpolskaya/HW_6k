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
            int n = 50;
            int num = n + 1;
            int i;
            byte[] numbers = new byte[n + 1];
            numbers[0] = 1;
            numbers[1] = 1;
 
            for (i = 2;  i < num ; i++)
            {
                if (numbers[i] == 0)
                {
                    for (int j = i * 2; j < num; j += i)
                      //  if (numbers[j] == 0)
                            numbers[j] = (byte)i;
                }
                if (numbers[i] == 0)
                {
                    numbers[i] = 2;
                }
                else
                {
                    int k = i / numbers[i];
                    numbers[i] = (byte)(numbers[k] + 1);
                }

            }

            byte cGroup = (byte)(Convert.ToByte(Math.Floor(Math.Log2(n))) + 1);

            for (int c = 1; c <= cGroup; c++)
            {
                Console.Write($"Группа №{c}:\t");
                for (int j = 1; j < numbers.Length; j++)
                {

                    if (numbers[j] == c)
                    {
                        Console.Write($" {j}");
                    }

                }
                Console.WriteLine();
            }

            //Console.WriteLine( BitConverter.ToString( numbers, 2 )) ;
            //Console.WriteLine();
            //Array.ForEach(gr, Console.WriteLine);
            TimeSpan timeSpan1 = DateTime.Now.Subtract(start);
            Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan1.TotalSeconds}");
            //Console.WriteLine();

            Console.ReadKey();

        }

    }
}

