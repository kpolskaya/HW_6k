using System;
using System.Linq;
using System.Text;
using System.Collections;

namespace НОД
{
    class Program

    {

        /// <summary>
        /// Ввод с консоли целого числа с проверкой диапазона значений. Возвращает целое число.
        /// </summary>
        /// <param name="message"> Приглашение к вводу </param>
        /// <param name="min">Минимальное допустимое значение </param>
        /// <param name="max">Максимальное допустимое значение </param>
        /// <returns></returns>
        static int GetNum(string message, int min, int max)
        {
            int num;
            Console.Write($"{message} (от {min} до {max}): ");
            do
            {
                if (int.TryParse(Console.ReadLine(), out num) && num >= min && num <= max)
                    break;
                else
                    Console.Write("Вы ввели недопустимое значение. Попробуйте еще: ");

            } while (true);
            return num;
        }


        static int [] Primes (int n)
        {
            //DateTime start = DateTime.Now;
            int topNumber = n;

            int[] Nums = new int[n];

            var numbers = new BitArray(topNumber, true);

            for (int i = 2; i < topNumber; i++)
                if (numbers[i])
                {
                    for (int j = i * 2; j < topNumber; j += i)
                        numbers[j] = false;
                }

            int primes = 0;
            for (int i = 1; i < topNumber; i++)
                if (numbers[i])
                {
                    Nums[primes++] = i;
                }
            //Console.WriteLine($"итого {primes}");
            Array.Resize(ref Nums, primes);
            //Array.ForEach(Nums, Console.WriteLine);
            //TimeSpan timeSpan = DateTime.Now.Subtract(start);
            //Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan.TotalSeconds}");
            //Console.WriteLine();
            //Console.Out.WriteLine(primes + " out of " + topNumber + " prime numbers found.");
            //Console.ReadLine();

            return Nums;
        }


        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int m;
            int n = GetNum("Введите число от 1 до 1 000 000 000", 1, 1000000000);
            int gr;
            int k;
            int p;
            int j;
            var c = Convert.ToInt32(Math.Floor( Math.Log2(n)))+1;
            //Console.WriteLine(c);
            int[][] groups = new int[c+1][];
            //groups[0][0] = 1;     // объявить первый массив из 1
           
            groups[1] = Primes(n);
            Array.Clear(groups[1], 0, 1);
            groups[1] = groups[1].Where(x => x != 0).ToArray();
            Array.ForEach(groups[1], Console.WriteLine);
            for (m = 2; m < c; m++)
            {
                groups [m] = new int[n];
                k = 0;
                p = 0;
               
                for (j = 0; j < n; j++)
                {
                    gr = groups[1][p]*groups[m - 1][k];
                    if (gr<=n)
                    {
                        groups[m][j] = gr;
                        k++;
                    }
                    else
                    {
                        j--;
                        k = p+1+m-2;
                        p++;
                        if (groups[1][p] * groups[m - 1][k]>n)
                        {
                            break;
                        }
                        continue;
                    }
                }
               // Array.Resize(ref groups[m], j+1);
               
                

            }
            Array.Sort(groups[2]);
            Array.ForEach(groups[2], Console.Write);
            Console.WriteLine();
            TimeSpan timeSpan1 = DateTime.Now.Subtract(start);
            Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan1.TotalSeconds}");
            // Array.ForEach(groups[m], Console.WriteLine);


            Console.ReadKey();
        }
    }
}
