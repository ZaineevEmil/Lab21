using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        public static int[,] pole;
        public static int vertical;
        public static int gorizontal;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину поля по вертикали");
            vertical = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину поля по горизонтали");
            gorizontal = Convert.ToInt32(Console.ReadLine());
            pole = new int[vertical, gorizontal];
            for (int i = 0; i < vertical; i++)
            {
                for (int j = 0; j < gorizontal; j++)
                {
                    pole[i, j] = 0;
                }
            }

            ThreadStart ThreadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(ThreadStart);
            thread.Start();
            Gardener2();

            for (int i = 0; i < vertical; i++)
            {
                for (int j = 0; j < gorizontal; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void Gardener1()
        {
            for (int i = 0; i < vertical; i++)
            {
                for (int j = 0; j < gorizontal; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(10);
                }
            }

        }
        public static void Gardener2()
        {
            for (int j = gorizontal - 1; j >= 0; j--)
            {
                for (int i = vertical - 1; i >= 0; i--)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 2;
                    Thread.Sleep(10);
                }
            }
        }
    }
}
