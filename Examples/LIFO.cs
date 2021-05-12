using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Examples
{
    public class LIFO
    {

        int size = 0;
        List<int> values = new List<int>();

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Push(int v)
        {
            values.Add(v);
            size++;
        }

        public int Size()
        {
            return size;
        }

        public int Pop()
        {
            int v = values[values.Count - 1];
            values.RemoveAt(values.Count - 1);
            return v;
        }
    }
}
