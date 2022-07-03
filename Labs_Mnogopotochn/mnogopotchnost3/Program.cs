namespace mnogopot3;
class Program
{
    public static int Million100 { get; set; }
    private static object locker = new object();
    static void Main(string[] args)
    {
        //3.2
        //for (int i = 0; i < 20; ++i)
        //{
        //    Thread t = new Thread(() => {
        //        lock (locker)
        //            for (int k = 0; k < 5000000; ++k)
        //                Million100++;
        //    });
        //    t.IsBackground = true;
        //    t.Start();
        //}
        //while (!Console.KeyAvailable)
        //{
        //    Thread.Sleep(50);
        //    ColoredConsole.WriteLine(ConsoleColor.Gray, "{0}", Million100);
        //}

        Thread[] threads = new Thread[3];
        String[] names = { "A", " B", " C" };
        semafor = new Semaphore(2, 2);
        for (int i = 0; i < 3; ++i)
        {
            threads[i] = new Thread(new ThreadStart(SecondWork));
            threads[i].Name = names[i];
            threads[i].Start();
        }
    }
    static Semaphore semafor;
    static void SecondWork()
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
}