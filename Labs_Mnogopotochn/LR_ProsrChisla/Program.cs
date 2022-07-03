

namespace LR_ProstChisla;
class Program
{
    const int N = 1000000;
    static List<int> prchisla = new List<int>();
    static int[] Nums = new int[N + 1];
    static int M = 3;
    static int cnt;
    static int current_index = 0;
    static void Init()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        for (int i = 2; i < Math.Sqrt(N); i++)
        {
            if (Nums[i] == 0)
            {
                for (int j = i + 1; j < Math.Sqrt(N); j++)
                    if (j % i == 0)
                        Nums[j] = 1;
                prchisla.Add(i);
                Console.WriteLine(i);

            }
        }
    }
    static void Task1()
    {
        Init();
        for (int i = (int)(Math.Sqrt(N)); i < N + 1; i++)
            foreach (var item in prchisla)
            {
                if (i % item == 0)
                    Nums[i] = 1;
            }
    }

    static void Task2()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Init();
        Thread[] arrThr = new Thread[M];
        for (int i = 0; i < M; i++)
        {

            arrThr[i] = new Thread(ThrFuncT2);
            arrThr[i].Start(i);
        }
        for (int i = 0; i < M; i++)
        {
            arrThr[i].Join();
            Console.WriteLine(i);
        }

    }
    static void ThrFuncT2(object obj)
    {
        int idx = (int)obj;
        int end;
        int Sqrt = (int)Math.Sqrt(N);
        cnt = (N - Sqrt) / M;
        int start = Sqrt + cnt * idx;
        if (idx == M - 1) end = N + 1;
        else end = start + cnt;
        for (int i = start; i < end; i++)
            foreach (var item in prchisla)
            {
                if (i % item == 0)
                    Nums[i] = 1;
            }
    }


    static void Task3()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Init();
        Thread[] arrThr = new Thread[M];
        for (int i = 0; i < M; i++)
        {

            arrThr[i] = new Thread(ThrFuncT3);
            arrThr[i].Start(i);
        }
        for (int i = 0; i < M; i++)
        {
            arrThr[i].Join();
            Console.WriteLine(i);
        }
    }
    private static void ThrFuncT3(object obj)
    {
        int idx = (int)obj;
        int end;
        int Sqrt = (int)Math.Sqrt(N);
        int Len = prchisla.Count;
        cnt = Len / M;
        int start = cnt * idx;
        if (idx == M - 1) end = Len;
        else end = start + cnt;
        for (int i = Sqrt; i < N + 1; i++)
            for (int j = start; j < end; j++)
            {
                if (i % prchisla[j] == 0)
                    Nums[i] = 1;
            }
    }
    static void Task4()
    {
        Init();
        int Len = prchisla.Count;
        CountdownEvent events = new CountdownEvent(Len);
        for (int i = 0; i < Len; i++)
        {
            ThreadPool.QueueUserWorkItem(F, new object[] { prchisla[i], events });
        }
        events.Wait();

    }
    private static void F(object obj)
    {
        int Sqrt = (int)Math.Sqrt(N);
        int prime = (int)((object[])obj)[0];
        CountdownEvent ev = ((object[])obj)[1] as CountdownEvent;
        for (int i = Sqrt; i < N + 1; i++)
            if (i % prime == 0)
                Nums[i] = 1;
        ev.Signal();
    }

    static void Task5()
    {
        Init();
        Thread[] arrThr = new Thread[M];
        for (int i = 0; i < M; i++)
        {

            arrThr[i] = new Thread(Func);
            arrThr[i].Start();
        }
        for (int i = 0; i < M; i++)
            arrThr[i].Join();
    }

    private static void Func()
    {
        int current_prime;
        int Len = prchisla.Count;
        while (true)
        {
            if (current_index >= Len)
                break;
            lock ("Critical")
            {
                current_prime = prchisla[current_index];
                current_index++;
            }
            for (int i = (int)Math.Sqrt(N); i < N + 1; i++)
                if (i % current_prime == 0)
                    Nums[i] = 1;
        }
    }

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;

        DateTime Start, End;
        Start = DateTime.Now;
        for (int i = 0; i < 3; i++)
        {
            Task1();
            Task2();
            //Task3();
            //Task4();
            //Task5();
        }
        End = DateTime.Now;
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Время выполнения: " +((End - Start).TotalSeconds));
        //int cntV = 0, cntC = 0;
        ////контрольная сумма значений чисел, контрольная сумма чисел
        //for (int i = 0; i < N - 1; i++)
        //{
        //    if (Nums[i] == 0)
        //    {
        //        cntV += i;//1061
        //        cntC++;//27
        //    }
        //}
        //Console.WriteLine(cntV.ToString() + " " + cntC.ToString());

        Console.ReadKey();
    }
}