namespace mnogopotochnost4;

class Program
{
    //4.1
    static void SillyWork()
    {
        ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
        Thread.Sleep(1000);
        ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
        Thread.Sleep(1000);
        ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
    }
    static void Main(string[] args)
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
    }
    //4.2
    /*static Mutex mutexA = new Mutex(false);
    static Mutex mutexB = new Mutex(false);
    static void SillyWork()
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
    static void Main(string[] args)
    {
        Task t1 = new Task(SillyWork);
        Task t2 = new Task(SillyWork2);
        t1.Start();
        t2.Start();
        while (!Console.KeyAvailable)
        {
            Thread.Sleep(50);
            ColoredConsole.Write(ConsoleColor.Gray, ".");
        }
    }*/
    //4.3
    //static void SillyWork()
    //{
    //    ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started", Task.CurrentId);
    //    Thread.Sleep(1000);
    //    ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
    //    Thread.Sleep(1000);
    //    ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
    //}
    //static void NextSillyWork(Task t)
    //{
    //    ColoredConsole.WriteLine(ConsoleColor.Green, "Task {0} started after task {1}",
    //    Task.CurrentId, t.Id);
    //    Thread.Sleep(1000);
    //    ColoredConsole.WriteLine(ConsoleColor.Yellow, "Task {0} worked", Task.CurrentId);
    //    Thread.Sleep(1000);
    //    ColoredConsole.WriteLine(ConsoleColor.Red, "Task {0} finished", Task.CurrentId);
    //}
    //static void Main(string[] args)
    //{
    //    Task t1 = new Task(SillyWork);
    //    Task t2 = t1.ContinueWith(NextSillyWork);
    //    Task t3 = t2.ContinueWith(NextSillyWork);
    //    t1.Start();
    //    while (!Console.KeyAvailable)
    //    {
    //        Thread.Sleep(50);
    //        ColoredConsole.Write(ConsoleColor.Gray, ".");
    //    }
    //}
}