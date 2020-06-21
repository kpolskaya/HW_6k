using System;

namespace НОД
{
    class Program

    {
        static int NOD (int a, int b)

        {
            while (b>a)
            { 
               b = b - a;
            }
            return b ;
        }


            static void Main(string[] args)
        {
            //int a = 2;
            //int b = 4;
            //Console.WriteLine ($"{ NOD( a, b)}");
            int[] mp = new int[50]; //длина неправильная
            int j = 1;
            mp[0] = 2;
            bool isOK;
            for (int i = 2; i < 50; i++)
            {
                if (NOD(i + 1, i) == 1)
                {
                    isOK = true;
                    for (int k = 0; k < j; k++)
                    {
                        if (NOD(i + 1, mp[k]) != 1)
                        {
                            isOK = false;
                            break;
                        }
                    }

                    if (isOK)
                        mp[j++] = i + 1;
                }

            }

            // вывод группы:
            foreach (var item in mp)
            {
                Console.Write($"  {item}");
            }
            Console.ReadKey();
        }
    }
}
