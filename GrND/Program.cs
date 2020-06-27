using System;
using System.Linq;

namespace GrND
{
    class Program
    {
 
        static int[] GroupND(int[] mas)
        {
            int j = 1;
            int[] mask = new int[mas.Length];
            mask[0] = mas[0];

            bool ND;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] % mas[i + 1] != 0)
                {
                    ND = true;
                    for (int k = 1; k < j; k++)
                    {

                        if (mas[i + 1] % mask[k - 1] == 0)
                        {
                            ND = false;
                            break;
                        }
                    }

                    if (ND)
                        mask[j++] = mas[i + 1];
                }

            }
            Array.Resize(ref mask, j);
            return mask;
        }


        static void Main(string[] args)
        {
            //DateTime start = DateTime.Now;
            int n = 100;
            int[] mas = new int[n - 1];
            for (int j = 0; j < n - 1; j++)
                mas[j] = j + 2;
            //TimeSpan timeSpan0 = DateTime.Now.Subtract(start);
            //Console.WriteLine($"начало GroupND  = {timeSpan0.TotalSeconds}");
            int m;
            int[] gr = new int[mas.Length];
            int[][] groups = new int[20][];
            //groups[1] = GroupND2(mas);
            //mas = mas.Except<int>(groups[1]).ToArray<int>();
           // TimeSpan timeSpan1 = DateTime.Now.Subtract(start);
            //Console.WriteLine($"группа {1}");
           // Console.WriteLine($"длительность GroupND = {timeSpan0.TotalSeconds - timeSpan1.TotalSeconds}");

            //Console.WriteLine($"Длина группы {groups[1].Length}");

            for (m = 1; m < mas.Length + 1; m++)
            {
                Console.WriteLine($"группа {m}");

                gr = GroupND(mas);
                Array.ForEach(gr, Console.WriteLine);
               Console.WriteLine($"Длина группы {gr.Length}");
                Console.WriteLine();
                //gr = GroupND2(gr);
               // Array.ForEach(gr, Console.Write);
                //TimeSpan timeSpan2 = DateTime.Now.Subtract(start);
                //Console.WriteLine($"длительность GroupND = {timeSpan2.TotalSeconds - timeSpan0.TotalSeconds}");

                //Array.ForEach(mas, Console.Write);
                //Console.WriteLine();
                // Array.ForEach(gr, Console.Write);
                //Console.WriteLine();
                groups[m] = new int[gr.Length];
                groups[m] = gr;
                mas = mas.Except<int>(groups[m]).ToArray<int>();
                //Array.ForEach(mas, Console.Write);
                //Console.WriteLine($"Длина группы {groups[m].Length}");
                //TimeSpan timeSpan3 = DateTime.Now.Subtract(start);
                //Console.WriteLine($"вычитание массивов = {timeSpan3.TotalSeconds}");
            }

           


            int[] Lastarr = mas.Except<int>(gr).ToArray<int>();         // переделать
            Array.ForEach(Lastarr, Console.WriteLine);
            //TimeSpan timeSpan = DateTime.Now.Subtract(start);
            //Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan.TotalSeconds}");
            Console.WriteLine($"Количество групп {m + 1}");
            Console.ReadKey();
        }
    }
}
            
    

