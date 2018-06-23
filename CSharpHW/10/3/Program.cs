using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._3
{
    class MyArray<T>
    {
        private T[] array = new T[0];
        public void Add(T NewElement)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = NewElement;
        }
        public T GetByIndex(int index)
        {
            return this[index];
        }
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                else throw new IndexOutOfRangeException();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
