using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_21
{
    class Program
    {
        static int X;
        static int Y;
        static int[,] Field;
        static void Sad1()
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (Field[i, j] == 0)
                        Field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        static void Sad2()
        {
            for (int i = Y - 1; i > 0; i--)
            {
                for (int j = X - 1; j > 0; j--)
                {
                    if (Field[j, i] == 0)
                        Field[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
        static void Main(string[] args)
        {
            X = 10;
            Y = 10;
            Field = new int[X, Y];
            ThreadStart threadStart1 = new ThreadStart(Sad1);
            Thread thread1 = new Thread(threadStart1);
            ThreadStart threadStart2 = new ThreadStart(Sad2);
            Thread thread2 = new Thread(threadStart2);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Console.Write($"{Field[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

