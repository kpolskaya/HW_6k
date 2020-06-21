using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;//число до которого будем находить простые числа
            n = int.Parse(Console.ReadLine());//вводим N
            for (int i = 2; i <= n; i++)
            {
                if (isSimple(i))
                {
                    Console.Write(i.ToString() + ",");
                }
            }Console.ReadKey();
        }
        //метод который определяет простое число или нет
        private static bool isSimple(int n)
        {
            bool tf = false;
            //чтоб убедится простое число или нет достаточно проверить не делитсья ли 
            //число на числа до его половины
            for (int i = 2; i < (int)(n / 2); i++)
            {
                if (n % i == 0)
                {
                    tf = false; 
                    break;
                }
                else
                {
                    tf = true;
                }
            }
            return tf;
        }
    }
}