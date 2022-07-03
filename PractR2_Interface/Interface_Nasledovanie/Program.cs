using System;

namespace Interface_Nasledovanie;

class Program
{
    static void Main(string[] args)
    {
        Edition ed1 = new Edition("Журнал", new DateTime(2021, 04, 12), 1);
        Edition ed2 = new Edition("Журнал", new DateTime(2021, 04, 12), 1);
        Console.WriteLine(object.ReferenceEquals(ed1, ed2));
        Console.WriteLine(ed1.Equals(ed2));
        Console.WriteLine(ed1.GetHashCode() + "\n" + ed2.GetHashCode());
        try
        {
            ed1.Tier = -1;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        //
        List<Person> moders = new List<Person>();
        moders.Add(new Person("Волчек", "Алексей", new DateTime(2004, 01, 26)));
        //
        List<Article> articles = new List<Article>();
        articles.Add(new Article(new Person("Александр", "Пушкин", new DateTime(1940, 10, 29)), "Стихи", 9.3));
        articles.Add(new Article(new Person("Александр", "Пушкин", new DateTime(1940, 10, 29)), "Стихи2", 1.3));
        articles.Add(new Article(new Person("Александр", "Пушкин", new DateTime(1940, 10, 29)), "Евгений Онегин", 5.3));
        articles.Add(new Article(new Person("Александр", "Пушкин", new DateTime(1940, 10, 29)), "Пир во время чумы", 7.3));
        //
        Magazine magazine = new Magazine("Сказки", new DateTime(2021, 01, 12), 3, "Сказки для малышей", Frequence.Monthly, new DateTime(2021, 12, 08), ed1, moders, articles);
        Console.WriteLine(magazine);
        Console.WriteLine();
        Console.WriteLine(magazine.Edition);
        Console.WriteLine();
        Magazine clon = (Magazine)magazine.DeepCopy();
        magazine.InfoDate = Frequence.Yearly;
        magazine.NameMagazine = "Газета";
        Console.WriteLine(clon);
        Console.WriteLine();
        Console.WriteLine(magazine);
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Список статей с рейтингом больше 6");
        foreach (var VARIABLE in magazine.IteratorRating(6))
        {
            Console.WriteLine(VARIABLE);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Список статей со словом стихи:");
        foreach (var VARIABLE in magazine.IteratorString("Стихи"))
        {
            Console.WriteLine(VARIABLE);
        }


    }
}