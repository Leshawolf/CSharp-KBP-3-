using System;
namespace zad3;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 3\n" +
            "\tУсловие:\n"+
            "Создайте класс с двумя методами с одинаковой сигнатурой – " +
            "через аргументы передаѐтся массив с Фамилией Именем Отчеством сотрудника," +
            " а возвращается строка – в первом методе «Фамилия И.О.», во втором – «Фамилия Имя».\n" +
            "Создайте делегат для ссылки на эти методы и продемонстрируйте их работоспособность.\n");
        string[] fio = { "Волчек", "Алёшка", "Владимирович" };
        FullName fiocl = new FullName();
        Delegat del = fiocl.ShortInfo;
        Console.Write($"Вывод ФИО: {del(fio)}\n");
        del = fiocl.LongInfo;
        Console.Write($"Вывод Инициалы: { del(fio)}");
    }
}