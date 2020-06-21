using System;
using System.Linq;
using System.Globalization;
using System.Net.Http.Headers;

namespace HW_6
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

            static int[] GroupND2(int[] mas)
            {
                int j = 1;
                int[] mask = new int[mas.Length];
                mask[0] = mas[0];

                bool ND;
                for (int i = 0; i < mas.Length - 1; )
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
                    i += 2;
                }

                //Console.WriteLine($"j {j}");
                Array.Resize(ref mask, j);
            //int[] gr = new int[j];
            //// gr = mask.Where(a => a != 0).ToArray();


            //for (int i = 0; i < j; i++)
            //{
            //    gr[i] = mask[i];

            //}

            return mask;
             }
        static void Main(string[] args)
        {
            /// Домашнее задание
            ///
            /// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
            /// своих навыков. 
            /// 
            /// Немного подумав они вспомнили, что не так давно на занятиях по математике
            /// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
            /// пример с использованием фактов делимости. 
            /// Пример заключался в следующем: 
            /// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
            /// так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
            /// В результате этого разбиения получилось M групп, для N = 50, M = 6
            /// 
            /// N = 50
            /// Группы получились такими: 
            /// 
            /// Группа 1: 1
            /// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
            /// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
            /// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
            /// Группа 5: 16 24 36 40
            /// Группа 6: 32 48
            /// 
            /// M = 6
            /// 
            /// ===========
            /// 
            /// N = 10
            /// Группы получились такими: 
            /// 
            /// Группа 1: 1
            /// Группа 2: 2 7 9
            /// Группа 3: 3 4 10
            /// Группа 4: 5 6 8
            /// 
            /// M = 4
            /// 
            /// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
            /// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
            ///    для которого нужно подсчитать количество групп
            ///    Программа работает с числами N не превосходящими 1 000 000 000
            ///   
            /// 2. В ней есть два режима работы:
            ///   2.1. Первый - в консоли показывается только количество групп, т е значение M
            ///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
            ///                 вариантов работы с файлами
            ///            
            /// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
            ///    в секундах и миллисекундах
            /// 
            /// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
            /// делает это.
            /// 
            /// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
            /// (добавление новых возможностей не возбраняется)
            ///
            /// * При выполнении текущего задания, необходимо документировать код 
            ///   Как пометками, так и xml документацией
            ///   В обязательном порядке создать несколько собственных методов

            DateTime start = DateTime.Now;
            int n =1000;
            int[] mas = new int[n-1];
            for (int j = 0; j < n-1; j++)
                mas[j] = j+2;
            //Array.ForEach(mas, Console.Write);
            //Console.WriteLine();
            /////////////////////////////////////////////////////////////////////////
            // int m;
            //int[] gr = new int[2000];
            //for (m = 0; m < mas.Length; m++)
            //{
            //    Console.WriteLine($"Количество групп {m + 2}");
            //   int[] gr = GroupND(mas);
            //Array.ForEach(gr, Console.Write);
            //Console.WriteLine();
            // string res = string.Join(" ", gr);
            //Console.Write($"gr {res}");
            //Console.WriteLine();
            //    mas = mas.Except<int>(gr).ToArray<int>();
            //}
            // Console.WriteLine($"Количество групп {m + 2}");
            /////////////////////////////////////////////////////////////////////////
            ///
            TimeSpan timeSpan0 = DateTime.Now.Subtract(start);
            Console.WriteLine($"начало GroupND  = {timeSpan0.TotalSeconds}");
            int m;
           int[][] groups = new int[200000][];
            groups[1] = GroupND2(mas);
            
            ////Array.ForEach(groups[1], Console.Write);
            ////Console.WriteLine();
            mas = mas.Except<int>(groups[1]).ToArray<int>();
            TimeSpan timeSpan1 = DateTime.Now.Subtract(start);
            Console.WriteLine($"группа {1}");
            Console.WriteLine($"длительность GroupND = {timeSpan0.TotalSeconds - timeSpan1.TotalSeconds}");
           
            Console.WriteLine($"Длина группы {groups[1].Length}");

            for (m = 2; m < mas.Length + 1; m++)
            {
                Console.WriteLine($"группа {m}");
                     
                int[] gr = GroupND(mas);
                TimeSpan timeSpan2 = DateTime.Now.Subtract(start);
                Console.WriteLine($"длительность GroupND = {timeSpan2.TotalSeconds- timeSpan1.TotalSeconds}");

                //Array.ForEach(mas, Console.Write);
                //Console.WriteLine();
                //Array.ForEach(gr, Console.Write);
                //Console.WriteLine();
                groups[m] = new int[gr.Length];
                groups[m] = gr;
                mas = mas.Except<int>(groups[m]).ToArray<int>();
                //Array.ForEach(mas, Console.Write);
                Console.WriteLine($"Длина группы {groups[m].Length}");
                //TimeSpan timeSpan3 = DateTime.Now.Subtract(start);
                //Console.WriteLine($"вычитание массивов = {timeSpan3.TotalSeconds}");
            }

            Console.WriteLine($"Количество групп {m}");


            ////int[] Lastarr = mas.Except<int>(gr).ToArray<int>();         // переделать
            ////Array.ForEach(Lastarr, Console.Write);
            TimeSpan timeSpan = DateTime.Now.Subtract(start);
            Console.WriteLine($"timeSpan.TotalSeconds = {timeSpan.TotalSeconds}");

            Console.ReadKey();
        }
    }
}
