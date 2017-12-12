using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingDemo
{
    class Worker
    {
        internal struct MonotonicTime
        {
            private static readonly double StopwatchTicksToTimeSpanTicks = (double)TimeSpan.TicksPerSecond / System.Diagnostics.Stopwatch.Frequency;
            private static long ToTimespanTicks(long stopwatchTicks) => (long)(stopwatchTicks * StopwatchTicksToTimeSpanTicks);

            private readonly long _ticks;
            private MonotonicTime(long ticks) => _ticks = ticks;

            public override string ToString()
            {
                return _ticks.ToString();
            }

            public static MonotonicTime Now => new MonotonicTime(System.Diagnostics.Stopwatch.GetTimestamp());
            public static TimeSpan operator -(MonotonicTime end, MonotonicTime start) => TimeSpan.FromTicks(ToTimespanTicks(end._ticks - start._ticks));
        }

        int tmp = 0;

        public void DoWork(int msDelayTime)
        {
            var start = MonotonicTime.Now;
            do
            {
                for (int i = 0; i < 10000; i++)
                {
                    tmp = i;
                }
            }
            while ((MonotonicTime.Now - start).TotalMilliseconds < msDelayTime);
        }

    }
}
