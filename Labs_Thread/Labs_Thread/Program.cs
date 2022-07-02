using System;
using System.Text;
namespace Labs_Thread
{
    class Program
    {
        static void ClockTick(object o)
        {
            ConsoleColor c = (ConsoleColor)o;
            ColoredConsole.Write(c, "{0} ", Thread.CurrentThread.ManagedThreadId);
        }


        public static class ColoredConsole
        {
            private static object locker = new object();
            public static void WriteLine(ConsoleColor color, String format, params object[] list)
            {

                lock (locker)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine(format, list);
                }
            }
            public static void Write(ConsoleColor color, String format, params object[] list)
            {
                lock (locker)
                {
                    Console.ForegroundColor = color;
                    Console.Write(format, list);
                }
            }
        }

        static void JustAThread(object o)
        {
            int n = (int)o;
            if (n > 15 || n < 1) // недопустимые номера выводить белым цветом
                n = 15;
            while (true)
            {
                Thread.Sleep(1000);
                ColoredConsole.Write((ConsoleColor)n, "{0} ", Thread.CurrentThread.ManagedThreadId);
            }
        }

        static void SecondWork(object o)
        {
            Random rnd = new Random();
            int sec = rnd.Next(4) + 2;
            string name = Thread.CurrentThread.Name;
            if (String.IsNullOrEmpty(name))
                name = "NoName";
            ColoredConsole.WriteLine(ConsoleColor.Green, "Поток {0} запущен", name);
            for (int k = 0; k < sec - 1; ++k)
            {
                Thread.Sleep(1000);
                ColoredConsole.WriteLine(ConsoleColor.Yellow, "Поток {0} работает", name);
            }
            ColoredConsole.WriteLine(ConsoleColor.Red, "Поток {0} завершен", name);
            AutoResetEvent ev = (AutoResetEvent)o;
            ev.Set();
        }
        static Mutex mutex;
        static void SecondWork()
        {
            Random rnd = new Random();
            int sec = rnd.Next(4) + 2;
            string name = Thread.CurrentThread.Name;
            if (String.IsNullOrEmpty(name))
                name = "NoName";
            mutex.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Green, "Поток {0} запущен", name);
            for (int k = 0; k < sec - 1; ++k)
            {
                Thread.Sleep(1000);
                ColoredConsole.WriteLine(ConsoleColor.Yellow, "Поток {0} работает", name);
            }
            ColoredConsole.WriteLine(ConsoleColor.Red, "Поток {0} завершен", name);
            mutex.ReleaseMutex();
        }

        static Semaphore semafor;
        static void SecondWork1()
        {
            Random rnd = new Random();
            int sec = rnd.Next(4) + 2;
            string name = Thread.CurrentThread.Name;
            if (String.IsNullOrEmpty(name))
                name = "NoName";
            semafor.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Green, "Поток {0} запущен", name);

            for (int k = 0; k < sec - 1; ++k)
            {
                Thread.Sleep(1000);
                ColoredConsole.WriteLine(ConsoleColor.Yellow, "Поток {0} работает", name);
            }
            ColoredConsole.WriteLine(ConsoleColor.Red, "Поток {0} завершен", name);
            semafor.Release();
        }

        static void SillyWork()
        {
            ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
        }

        static Mutex mutexA = new Mutex(false);
        static Mutex mutexB = new Mutex(false);
        static void SillyWork1()
        {
            mutexA.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
            Thread.Sleep(1000);
            mutexB.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
            mutexA.ReleaseMutex();
            mutexB.ReleaseMutex();
        }
        static void SillyWork2()
        {
            mutexB.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
            Thread.Sleep(1000);
            mutexA.WaitOne();
            ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
            mutexB.ReleaseMutex();
            mutexA.ReleaseMutex();
        }

        static void SillyWork3()
        {
            ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
        }
        static void NextSillyWork(Task t)
        {
            ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started after task {1}",
            Task.CurrentId, t.Id);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
            Thread.Sleep(1000);
            ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
        }

        public static string Translate(string source)
        {
            ColoredConsole.WriteLine(ConsoleColor.Green, "Translate started ");
            String template = " " + source + " ";
            String res = "";
            using (FileStream fs = File.OpenRead(@"D:\TestFile.txt"))
            using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251)))
            {
                Boolean found = false;
                Boolean finished = false;

                String line;
                while ((!found || !finished) && ((line = sr.ReadLine()) != null))
                {
                    if (found)
                    {
                        if (line != "" && line[0] != ' ') // продолжение словарной статьи
                            res += line;
                        else // начало новой словарной статьи
                            finished = true;
                    }
                    else
                    if (line != "" && line[0] == ' ')
                    {
                        int n = line.IndexOf(template);
                        if (n > 0 && n < 20) // ищем слово только в определении
                        {
                            res += line;
                            found = true;
                        }
                    }
                }
            }
            ColoredConsole.WriteLine(ConsoleColor.Green, "Translate finished");
            return res;
        }
        delegate String StringToString(String s);

        public static async Task<String> TranslateUpperAsync(String s)
        {
            ColoredConsole.WriteLine(ConsoleColor.Magenta, "TranslateUpperAsync started "
            + "in Task {0}", Task.CurrentId);
            Thread.Sleep(1000);
            String Z = await TranslateAsync(s);
            ColoredConsole.WriteLine(ConsoleColor.Magenta, "{0} (Task {1})", Z, Task.CurrentId);
            return Z.ToUpper();
        }

        static void Main(string[] args)
            {   

            static void ClockTick1(object o)
            {
                ColoredConsole.Write(ConsoleColor.Red, "Red ");
            }
            static void ClockTick2(object o)
            {
                ColoredConsole.Write(ConsoleColor.Green, "Green ");
            }
            int a = 0,relog=0;
        NewTask:
            Console.WriteLine("Выберите любой номер задания от 1 до 28");
            a =Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1:
                    {
                        ColoredConsole.WriteLine(ConsoleColor.Red, "2+2={0}", 4);
                        ColoredConsole.WriteLine(ConsoleColor.Green, "просто зеленый текст");
                        break;
                    }
                    case 2:
                    {
                        Timer timerRed = new Timer(ClockTick1, null, 0, 1);
                        Timer timerGreen = new Timer(ClockTick2, null, 0, 1);
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Timer timerRed = new Timer(ClockTick, ConsoleColor.Red, 0, 200);
                        Timer timerGreen = new Timer(ClockTick, ConsoleColor.Green, 0, 200);
                        Timer timerYellow = new Timer(ClockTick, ConsoleColor.Yellow, 0, 200);
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(50);
                            ColoredConsole.Write(ConsoleColor.Gray, ".");
                        }
                        break;
                    }
                case 4:
                    {
                        Thread.Sleep(3000);
                        Timer timerRed = new Timer(ClockTick, ConsoleColor.Red, 0, 500);
                        Thread.Sleep(3000);
                        Timer timerGreen = new Timer(ClockTick, ConsoleColor.Green, 0, 500);
                        Thread.Sleep(3000);
                        Timer timerYellow = new Timer(ClockTick, ConsoleColor.Yellow, 0, 500);
                        Thread.Sleep(3000);
                        Timer timerWhite = new Timer(ClockTick, ConsoleColor.White, 0, 500);
                        Thread.Sleep(3000);
                        Timer timerCyan = new Timer(ClockTick, ConsoleColor.Cyan, 0, 500);
                        Thread.Sleep(3000);
                        Timer timerMagenta = new Timer(ClockTick, ConsoleColor.Magenta, 0, 500);
                        break;
                    }
                case 5:
                    {
                        for (int i = 1; i < 16; ++i)
                        {
                            Thread t = new Thread(JustAThread);
                            t.Start(i);
                        }
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(50);
                            ColoredConsole.Write(ConsoleColor.Gray, ".");
                        }
                        break;
                    }
                case 6:
                    {
                        for (int i = 1; i < 16; ++i)
                        {
                            Thread t = new Thread(JustAThread);
                            t.Start(i);
                            Thread.Sleep(3000);
                        }
                        break;
                    }
                case 7:
                    {
                        for (int i = 1; i < 16; ++i)
                        {
                            Thread t = new Thread(JustAThread);
                            t.IsBackground = true;
                            switch (i)
                            {

                                case 1:
                                case 9:
                                    t.Priority = ThreadPriority.Lowest;
                                    break;
                                case 2:
                                case 10:
                                    t.Priority = ThreadPriority.Highest;
                                    break;
                            }
                            t.Start(i);
                        }
                        break;
                    }
                case 8:
                    {
                        Thread[] threads = new Thread[3];
                        AutoResetEvent[] waitEvents = new AutoResetEvent[3];
                        String[] names = { "A", " B", " C" };
                        for (int i = 0; i < 3; ++i)
                        {
                            waitEvents[i] = new AutoResetEvent(false);
                            threads[i] = new Thread(SecondWork1);
                            threads[i].Name = names[i];
                            threads[i].Start(waitEvents[i]);
                        }
                        ColoredConsole.WriteLine(ConsoleColor.White, "Основной поток ожидает окончания работы потоков");
                        AutoResetEvent.WaitAll(waitEvents);
                        ColoredConsole.WriteLine(ConsoleColor.White, "Основной поток дождался окончания работы потоков");
                        break;
                    }
                case 9:
                    {
                        Thread[] threads = new Thread[3];
                        String[] names = { "A", " B", " C" };
                        mutex = new Mutex(false);
                        for (int i = 0; i < 3; ++i)
                        {
                            threads[i] = new Thread(new ThreadStart(SecondWork));
                            threads[i].Name = names[i];
                            threads[i].Start();
                        } // созданы приоритетные потоки: программа не завершится, пока они работают
                        break;
                    }
                case 10:
                    {
                        Thread[] threads = new Thread[3];
                        String[] names = { "A", " B", " C" };
                        semafor = new Semaphore(2, 2);
                        for (int i = 0; i < 3; ++i)
                        {
                            threads[i] = new Thread(new ThreadStart(SecondWork1));
                            threads[i].Name = names[i];
                            threads[i].Start();
                        } // созданы приоритетные потоки: программа не завершится, пока они работают
                        break;
                    }
                case 11:
                    {
                        Task t1 = new Task(SillyWork);
                        Task t2 = new Task(SillyWork);
                        Task t3 = new Task(SillyWork);
                        t1.Start();
                        t2.Start();
                        t3.Start();
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(50);
                            ColoredConsole.Write(ConsoleColor.Gray, ".");
                        }
                        break;
                    }
                case 12:
                    {
                        Task t1 = new Task(SillyWork1);
                        Task t2 = new Task(SillyWork2);
                        t1.Start();
                        t2.Start();
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(50);
                            ColoredConsole.Write(ConsoleColor.Gray, ".");
                        }
                        break;
                    }
                case 13:
                    {
                        Task t1 = new Task(SillyWork3);
                        Task t2 = t1.ContinueWith(NextSillyWork);
                        Task t3 = t2.ContinueWith(NextSillyWork);
                        t1.Start();
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(50);
                            ColoredConsole.Write(ConsoleColor.Gray, ".");
                        }
                        break;
                    }
                case 14:
                    {
                        (new Task(() => {
                            while (!Console.KeyAvailable)
                            {
                                Thread.Sleep(50);

                                ColoredConsole.Write(ConsoleColor.Gray, ".");

                            }
                        })).Start();
                        StringToString d = new StringToString(Translate);
                        String Z = d.Invoke("zoological");
                        ColoredConsole.WriteLine(ConsoleColor.Red, Z);
                        break;
                    }
                case 15:
                    {
                        StringToString d = new StringToString(Translate);
                        IAsyncResult ar = d.BeginInvoke("zoological", null, null);
                        while (!ar.IsCompleted)
                        {
                            ColoredConsole.Write(ConsoleColor.Red, "-");
                            Thread.Sleep(50);
                        }
                        ColoredConsole.WriteLine(ConsoleColor.Red, "{0}", d.EndInvoke(ar));
                        break;
                    }
                case 16:
                    {
                        Task<String> t = TranslateAsync("zebra");
                        while (!t.IsCompleted)
                        {
                            ColoredConsole.Write(ConsoleColor.Red, "-");
                            Thread.Sleep(50);
                        }
                        ColoredConsole.WriteLine(ConsoleColor.Red, "{0}", t.Result);
                        break;
                    }

            }

            Console.WriteLine("Желаете выбрать другой номер задания?(1 - Да | 0 - Нет)");
            relog = Convert.ToInt32(Console.ReadLine());
            if (relog==1) goto NewTask;
        }
    }
}
