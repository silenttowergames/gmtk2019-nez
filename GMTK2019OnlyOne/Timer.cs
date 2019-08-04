using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTK2019OnlyOne
{
    public class Timer
    {
        protected int
            Limit,
            Current
        ;

        public Timer(int _Limit, int _Current)
        {
            Limit = _Limit;
            Current = _Current;
        }

        public Timer(int _Limit)
        {
            Current = Limit = _Limit;
        }

        public void Run()
        {
            if (Current > 0)
            {
                Current--;
            }
        }

        public bool IsFinished()
        {
            return Current <= 0;
        }

        public bool GetFinished()
        {
            Run();

            return IsFinished();
        }

        public bool GetFinishedThenReset()
        {
            Run();

            bool Ret = IsFinished();

            if (Ret)
            {
                Reset();
            }

            return Ret;
        }

        public void Reset()
        {
            Current = Limit;
        }

        public float GetPercentage()
        {
            if (Limit == 0 || Current == 0)
            {
                return 0;
            }

            return 1 / (Limit / Current);
        }

        public int GetCurrent()
        {
            return Current;
        }

        public int GetLimit()
        {
            return Limit;
        }
    }
}
