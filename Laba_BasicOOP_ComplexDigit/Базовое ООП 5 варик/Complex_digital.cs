using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базовое_ООП_5_варик
{
    class Complex_digital
    {
        private double modul;
        private double argument;
        private Complex_digital(double modul, double argument)
        {
            this.modul = modul;
            this.argument = argument;
        }
        public static Complex_digital Triganamet(double modul, double argument)
        {
            return new Complex_digital(modul, argument);
        }
        //public static Complex_digital Actual_part(double modul,double argument)
        //{
        //    return
        //}
        public static Complex_digital Complex_Create(double actual,double image)
        {
            double mod = Math.Sqrt(actual*actual+image*image);
            double arg = actual / mod;
            return new Complex_digital(mod,arg);
        }
        public double Modul 
        {
            get { return modul; }
        }
        public double Argument
        { 
            get { return argument; }
        }
        public double Real => modul * Math.Sin(argument);
        public double Image => modul * Math.Cos(argument);

        public Complex_digital Multiplication(Complex_digital obj1)
        {
           
            return new Complex_digital(modul*obj1.modul, argument*obj1.argument);
        }
        public Complex_digital Division(Complex_digital obj2)
        {
            return new Complex_digital(modul*obj2.modul, argument*obj2.argument);
        }

    }
}
