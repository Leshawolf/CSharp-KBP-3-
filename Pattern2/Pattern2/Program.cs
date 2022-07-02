using System;

namespace RefactoringGuru.DesignPatterns.Proxy.Conceptual
{
    // Интерфейс Субъекта объявляет общие операции как для Реального Субъекта,
    // так и для Заместителя. Пока клиент работает с Реальным Субъектом,
    // используя этот интерфейс, вы сможете передать ему заместителя вместо
    // реального субъекта.
    public interface ISubject
    {
        void Request();
    }

    // Реальный Субъект содержит некоторую базовую бизнес-логику. Как правило,
    // Реальные Субъекты способны выполнять некоторую полезную работу, которая к
    // тому же может быть очень медленной или точной – например, коррекция
    // входных данных. Заместитель может решить эти задачи без каких-либо
    // изменений в коде Реального Субъекта.
    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("Реальная Тема: Обработка запроса.");
        }
    }

    // Интерфейс Заместителя идентичен интерфейсу Реального Субъекта.
    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        // Наиболее распространёнными областями применения паттерна Заместитель
        // являются ленивая загрузка, кэширование, контроль доступа, ведение
        // журнала и т.д. Заместитель может выполнить одну из этих задач, а
        // затем, в зависимости от результата, передать выполнение одноимённому
        // методу в связанном объекте класса Реального Субъект.
        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Request();

                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            // Некоторые реальные проверки должны проходить здесь.
            Console.WriteLine("Прокси: Проверка доступа перед отправкой реального запроса.");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Прокси: Регистрация времени запроса.");
        }
    }

    public class Client
    {
        // Клиентский код должен работать со всеми объектами (как с реальными,
        // так и заместителями) через интерфейс Субъекта, чтобы поддерживать как
        // реальные субъекты, так и заместителей. В реальной жизни, однако,
        // клиенты в основном работают с реальными субъектами напрямую. В этом
        // случае, для более простой реализации паттерна, можно расширить
        // заместителя из класса реального субъекта.
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Клиент: Выполнение клиентского кода с реальным субъектом:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Клиент: Выполнение одного и того же клиентского кода с прокси-сервером:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}