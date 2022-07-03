namespace mnogopot;
class Program
{
    public static void Main(string[] args)
    {
        ColoredConsole.WriteLine(ConsoleColor.Blue, "123", 0);
        ColoredConsole.Write(ConsoleColor.Green, "321", 0);


        TimerCallback tm = new TimerCallback(ColoredConsole.WriteRed);
        Timer timer = new Timer(tm, null, 0, 200);
        TimerCallback tm2 = new TimerCallback(ColoredConsole.WriteGreen);
        Timer timer2 = new Timer(tm2, null, 0, 200);
        Console.ReadLine();

        while (!Console.KeyAvailable)
        {
            Thread.Sleep(50);
            ColoredConsole.Write(ConsoleColor.Gray, ".");
        }
        
    }
}


