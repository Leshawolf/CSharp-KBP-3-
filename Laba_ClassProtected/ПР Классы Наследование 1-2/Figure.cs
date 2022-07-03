using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_Классы_Наследование_1_2
{
    abstract class Figure{}
    к
    class Point : Figure
    {
        protected int x1, y1;

        public Point(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;
        }
        public virtual void Show()
        {
            Console.WriteLine($"*Точка*Кординаты точек: {x1}{y1}");
        }
    }

    class Line : Point
    {
        protected int lenght; 
            
        public Line(int lenght, int x1, int y1) : base(x1, y1)
        {
            this.lenght = lenght;
        }
        public override void Show()
        {
            Console.WriteLine($"*Линия*Кординаты точки начальной( X:{x1} Y:{y1} ) Длина линии: {lenght}");
        }
    }

    class Circle : Line
    {
        protected int radius;
        protected double S1;

        public Circle(int radius,int x1, int y1,int lenght) : base(lenght,x1, y1)
        {
            this.radius = radius;
        }
        public virtual void S()
        {
            S1 = Math.PI * Math.Pow((radius + radius), 2);
        }
        public override void Show()
        {
            Console.WriteLine($"*Круг*  Радиус: {radius} Кординаты точки начальной( X:{x1} Y:{y1} ) Длина линии: {lenght} Площадь: {S1:2}");
        }


    }
    class Cylinder : Circle
    {
        public int h;
        public double V1;
        public Cylinder(int h,int radius, int x1, int y1, int lenght) : base(radius, x1, y1, lenght)
        {
            this.h = h;
        }
        public override void S() 
        {
            S1 = (2 * Math.PI * radius * h) * (2 * Math.PI * Math.Pow(radius, 2));
        }
        public void V()
        {
            V1=Math.PI*Math.Pow(radius,2)*h;
        }
        public override void Show()
        {
            Console.WriteLine($"*Цилиндр*  Радиус: {radius} Кординаты точки начальной( X:{x1} Y:{y1} ) Длина линии: {lenght} Площадь поверхности цилиндра: {S1:2} Объём цилиндра: {V1:f2}");
        }
    }


}
