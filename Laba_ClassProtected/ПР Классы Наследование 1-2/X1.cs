using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_Классы_Наследование_1_2
{
    class X1
    {
        protected int x1;
        protected int x2;
        public X1(int x1, int x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }
        public void Method()
        {
            Console.WriteLine("Вывод на консоль");
        }
    }
}
