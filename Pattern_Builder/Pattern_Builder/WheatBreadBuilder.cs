using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Builder
{
    // строитель для пшеничного хлеба
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetSpec_Zakaz()
        {
            this.Bread.Spec_Zakaz = new Spec_Zakaz { Korob_pered = true,Model="Volvo" };
            Console.WriteLine($"RYE {this.Bread.Spec_Zakaz.Korob_pered} {this.Bread.Spec_Zakaz.Model}\n");
        }

        public override void SetRegix_Number()
        {
            this.Bread.Numbers = new Regix_Number { Number = "В777ОР" };
        }
    }
}
