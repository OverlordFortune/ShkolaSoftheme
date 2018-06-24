using System;

namespace _14._1
{   
    class Program
    {
        static void Main(string[] args)
        {
            Lottery lottery = new Lottery();

            for (int i = 0; i < lottery.Length; i++)
            {
                Console.WriteLine("Now write {0}- number", i + 1);
                lottery[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(lottery.IsWin());
        }
    }
}
