using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._1
{
    class QueueElement<T>
    {
        public T Data { get; set; }
        public QueueElement<T> Next { get; set; }

        public QueueElement(T Data)
        {
            this.Data = Data;
            this.Next = null;
        }
    }
}
