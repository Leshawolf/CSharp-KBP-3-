using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_Классы_Наследование_1_2
{
    class Pair
    {
      protected int first, second;
        public int First { set { first = value; } get { return first; } }
        public int Second { set { second = value; }get { return second; } }
        public Pair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public Pair Slog(Pair c)
        {
            return new Pair(this.first + this.second, c.first + c.second);
        }
        public override string ToString()
        {
            return $"({first}, {second})";
        }
    }
    class Money : Pair
    {
        public Money(int first, int second) : base(first, second)
        {}
        public Money Slog(Money c)
        {
            int kop = second + c.second;
            int rub = 0;
            if (kop >= 100) { rub ++; kop = kop % 100; }
            rub += first + c.first;
            return new Money(rub,kop);
        }
        public static Money operator +(Money a,Money b)
        {
            return new Money(a.first + a.first, a.second + b.second);
        }
        public static Money operator/(Money a,Money b)
        {
            return new Money(a.first / b.first, a.second / b.second);
        }
        public static Money operator-(Money a,Money b)
        {
            return new Money(a.first - b.first, a.second - b.second);   
        }
        public override string ToString()
        {
            return $"{first},{second} y.e.";
        }

    }

}
