using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;
using System.IO.Compression;
using System.Text;

namespace Простые_числа_2
{


    class Program
    {
        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }


        /// <summary>
        /// Сортировка чисел по группам взаимно простых решетом Эратосфена
        /// </summary>
        /// <param name="n"></param>
        static byte [] Eratosfen(int n)
        {
            DateTime start = DateTime.Now;
            //int n = 50;
            int num = n + 1;
            int i;
            byte[] numbers = new byte[n + 1];
            numbers[0] = 1;
            numbers[1] = 1;

            for (i = 2; i < num; i++)
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
            return numbers;
        }
            static void Main(string[] args)
        {
            Console.WriteLine ($"ПРОГРАММА СОРТИРОВКИ НА ГРУППЫ ВЗАИМНО ПРОСТЫХ ЧИСЕЛ");

            //C:\Users\kpols\Desktop\ДЗ\HW_6k\Число.txt
            string way;
            do
            {
                Console.WriteLine($"Введите путь к файлу .txt :");
                way = Console.ReadLine();
                if (File.Exists(@way))
                    break;
                else
                    Console.Write("Файл не найден. Попробуйте еще: ");

            } while (true);


            string[] b = File.ReadAllLines(@way); // Открывает текстовый файл, считывает все строки файла и затем закрывает файл.

            Console.WriteLine($" N = {b[0]};");

            var n = Convert.ToInt32(b[0]);
            byte[] numbers = Eratosfen(n);
            byte cGroup = (byte)(Convert.ToByte(Math.Floor(Math.Log2(n))) + 1);
            using (var file = new StreamWriter(@"C:\Users\kpols\Desktop\ДЗ\HW_6k\Группы.txt"))
            
            {
   
                    for (int c = 1; c <= cGroup; c++)
                    {
                       var line = ($"Группа №{c}: ");
                        file.Write(line);
                        for (int j = 1; j < numbers.Length; j++)
                        {
                        
                            if (numbers[j] == c)
                            {
                          
                            file.Write($"{j}, ");
                           
                            }
 
                        }
                    file.Write($"\n");
                    }
               
            }
            string sourceFile = "C://Users/kpols/Desktop/ДЗ/HW_6k/Группы.txt"; // исходный файл
            string compressedFile = "C://Users/kpols/Desktop/ДЗ/HW_6k/Группы.zip"; // сжатый файл
            Compress (sourceFile, compressedFile);
            Console.ReadKey();
        }
       
    }
}
