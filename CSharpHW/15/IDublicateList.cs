using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._1
{
    interface IDoubleListElement<T>
    {
        T Data { get; set; }
        DoubleListElement<T> Previous { get; set; }
        DoubleListElement<T> Next { get; set; }
    }
}
