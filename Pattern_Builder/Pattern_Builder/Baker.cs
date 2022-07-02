using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Builder
{
    // пекарь
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetSpec_Zakaz();
            breadBuilder.SetRegix_Number();
            return breadBuilder.Bread;
        }
    }
}
