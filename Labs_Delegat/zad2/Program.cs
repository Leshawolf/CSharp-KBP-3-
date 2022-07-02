using System;
namespace zad2;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 2\nУсловие:\n" +
            "Написать делегат, с помощью которого реализуется сортировка книг.\n"+
            "Книга представляет собой класс с полями Название, Автор, Издательство и конструктором.\n" +
            "Создать класс, являющийся контейнером для множества книг(массив книг).В этом классе предусмотреть метод сортировки книг.\n" +
            "Критерий сортировки определяется экземпляром делегата, который передается методу в качестве параметра.\n" +
            "Каждый экземпляр делегата должен сравнивать книги по какому - то одному полю: названию, автору, издательству.");
        Book[] book = new Book[2];
        book[0] = new Book("Антарктида", "Бельников", "Версин");
        book[1] = new Book("Будущее", "Анютинко", "Венера");
        book[2] = new Book("Веном", "Бульняк", "Анна");
        book[3] = new Book("Веном", "Бульняк", "Анна");
        LibraryBook library = new LibraryBook(book);
        Console.WriteLine("===============================================");
        Console.WriteLine("Сортировка по автору: \n");
        library.SortLibrary(new DelegatToSortZad2(library.SortAuthor));
        Console.WriteLine(library);
        Console.WriteLine("===============================================");
        Console.WriteLine("\nСортировка по названию: \n");
        library.SortLibrary(new DelegatToSortZad2(library.SortName));
        Console.WriteLine(library);
        Console.WriteLine("===============================================");
        Console.WriteLine("\nСортировка по издательству: \n");
        library.SortLibrary(new DelegatToSortZad2(library.SortPublishing));
        Console.WriteLine(library);
        
    }
}