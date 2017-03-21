using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace lab9_2
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static Process[] proc = new Process[11];
        private static int tick = 0;

        public static void Main()
        {
            SetTimer();

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();
            Console.WriteLine("Terminating the application...");

        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(300);
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (tick > 14 && tick < 25)
            {
                File.WriteAllText(tick + ".txt", "Запуск №" + (tick - 14));

                proc[tick - 15] = Process.Start(tick + ".txt");
            }

            if (tick > 24)
            {
                proc[tick - 25].CloseMainWindow();
            }
            if(tick > 33) aTimer.Stop();
            Console.WriteLine("tick " + tick);
            tick++;
        }
    }
}
