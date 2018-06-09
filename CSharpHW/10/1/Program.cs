using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._1
{
    class Program
    {
        static int[] numbers = new int[1001];

        static void Main(string[] args)
        {
            FullArray();
            //ShowArray();//test
           // Console.ReadKey();//test
            //Console.WriteLine(new string('-', 50));//test
            RandomSort();
            // ShowArray();//test
            //Console.ReadKey();//test
            //Console.WriteLine(new string('-', 50));//test
            Array.Sort(numbers);
          //  ShowArray();//test

            Console.WriteLine("Unpaired number is {0}", FindSingle());
            Console.ReadKey();//test
        }
    /*
     * ПОИСК ПО ОТСОРТИРОВАНОМУ МАСИВУ*/
        static int  FindSingle()
        {
            for(int i = 1; i < numbers.Length-1; i++)
            {
                if (numbers[i] != numbers[i - 1])
                    if (numbers[i] != numbers[i + 1])
                        return numbers[i];
            }
            return numbers[numbers.Length - 1];
        }

        static void FullArray()
        {
            Random rand = new Random();
            int num, num2;
            for(int i = 0; i < numbers.Length-1;)
            {
                num = rand.Next(1, 100);
                num2 = rand.Next(1, (numbers.Length - i>100?100: numbers.Length - i) / 2) * 2;
                for (int j = 0; j < num2; j++)
                {
                    numbers[i] = num;
                    i++;
                }
            }
            numbers[numbers.Length - 1] = rand.Next(1, 100);
        }

        static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        //ПЕРЕМЕШАТЬ МАСИВ 
        static void RandomSort()
        {
            Random rand = new Random();
            int length = numbers.Length;
            for (int i = 0;i< length*10; i++ )
            {
                Swap(ref numbers[rand.Next(0, length - 1)], ref numbers[rand.Next(0, length - 1)]);
            }
            Swap(ref numbers[length - 1], ref numbers[rand.Next(0, length - 1)]);
        }

        static void ShowArray()
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Array[{0}] = {1}", i, numbers[i]);
            }
        }
    }
}
