using System;
namespace zad5;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 5\n");
        NsOperator NewsOp = new NsOperator();
        Sub Sub1 = new Sub("Sub 1");
        Sub Sub2 = new Sub("Sub 2");
        NewsOp.SubscribeTo(Category.Events, Sub1);
        NewsOp.SubscribeTo(Category.Events, Sub2);
        Console.WriteLine("=========================\n Тут произошло заполнение Происшедствиях");
        NewsOp.SubscribeTo(Category.News, Sub1);
        NewsOp.SubscribeTo(Category.News, Sub2);
        Console.WriteLine("=========================\n Тут произошло заполнение Новостей");
        NewsOp.SubscribeTo(Category.Sport, Sub1);
        NewsOp.SubscribeTo(Category.Sport, Sub2);
        Console.WriteLine("=========================\n Тут произошло заполнение информации о спорте");
        NewsOp.SubscribeTo(Category.Humor, Sub1);
        NewsOp.SubscribeTo(Category.Humor, Sub2);
        Console.WriteLine("=========================\n Тут произошло заполнение Юмористических шоу");
        NewsOp.SubscribeTo(Category.Weather, Sub1);
        NewsOp.SubscribeTo(Category.Weather, Sub2);
        Console.WriteLine("=========================\n Тут произошло заполнение информации о погоде");
        Console.WriteLine("=========================");

        NewsOp.AddNews(Category.Events, "Новость(1)");
        Console.WriteLine("=========================");
        NewsOp.AddNews(Category.Events, "Новость(2)");
        Console.WriteLine("=========================");
        NewsOp.AddNews(Category.Sport, "В данном месте должна быть тематика про спорт");
        Console.WriteLine("========================="); 
        NewsOp.AddNews(Category.Humor, "В данном месте должна быть шутка, минутка");
        Console.WriteLine("========================="); 
        NewsOp.AddNews(Category.Weather, "А в данной тебе должна быть отображена погода");
        Console.WriteLine(" "); 
        NewsOp.SubscribeTo(Category.Sport, Sub2);

    }
}