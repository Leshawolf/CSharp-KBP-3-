using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Builder
{
    class Bread
    {
        // спец заказ
        public Spec_Zakaz Spec_Zakaz { get; set; }
        // номер
        public Regix_Number Numbers { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Spec_Zakaz != null)
            {
                string help;
                if(Spec_Zakaz.Korob_pered == true) { 
                    sb.Append(Spec_Zakaz.Model + "\n");
                    sb.Append("Коробка автомат\n");
                }
                else {
                    sb.Append(Spec_Zakaz.Model + "\n");
                    sb.Append("Ручная коробка передач\n");
                }
            }
            if (Numbers.Number != null)
                sb.Append("Регистрационный номер: " + Numbers.Number + " \n");
            return sb.ToString();
        }
    }
}
