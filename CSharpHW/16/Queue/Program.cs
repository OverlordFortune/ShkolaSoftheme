using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> myQueue = new MyQueue<int>();

            myQueue.Enqueue(12);
            myQueue.Enqueue(10);
            //myQueue.ShowAllElements();

            Console.WriteLine(myQueue.Peek());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());

        }
    }
}
