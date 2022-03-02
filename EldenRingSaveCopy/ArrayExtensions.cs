using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenRingSaveCopy
{
    static class ArrayExtensions
    {

        public static IEnumerable<int> StartingIndex(this byte[] x, byte[] y)
        {
            IEnumerable<int> index = Enumerable.Range(0, x.Length - y.Length + 1);
            for (int i = 0; i < y.Length; i++)
            {
                index = index.Where(n => x[n + i] == y[i]).ToArray();
            }
            return index;
        }

    }
}
