using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._1
{
    class DoubleList<T>
    {
        protected DoubleListElement<T> head = null;
        protected DoubleListElement<T> tail = null;
        protected int count = 0;

        public void Add(DoubleListElement<T> NewElement)
        {
            Add(NewElement.Data);
        }

        public void Add(T NewElementData)
        {
            DoubleListElement<T> listElement = new DoubleListElement<T>(NewElementData);

            if (head == null)
            {
                head = listElement;
                tail = listElement;
            }
            else
            {
                tail.Next = listElement;
                listElement.Previous = tail;
                listElement.Next = null;
                tail = listElement;
            }
            count++;
        }

        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                count = value;
            }
        }

        public void RemoveLast()
        {
            tail = tail.Previous;

            if (tail != null)
                tail.Next = null;
            this.Count--;
        }

        public void RemoveFirst()
        {
            head = head.Next;

            if (head != null)
                head.Previous = null;
            this.Count--;
        }

        public bool IsContain(T Element)
        {
            DoubleListElement<T> item = head;
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Data.Equals(Element))
                {
                    return true;
                }
                else
                {
                    item = item.Next;
                }
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            DoubleListElement<T> item = head;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = item.Data;
                item = item.Next;
            }
            return array;
        }
    }
}
