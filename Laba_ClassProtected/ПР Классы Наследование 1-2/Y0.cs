using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР_Классы_Наследование_1_2
{
    class Y0 : X1
    {
        int y1;

        public Y0(int y1,int x1, int x2) : base(x1, x2)
        {
            this.y1 = y1;
        }
        public int Run()
        {
            return (x1 + x2) / y1;
        }
    }
}
