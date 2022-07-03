using System;

using System.Collections;

namespace Reapit_Nasledovanie;
//Добавление и вывод на табло информации о рейсе
//Оператор телефонной службы, пока нажата кнопка идёт таймер, потом время с таймера умножается на тариф 
class Reapit_Nasledovanie
{
    static void Main(string[] args)
    {
        Function();
        Console.ReadLine();
    }
    static public void Function()
    {
        try
        {

            ArrayList list = new ArrayList();
            Magazine m1 = new Magazine(23, "Март", "Мирский дома", 19, "Плей бой");
            Magazine m3 = new Magazine();
            Book b1 = new Book("Фэнтази", "Аркадий", 39, "Печатный дом \"Ёлки\"", 2000, "Страна чудес");
            Textbook t1 = new Textbook("Для изучения английского яхыка", "Дом культуры", 2001, "Учебник Английского языка");
            MagazinOnline m = new MagazinOnline("Северное РУВД", 2002, "Епам");
            list.Add(m1);
            list.Add(b1);
            list.Add(t1);
            list.Add(m);
            list.Add("hello");

            Console.WriteLine(  ( (Textbook)list[0]).Purpose); Console.WriteLine("\nВсе печатные издания:");
            foreach (PrintedEdition l in list)
            {
                Console.WriteLine(l);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сработало");
        }
        finally
        {
            Console.WriteLine("Конец работы программы.");
        }
    }

}