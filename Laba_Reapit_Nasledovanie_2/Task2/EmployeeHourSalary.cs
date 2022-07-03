using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class EmployeeHourSalary : Employee
    {
        double salaryForHour;

        public EmployeeHourSalary(string name, string position, double salaryForHour) : base(name, position)
        {
            if (salaryForHour <= 0)
                throw new ArgumentException("Ошибка!!! Зарплата не может быть меньше или равна 0");
            this.salaryForHour = salaryForHour;
        }

        public override double CountMonthSalary(ref double monthSalary)
        {
            monthSalary = 20.8 * 8 * salaryForHour;
            return monthSalary;
        }

        public override string ToString()
        {
            return base.ToString() + $", почасовая зарплата: {salaryForHour}, месячная зарплата: {CountMonthSalary(ref monthSalary)}";
        }
    }
}
