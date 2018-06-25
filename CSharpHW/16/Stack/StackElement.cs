using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._2
{
    class StackElement<T>
    {
        public T Data { get; set; }
        public StackElement<T> Next { get; set; }

        public StackElement(T Data)
        {
            this.Data = Data;
            this.Next = null;
        }
    }
}
