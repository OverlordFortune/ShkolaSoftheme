using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._2
{
    class MyStack<T>
    {
        StackElement<T> head = null;

        public T Push(T NewElement)
        {
            StackElement<T> element = new StackElement<T>(NewElement);
            element.Next = head;
            head = element;
            return NewElement;
        }

        public T Pull()
        {
            T data = this.Peek();
            head = head.Next;
            return data;
        }

        public T Peek()
        {
            if (head != null)
            {
                return head.Data;
            }
            throw new Exception("Empty Stack");
        }
    }
}
