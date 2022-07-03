using System;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Pract2;

class Program
{
    static void Main(string[] args)
    {
        Edition ed1 = new Edition("Журнал", new DateTime(2021, 04, 12), 1);
        Edition ed2 = new Edition("Журнал", new DateTime(2021, 04, 12), 1);
        Console.WriteLine("//////////////////////////////////////////////////");
        Console.WriteLine(object.ReferenceEquals(ed1, ed2));
        Console.WriteLine(ed1.Equals(ed2));
        Console.WriteLine(ed1.GetHashCode() + "\n" + ed2.GetHashCode());
        Console.WriteLine("//////////////////////////////////////////////////");
        try
        {
            ed1.Tier = -1;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
        }
        Console.WriteLine("//////////////////////////////////////////////////");
        List<Person> moders = new List<Person>();
        moders.Add(new Person("Алексей", "Волчек", new DateTime(2004, 01, 26)));
        List<Article> articles = new List<Article>();
        articles.Add(new Article(new Person("Степан", "Нурминский", new DateTime(1940, 10, 29)), "О любви", 9.3));
        articles.Add(new Article(new Person("Николая", "Метан", new DateTime(1940, 10, 29)), "Шнурки", 1.3));
        articles.Add(new Article(new Person("Василий", "Гелентман", new DateTime(2021, 10, 29)), "Экристин", 5.3));
        articles.Add(new Article(new Person("Александр", "Пушкин", new DateTime(1940, 10, 29)), "Пир во время чумы", 7.3));
        Magazine magazine = new Magazine("Рассказы", new DateTime(2021, 01, 12), 3, "Романтические рассказы", Frequence.Monthly, new DateTime(2021, 12, 08), ed1, moders, articles);
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

        BinaryFormatter formatter = new BinaryFormatter();
        using(FileStream fs=new FileStream("file.dat",FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, ed2);
            Console.WriteLine("=====================\nБинарная сериализация");
            Console.WriteLine(new String('-',50));
        }
        using (FileStream fs=new FileStream("file.dat",FileMode.Open))
        {
            Edition edSerial = (Edition)formatter.Deserialize(fs);

            Console.WriteLine(edSerial);
        }
        XmlSerializer serializer = new XmlSerializer(typeof(Edition));
        using (FileStream fs = new FileStream("file2.xml", FileMode.OpenOrCreate)) 
        {
            serializer.Serialize(fs, ed1);
            Console.WriteLine("================================\nXML Сериализация");
            Console.WriteLine(new String('-',50));
        }
        using (FileStream fs = new FileStream("file2.xml", FileMode.Open))
        {
            Edition edSerial = (Edition)serializer.Deserialize(fs);
            Console.WriteLine(edSerial);
            Console.WriteLine();
        }



    }
}