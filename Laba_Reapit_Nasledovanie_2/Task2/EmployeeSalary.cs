using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
 class EmployeeSalary : Employee
    {
        double fixmonthSalary;

        public EmployeeSalary(string name, string position, double fixmonthSalary) : base(name, position)
        {
            if (fixmonthSalary <= 0)
                throw new ArgumentException("Ошибка! Зарплата введена меньше или равна 0");
            this.fixmonthSalary = fixmonthSalary;
        }
        public override double CountMonthSalary(ref double monthSalary)
        {
            monthSalary = fixmonthSalary;
            return monthSalary;
        }
        public override string ToString()
        {
            return base.ToString() + $", фиксированная месячная зарплата: {CountMonthSalary(ref monthSalary)}";
        }
    }
}
