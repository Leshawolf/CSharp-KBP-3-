using System;
using System.Collections;
namespace Task2;
class Task2
{
    static void Main(string[] args)
    {
        ReplicMain();
        Console.ReadLine();
    }
    static void ReplicMain()
    {
        try
        {

            List<Employee> list2 = new List<Employee>();
            list2.Add(new EmployeeHourSalary("Гена", "Программист", 4));
            list2.Add(new EmployeeSalary("Дина", "Разработчик", 2000));
            list2.Add(new EmployeeHourSalary("Витя", "Администратор", 5));
            list2.Add(new EmployeeSalary("Абрам", "Разработчик", 1000));
            list2.Add(new EmployeeHourSalary("Бобик", "Программист", 2));
            list2.Add(new EmployeeHourSalary("Абгин", "Дезайнер", 10));
            Console.WriteLine("Список до иземенения: ");
            foreach (Employee emp in list2)
            {
                Console.WriteLine(emp);
            }
            list2.Sort();
            Console.WriteLine("\nВсе сотрудники:");
            foreach (Employee e in list2)
            {
                Console.WriteLine(e);
            }
            double f = 0;
           list2[0].CountMonthSalary(ref f);
            Console.WriteLine(f);
            Console.WriteLine("\nПервые пять имен: ");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(list2[i].Name);
            }
            Console.WriteLine("\nТри последних идентификатора: ");
            for (int i = list2.Count - 3; i < list2.Count; i++)
            {
                Console.WriteLine(list2[i].id);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Конец программы");
        }
    }
}