using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne
{
    public static class Numbers
    {
        private static Random _Random;

        private static int RandomSeed = -1;

        public static int Random(int Min = 0, int Max = 9999, int _RandomSeed = -1)
        {
            if (
                RandomSeed == -1
                ||
                (
                    _RandomSeed != -1
                    &&
                    _RandomSeed != RandomSeed
                )
            )
            {
                if (_RandomSeed == -1)
                {
                    // Thanks, Stack Overflow
                    // Wow it's late. 2:38am 2018 September 20th
                    _RandomSeed = Guid.NewGuid().GetHashCode();
                }

                _Random = new Random(RandomSeed = _RandomSeed);
            }

            return _Random.Next(Min, Max);
        }

        public static int Random(int Max)
        {
            return Random(0, Max);
        }
    }
}
