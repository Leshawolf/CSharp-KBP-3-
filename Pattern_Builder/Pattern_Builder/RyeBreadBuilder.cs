using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Builder
{
    // строитель для ржаного хлеба
    class RyeBreadBuilder : BreadBuilder
    {

        public override void SetSpec_Zakaz()
        {
            this.Bread.Spec_Zakaz  = new Spec_Zakaz();
            Console.WriteLine($"RYE {this.Bread.Spec_Zakaz.Korob_pered} {this.Bread.Spec_Zakaz.Model}\n");
        }

        public override void SetRegix_Number()
        {
            // не используется
            this.Bread.Numbers = new Regix_Number();
        }
    }
}
