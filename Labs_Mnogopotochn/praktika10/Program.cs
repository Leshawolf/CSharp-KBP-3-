class Program
{

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Fibonachi);
        thread1.Start();
        Thread.Sleep(500);
        Thread thread2 = new Thread(isSimple);
        thread2.Start();
        
    }

    static object locker = new();
    static void  Fibonachi()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        lock (locker)
        {
            int count = 0;
            int position = 20;
            int f1, f2;
            f1 = 0; f2 = 1;
            int fsum = 0;
            if (position == 1) fsum = f1;
            else if (position == 2) fsum = f2;
            for (int i = 2; i < position; i++)
            {
                fsum = f1 + f2;
                f1 = f2;
                f2 = fsum;
                count++;
                Console.WriteLine(fsum);
            }
            Console.WriteLine("Кол-во чисел фибоначи: " + count);
            Console.ResetColor();
        }
    }
    private static void isSimple()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        lock (locker)
        {
            int count = 0;
            for (int num = 0; num < 20; ++num)
            {
                if (num == 2)
                {
                    Console.WriteLine(num);
                    continue;
                }
                if (num % 2 == 0 || num <= 1) continue;
                bool is_prime = true;
                for (int i = 3; i * i <= num; i += 2)
                {
                    if (num % i == 0)
                    {
                        is_prime = false;
                        break;
                    }
                }
                if (is_prime)
                {
                    Console.WriteLine(num);
                    count++;
                }
            }
            Console.WriteLine("Число простых чисел: " + count);
            Console.ResetColor();

        }
    }
}