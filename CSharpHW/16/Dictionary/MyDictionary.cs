using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._3
{
    class MyDictionary<TKey, TValue>
    {
        List<TKey> keys = new List<TKey>();
        List<TValue> values = new List<TValue>();

        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key)) throw new Exception("Key has been added");
            keys.Add(key);
            values.Add(value);
        }

        public void Add(KeyValuePair<TKey, TValue> keyvalue)
        {
            this.Add(keyvalue.Key, keyvalue.Value);
        }

        public void Remove(TKey key)
        {
            int index = keys.IndexOf(key);
            if (index >= 0)
            {
                values.RemoveAt(index);
                

                keys.RemoveAt(index);
                foreach (var item in keys.ToArray())
                    Console.WriteLine(item);
                foreach (var item in values.ToArray())
                    Console.WriteLine(item);
            }
        }

        public TValue[] Values
        {
            get
            {
                return values.ToArray();
            }
        }

        public TKey[] Keys
        {
            get
            {
                return keys.ToArray();
            }
        }


    }
}
