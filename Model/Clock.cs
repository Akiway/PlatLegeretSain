using System;
using System.Threading;

namespace PlatLegeretSain.Model
{
    sealed class Clock
    {
        // Singleton
        private static Clock clock = null;
        public static Clock Instance()
        {
            if (clock == null)
                clock = new Clock();
            return clock;
        }

        public static int TotalSeconds { get; set; }
        public static int TotalMinutes => TotalSeconds / 60;
        public static int TotalHours => TotalSeconds / 3600;
        public static int Seconds => TotalSeconds % 60;
        public static int Minutes => TotalMinutes % 60;
        public static int Hours => TotalHours % 24;
        public static string Time => Hours + ":" + (Minutes < 10 ? "0" : null) + Minutes + ":" + (Seconds < 10 ? "0" : null) + Seconds;
        public static double Speed { get; set; }
        public static int STime(int time) => Convert.ToInt32(Math.Round(time / Speed));


        private Clock()
        {
            TotalSeconds = 0;
            Speed = 1.0;
            ThreadPool.QueueUserWorkItem(StartClock);
        }

        private void StartClock(object args)
        {
            while (Thread.CurrentThread.IsAlive)
            {
                TotalSeconds++;
                Thread.Sleep(STime(1000));
            }
        }
    }
}
