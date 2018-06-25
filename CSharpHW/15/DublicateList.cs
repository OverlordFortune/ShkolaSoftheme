using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._1
{
    class DoubleListElement<T> : IDoubleListElement<T>
    {

        public T Data { get; set; }
        public DoubleListElement<T> Previous { get; set; }
        public DoubleListElement<T> Next { get; set; }


        public DoubleListElement(T Data)
        {
            this.Data = Data;
        }
    }

    
}
