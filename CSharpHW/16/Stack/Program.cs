using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Push {0}",stack.Push(rand.Next(10)));
            }

            Console.WriteLine(new string('-', 30));
            try
            {
                while (true)
                    Console.WriteLine("Pull {0}", stack.Pull());
            }
            catch(Exception)
            { }
            Console.ReadKey();
        }
    }
}
