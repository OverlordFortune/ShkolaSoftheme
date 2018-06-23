using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2
{
    class Program
    {
        static void swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        static void InsertionSort(int[] array)
        {
            int key, position;
            for (int i = 0; i < array.Length - 1; i++)
            {
                key = array[i + 1];
                position = i;
                while ((position >= 0) && (array[position] > key))
                {
                    array[position + 1] = array[position];
                    position--;
                }
                array[position + 1] = key;
            }
        }
        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.Write('\n');
        }
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)//заполнение масива
                array[i] = rand.Next(-100, 100);

            ShowArray(array);//масив до сортировки 

            InsertionSort(array);//сортировка масива

            ShowArray(array);//масив после сортировки
            
            Console.ReadKey();
        }
    }
}
