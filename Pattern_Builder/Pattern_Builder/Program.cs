using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Builder
{
public class Program
    { 
    static void Main(string[] args)
    {
        // содаем объект Покупателя
        Baker baker = new Baker();
        // создаем билдер для Автомобиля
        BreadBuilder builder = new RyeBreadBuilder();
        // Делаем его улучшенным
        Bread ryeBread = baker.Bake(builder);
        Console.WriteLine(ryeBread.ToString());
        // оздаем билдер для улучшенного автомобиля
        builder = new WheatBreadBuilder();
        Bread wheatBread = baker.Bake(builder);
        Console.WriteLine(wheatBread.ToString());

        Console.Read();
    }
    }
}

