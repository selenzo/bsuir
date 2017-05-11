using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3
{
    class LehmerRandom
    {
        private readonly uint[] _simples =
        {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
        };
        private ulong a, m, Rprev, c;
        public LehmerRandom(ulong a, ulong m, ulong c)
        {
            List<uint> simples = new List<uint>();
            foreach (uint p in _simples)
            {
                if (p < m - 1)
                {
                    simples.Add(p);
                }
            }

            this.a = a;
            this.m = m;
            this.Rprev = (ulong)simples[new Random().Next(simples.Count)];
            this.c = c;
        }

        public double Next()
        {
            double result = Rprev;
            Rprev = (a * Rprev + c) % m;
            return result / m;
        }
    }
}
