using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._1
{
    class MyQueue<T>
    {
        QueueElement<T> head = null;

        public T Dequeue()
        {
            T data;
            data = Peek();
            head = head.Next;
            return data;
        }

        public T Peek()
        {
            if (head != null)
                return head.Data;
            throw new Exception("Empty Queue");
        }

        public void Enqueue(T NewElement)
        {
            if (head == null) head = new QueueElement<T>(NewElement);
            else
            {
                QueueElement<T> item = head;
                while (item.Next != null)
                    item = item.Next;
                item.Next = new QueueElement<T>(NewElement);
            }
            
        }

        public void ShowAllElements()
        {
            QueueElement<T> item = head;
            while (item.Next != null)
            {
                Console.WriteLine(item.Data.ToString());
                item = item.Next;
            }                
        }
    }
}
